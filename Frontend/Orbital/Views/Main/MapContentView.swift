import SwiftUI
import MapKit

struct MapContentView: View {
    @StateObject private var locationService = LocationService.shared
    @State private var region = MKCoordinateRegion(
        center: CLLocationCoordinate2D(latitude: 1.2966, longitude: 103.7764), // NUS coordinates
        span: MKCoordinateSpan(latitudeDelta: 0.01, longitudeDelta: 0.01)
    )
    @State private var userTrackingMode: MKUserTrackingMode = .follow
    @State private var annotations: [CustomMapOverlay] = []

    var body: some View {
        ZStack {
            MapViewRepresentable(region: $region, locationService: locationService, userTrackingMode: $userTrackingMode)
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
        .onAppear{
            fetchVenueData()
        }
        .onReceive(locationService.$location) { location in
            guard let location = location else { return }

            // Inline restrictRegion functionality
            var newCenter = location.location.coordinate
            let maxLatitude = 1.2966 + 0.005
            let minLatitude = 1.2966 - 0.005
            let maxLongitude = 103.7764 + 0.005
            let minLongitude = 103.7764 - 0.005

            if newCenter.latitude > maxLatitude {
                newCenter.latitude = maxLatitude
            } else if newCenter.latitude < minLatitude {
                newCenter.latitude = minLatitude
            }

            if newCenter.longitude > maxLongitude {
                newCenter.longitude = maxLongitude
            } else if newCenter.longitude < minLongitude {
                newCenter.longitude = minLongitude
            }

            // Update the center while preserving the current span
            region.center = newCenter
        }
    }
    
    private func fetchVenueData() {
        let db = Firestore.firestore()
        db.collection("key_venues").getDocuments { snapshot, error in
            guard let documents = snapshot?.documents else { return }
            var newAnnotations: [CustomMapOverlay] = []
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
                
                let annotation = CustomMapOverlay(coordinate1: coordinate1, coordinate2: coordinate2, title: name, levels: levels, capacity: capacity, buildingID: document.documentID)
                newAnnotations.append(annotation)
            }
            annotations = newAnnotations
        }
    }
}



struct MapContentView_Previews: PreviewProvider {
    static var previews: some View {
        MapContentView()
    }
}

