//
//  MainMapView.swift
//  Orbital
//
//  Created by Xu Siyi on 16/5/24.
//


// using firebase messaging SDK for community interactions
import SwiftUI
import MapKit
import FirebaseCore
import FirebaseFirestore
import FirebaseAuth
import Firebase


struct MainMapView: UIViewRepresentable {
    
    @ObservedObject var locationManager = LocationManager()
    let db = Firestore.firestore()

    func makeUIView(context: Context) -> MKMapView {
        let mapView = MKMapView()
        mapView.showsUserLocation = true
        mapView.userTrackingMode = .follow
        return mapView
    }

    
    func updateUIView(_ view: MKMapView, context: Context) {
        if let location = locationManager.location {
            let region = MKCoordinateRegion(
                center: location.coordinate,
                span: MKCoordinateSpan(latitudeDelta: 0.05, longitudeDelta: 0.05)
            )
            view.setRegion(region, animated: true)
        }
        
        
        // Fetch other users and display on the map
        db.collection("users").getDocuments { (snapshot, error) in
            guard let documents = snapshot?.documents else { return }
            for document in documents {
                let data = document.data()
                let username = data["username"] as? String ?? "Unknown"
                let latitude = data["latitude"] as? CLLocationDegrees ?? 0.0
                let longitude = data["longitude"] as? CLLocationDegrees ?? 0.0
                let privacySetting = data["privacySetting"] as? Bool ?? true

                if privacySetting {
                    let annotation = MKPointAnnotation()
                    annotation.title = username
                    annotation.coordinate = CLLocationCoordinate2D(latitude: latitude, longitude: longitude)
                    view.addAnnotation(annotation)
                }
            }
        }
    }
}

#Preview {
    MainMapView().edgesIgnoringSafeArea(.all).previewInterfaceOrientation(.landscapeLeft)
}
