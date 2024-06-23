import SwiftUI
import FirebaseFirestore
import Firebase
import MapKit

struct MapContentView: View {
    @StateObject private var locationService = LocationService.shared
    @State private var region = MKCoordinateRegion(
        center: CLLocationCoordinate2D(latitude: 1.2966, longitude: 103.7764), // NUS coordinates
        span: MKCoordinateSpan(latitudeDelta: 0.01, longitudeDelta: 0.01)
    )
    @State private var userTrackingMode: MKUserTrackingMode = .follow
    @State private var annotations: [CustomAnnotation] = []
    @State private var overlays: [CustomMapOverlay] = []
    @State private var selectedBuildingID: String? = nil

    @State private var lastMessageTime: Date?
    @State private var showMessageTimer: Timer?

    var body: some View {
        ZStack {
            MapViewRepresentable(region: $region, locationService: locationService, userTrackingMode: $userTrackingMode, annotations: $annotations, overlays: $overlays, selectedBuildingID: $selectedBuildingID)
                .edgesIgnoringSafeArea(.all)
            NavigationLink(
                destination: BuildingView(buildingID: selectedBuildingID ?? ""),
                isActive: Binding(
                    get: { selectedBuildingID != nil },
                    set: { if !$0 { selectedBuildingID = nil } }
                )
            ) {
                EmptyView()
            }
        }
        .onAppear {
            fetchVenueData()
            startMessageTimer()
        }
        .onDisappear {
            showMessageTimer?.invalidate()
        }
        .onChange(of: locationService.location) { newLocation in
            detectVenueProximity(location: newLocation?.location)
        }
        .onChange(of: selectedBuildingID) { _ in
            if selectedBuildingID != nil {
                // if currently in a building , don't show any messages
            }
        }
    }
    
    private func fetchVenueData() {
        let db = Firestore.firestore()
        print("\n start fetching data from firebase \n")
        db.collection("key_venues").getDocuments { snapshot, error in
            guard let documents = snapshot?.documents else { return }
            var newAnnotations: [CustomAnnotation] = []
            var newOverlays: [CustomMapOverlay] = []

            for document in documents {
                let data = document.data()
                guard let name = data["name"] as? String,
                      let levels = data["levels"] as? Int,
                      let capacity = data["capacity"] as? Int,
                      let coordinates = data["coordinates"] as? [GeoPoint], coordinates.count == 2 else { continue }

                let coordinate1 = CLLocationCoordinate2D(
                    latitude: coordinates[0].latitude,
                    longitude: coordinates[0].longitude)
                let coordinate2 = CLLocationCoordinate2D(
                    latitude: coordinates[1].latitude,
                    longitude: coordinates[1].longitude)

                // Calculate the center of the bounding box for the annotation
                let centerCoordinate = CLLocationCoordinate2D(
                    latitude: (coordinate1.latitude + coordinate2.latitude) / 2,
                    longitude: (coordinate1.longitude + coordinate2.longitude) / 2
                )

                // Calculate the top left and bottom right points for the bounding box
                let topLeftMapPoint = MKMapPoint(coordinate1)
                let bottomRightMapPoint = MKMapPoint(coordinate2)

                // Calculate the bounding map rectangle
                let boundingMapRect = MKMapRect(
                    origin: MKMapPoint(
                        x: min(topLeftMapPoint.x, bottomRightMapPoint.x),
                        y: min(topLeftMapPoint.y, bottomRightMapPoint.y)
                    ),
                    size: MKMapSize(
                        width: abs(topLeftMapPoint.x - bottomRightMapPoint.x),
                        height: abs(topLeftMapPoint.y - bottomRightMapPoint.y)
                    )
                )

                let overlay = CustomMapOverlay(coordinate1: coordinate1, coordinate2: coordinate2, title: name, levels: levels, capacity: capacity, buildingID: document.documentID, boundingMapRect: boundingMapRect)
                let annotation = CustomAnnotation(coordinate: centerCoordinate, title: name, subtitle: "Levels: \(levels), Capacity: \(capacity)", buildingID: document.documentID)

                newOverlays.append(overlay)
                newAnnotations.append(annotation)
            }

            annotations = newAnnotations
            overlays = newOverlays
            print("Annotations: \(annotations)")
            print("Overlays: \(overlays)")
        }
    }
    
    private func fetchUserLocations() {
        let db = Firestore.firestore()
        db.collection("users-locations").addSnapshotListener { snapshot, error in
            guard let documents = snapshot?.documents else { return }
            var newAnnotations: [CustomAnnotation] = []
            
            for document in documents {
                let data = document.data()
                guard let latitude = data["latitude"] as? Double,
                      let longitude = data["longitude"] as? Double,
                      let userID = document.documentID as? String else { continue }
                
                let coordinate = CLLocationCoordinate2D(latitude: latitude, longitude: longitude)
                let annotation = CustomAnnotation(coordinate: coordinate, title: "User \(userID)", subtitle: "Details", buildingID: userID)
                newAnnotations.append(annotation)
            }
            
            annotations = newAnnotations
        }
    }
    
    private func detectVenueProximity(location: CLLocation?) {
        guard let location = location else { return }

        for annotation in annotations {
            let venueLocation = CLLocation(latitude: annotation.coordinate.latitude, longitude: annotation.coordinate.longitude)
            let distance = location.distance(from: venueLocation)
            
            if distance < 50 { // 50 meters range
                if shouldShowMessage() {
                    showInAppMessage(for: annotation.buildingID)
                }
            } else {
                NotificationService.shared.unsubscribeFromVenueTopic(buildingID: annotation.buildingID)
            }
        }
    }

    private func shouldShowMessage() -> Bool {
        guard let lastMessageTime = lastMessageTime else {
            self.lastMessageTime = Date()
            return true
        }
        let elapsedTime = Date().timeIntervalSince(lastMessageTime)
        if elapsedTime >= 20 {
            self.lastMessageTime = Date()
            return true
        }
        return false
    }

    private func showInAppMessage(for buildingID: String) {
        let db = Firestore.firestore()
        db.collection("key_venues").document(buildingID).getDocument { document, error in
            if let document = document, document.exists {
                let data = document.data()
                let venueName = data?["name"] as? String ?? "Unknown"
                
                let alert = UIAlertController(title: "Detected Venue", message: "You are near \(venueName). Enter?", preferredStyle: .alert)
                alert.addAction(UIAlertAction(title: "Enter", style: .default, handler: { _ in
                    self.selectedBuildingID = buildingID
                    NotificationService.shared.subscribeToVenueTopic(buildingID: buildingID)
                }))
                alert.addAction(UIAlertAction(title: "Dismiss", style: .cancel, handler: nil))
                
                if let window = UIApplication.shared.windows.first {
                    window.rootViewController?.present(alert, animated: true, completion: nil)
                }
            }
        }
    }

    private func startMessageTimer() {
        showMessageTimer = Timer.scheduledTimer(withTimeInterval: 20, repeats: true) { _ in
            self.lastMessageTime = nil
        }
    }
}

struct MapContentView_Previews: PreviewProvider {
    static var previews: some View {
        MapContentView()
    }
}
