import SwiftUI
import MapKit
import CoreLocation
import Foundation


struct MainMapView: View {
//    @StateObject private var locationManager = LocationManager()
//    @State private var region = MKCoordinateRegion(center: CLLocationCoordinate2D(latitude: 37.7749, longitude: -122.4194),
//                                                   span: MKCoordinateSpan(latitudeDelta: 0.05, longitudeDelta: 0.05))
    @Binding var showSettingsOverlay: Bool

    var body: some View {
        NavigationView {
            ZStack {
//                Map(coordinateRegion: $region, showsUserLocation: true)
//                    .onAppear {
//                        if let userLocation = locationManager.userLocation {
//                            region.center = userLocation.coordinate
//                        }
//                    }
                MapContentView()
                
                if showSettingsOverlay {
                    SettingsOverlay(showSettingsOverlay: $showSettingsOverlay)
                }
                
                HStack {
                    Spacer()
                    VStack(spacing: 20) {
                        NavigationLink(destination: FurnitureMarketView()) {
                            VStack {
                                Image(systemName: "cart.fill")
                                    .resizable()
                                    .frame(width: 50, height: 50)
                                    .padding()
                                    .background(Color.blue)
                                    .foregroundColor(.white)
                                    .clipShape(Circle())
                                Text("To Furniture Market")
                                    .foregroundColor(.blue)
                            }
                        }
                        .padding()

                        NavigationLink(destination: MyIslandView()) {
                            VStack {
                                Image(systemName: "leaf.arrow.circlepath")
                                    .resizable()
                                    .frame(width: 50, height: 50)
                                    .padding()
                                    .background(Color.green)
                                    .foregroundColor(.white)
                                    .clipShape(Circle())
                                Text("My Island")
                                    .foregroundColor(.green)
                            }
                        }
                        .padding()
                        Spacer()
                    }
                    .padding()
                }
            }
            .navigationBarHidden(true)
        }
        .navigationViewStyle(StackNavigationViewStyle())
    }
}

//class LocationManager: NSObject, ObservableObject, CLLocationManagerDelegate {
//    private let locationManager = CLLocationManager()
//    @Published var userLocation: CLLocation?
//
//    override init() {
//        super.init()
//        locationManager.delegate = self
//        locationManager.desiredAccuracy = kCLLocationAccuracyBest
//        locationManager.requestWhenInUseAuthorization()
//        locationManager.startUpdatingLocation()
//    }
//
//    func locationManager(_ manager: CLLocationManager, didUpdateLocations locations: [CLLocation]) {
//        guard let location = locations.last else { return }
//        userLocation = location
//    }
//}
