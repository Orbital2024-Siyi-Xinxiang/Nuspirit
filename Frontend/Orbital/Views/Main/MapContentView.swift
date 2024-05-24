import SwiftUI
import MapKit

struct MapContentView: View {
    @StateObject private var locationService = LocationService.shared
    @State private var region = MKCoordinateRegion(
        center: CLLocationCoordinate2D(latitude: 1.2966, longitude: 103.7764), // NUS coordinates
        span: MKCoordinateSpan(latitudeDelta: 0.01, longitudeDelta: 0.01)
    )

    var body: some View {
        ZStack {
            MapViewRepresentable(region: $region, locationService: locationService)
                .edgesIgnoringSafeArea(.all)
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
}

struct MapContentView_Previews: PreviewProvider {
    static var previews: some View {
        MapContentView()
    }
}

