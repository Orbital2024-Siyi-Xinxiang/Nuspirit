import SwiftUI
import MapKit

struct MainMapView: View {
    @StateObject private var locationManager = LocationManager()
    @State private var region = MKCoordinateRegion(center: CLLocationCoordinate2D(latitude: 37.7749, longitude: -122.4194),
                                                   span: MKCoordinateSpan(latitudeDelta: 0.05, longitudeDelta: 0.05))
    @Binding var showSettingsOverlay: Bool

    var body: some View {
        ZStack {
            Map(coordinateRegion: $region, showsUserLocation: true)
                .onAppear {
                    if let userLocation = locationManager.userLocation {
                        region.center = userLocation.coordinate
                    }
                }

            if showSettingsOverlay {
                SettingsOverlay(showSettingsOverlay: $showSettingsOverlay)
            }
        }
    }
}

class LocationManager: NSObject, ObservableObject, CLLocationManagerDelegate {
    private let locationManager = CLLocationManager()
    @Published var userLocation: CLLocation?

    override init() {
        super.init()
        locationManager.delegate = self
        locationManager.desiredAccuracy = kCLLocationAccuracyBest
        locationManager.requestWhenInUseAuthorization()
        locationManager.startUpdatingLocation()
    }

    func locationManager(_ manager: CLLocationManager, didUpdateLocations locations: [CLLocation]) {
        guard let location = locations.last else { return }
        userLocation = location
    }
}
