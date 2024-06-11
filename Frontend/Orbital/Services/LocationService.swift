//
//  LocationService.swift
//  Orbital
//
//  Created by Wulala's Macbook on 14/5/24.
//
import FirebaseFirestore
import Foundation
import CoreLocation
import FirebaseAuth
import FirebaseCore

struct IdentifiableLocation: Identifiable {
    let id = UUID()
    let location: CLLocation
}

class LocationService: NSObject, CLLocationManagerDelegate, ObservableObject {
    static let shared = LocationService()
    private let locationManager = CLLocationManager()
    
    @Published var location: IdentifiableLocation? = nil

    override init() {
        super.init()
        locationManager.delegate = self
        locationManager.desiredAccuracy = kCLLocationAccuracyBestForNavigation
        locationManager.requestWhenInUseAuthorization()
        locationManager.startUpdatingLocation()  // Start location updates here
    }

    func locationManager(_ manager: CLLocationManager, didUpdateLocations locations: [CLLocation]) {
        guard let location = locations.last else { return }
        self.location = IdentifiableLocation(location: location)
        // Post location to Firestore
        updateLocationInFirestore(location: location)
        
        // Post location to the app
        NotificationCenter.default.post(name: NSNotification.Name("LocationUpdate"), object: nil, userInfo: ["location": location])
    }
    
    private func updateLocationInFirestore(location: CLLocation) {
        guard let userID = Auth.auth().currentUser?.uid else { return }
        let db = Firestore.firestore()
        db.collection("users_locations").document(userID).setData([
            "latitude": location.coordinate.latitude,
            "longitude": location.coordinate.longitude,
            "timestamp": Timestamp(date: Date())
            
        ], merge: true)
    }
    
}

