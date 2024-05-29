import Foundation
import FirebaseCore
import Firebase
import FirebaseAuth
import FirebaseAuthUI
import UserNotifications
import FirebaseFacebookAuthUI
import FirebaseGoogleAuthUI
import FirebaseOAuthUI
import FirebasePhoneAuthUI
import FirebaseEmailAuthUI
import FirebaseEmailAuthUI
import UIKit
import SwiftUI
import GoogleSignIn
import FBSDKCoreKit
import FBSDKLoginKit
import MapKit
import FirebaseFirestore
import FirebaseFirestoreUI

struct MapContentView: View {
    @StateObject private var locationService = LocationService.shared
    @State private var region = MKCoordinateRegion(
        center: CLLocationCoordinate2D(latitude: 1.2966, longitude: 103.7764), // NUS coordinates
        span: MKCoordinateSpan(latitudeDelta: 0.01, longitudeDelta: 0.01)
    )
    @State private var userTrackingMode: MKUserTrackingMode = .follow
    @State private var annotations: [CustomMapOverlay] = []
    @State private var selectedBuildingID: String? = nil

    var body: some View {
        ZStack {
            MapViewRepresentable(region: $region, locationService: locationService, userTrackingMode: $userTrackingMode, annotations: $annotations, selectedBuildingID: $selectedBuildingID)
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
//        .onReceive(locationService.$location) { location in
//            guard let location = location else { return }
//
//            // Inline restrictRegion functionality
//            var newCenter = location.location.coordinate
//            let maxLatitude = 1.2966 + 0.005
//            let minLatitude = 1.2966 - 0.005
//            let maxLongitude = 103.7764 + 0.005
//            let minLongitude = 103.7764 - 0.005
//
//            if newCenter.latitude > maxLatitude {
//                newCenter.latitude = maxLatitude
//            } else if newCenter.latitude < minLatitude {
//                newCenter.latitude = minLatitude
//            }
//
//            if newCenter.longitude > maxLongitude {
//                newCenter.longitude = maxLongitude
//            } else if newCenter.longitude < minLongitude {
//                newCenter.longitude = minLongitude
//            }
//
//            // Update the center while preserving the current span
//            region.center = newCenter
//        }
    }
    
    private func fetchVenueData() {
        let db = Firestore.firestore()
        print("\n start fetching data from firebase \n")
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
                
                let annotation = CustomMapOverlay(coordinate1: coordinate1, coordinate2: coordinate2, title: name, levels: levels, capacity: capacity, buildingID: document.documentID, boundingMapRect: boundingMapRect)
                newAnnotations.append(annotation)
            }
            annotations = newAnnotations
            print(annotations)
        }
    }
}



struct MapContentView_Previews: PreviewProvider {
    static var previews: some View {
        MapContentView()
    }
}




