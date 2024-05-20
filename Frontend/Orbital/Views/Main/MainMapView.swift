//
//  MainMapView.swift
//  Orbital
//
//  Created by Xu Siyi on 16/5/24.
//

import SwiftUI
import MapKit

struct MainMapView: UIViewRepresentable {
    
    @ObservedObject var locationManager = LocationManager()

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
    }
}

#Preview {
    MainMapView().edgesIgnoringSafeArea(.all).previewInterfaceOrientation(.landscapeLeft)
}
