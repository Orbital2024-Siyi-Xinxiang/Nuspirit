import SwiftUI
import MapKit

// Extension to make CLLocationCoordinate2D conform to Equatable
extension CLLocationCoordinate2D: Equatable {
    public static func ==(lhs: CLLocationCoordinate2D, rhs: CLLocationCoordinate2D) -> Bool {
        return lhs.latitude == rhs.latitude && lhs.longitude == rhs.longitude
    }
}

struct MapViewRepresentable: UIViewRepresentable {
    @Binding var region: MKCoordinateRegion
    @ObservedObject var locationService: LocationService

    func makeUIView(context: Context) -> MKMapView {
        let mapView = MKMapView()
        mapView.delegate = context.coordinator
        mapView.showsUserLocation = true
        mapView.setRegion(region, animated: false)

        // Define the bounding box for the NUS region
        let nusCoordinate = CLLocationCoordinate2D(latitude: 1.2966, longitude: 103.7764)
        let nusTopLeft = CLLocationCoordinate2D(latitude: 1.310306, longitude: 103.764663)
        let nusBottomRight = CLLocationCoordinate2D(latitude: 1.287961, longitude: 103.788603)

        let topLeftMapPoint = MKMapPoint(nusTopLeft)
        let bottomRightMapPoint = MKMapPoint(nusBottomRight)

        let boundingMapRect = MKMapRect(
            origin: topLeftMapPoint,
            size: MKMapSize(width: bottomRightMapPoint.x - topLeftMapPoint.x, height: bottomRightMapPoint.y - topLeftMapPoint.y)
        )

        // Add the custom map overlay
        let overlay = CustomMapOverlay(
            coordinate: nusCoordinate,
            boundingMapRect: boundingMapRect
        )
        mapView.addOverlay(overlay)

        return mapView
    }

    func updateUIView(_ mapView: MKMapView, context: Context) {
        mapView.setRegion(region, animated: true)
    }

    func makeCoordinator() -> Coordinator {
        Coordinator(self)
    }

    class Coordinator: NSObject, MKMapViewDelegate {
        var parent: MapViewRepresentable

        init(_ parent: MapViewRepresentable) {
            self.parent = parent
        }

        func mapView(_ mapView: MKMapView, rendererFor overlay: MKOverlay) -> MKOverlayRenderer {
            if let overlay = overlay as? CustomMapOverlay {
                return CustomMapOverlayRenderer(overlay: overlay)
            }
            return MKOverlayRenderer(overlay: overlay)
        }

        // Customize user location annotation view
        func mapView(_ mapView: MKMapView, viewFor annotation: MKAnnotation) -> MKAnnotationView? {
            if annotation is MKUserLocation {
                let identifier = "UserLocation"
                var annotationView = mapView.dequeueReusableAnnotationView(withIdentifier: identifier)
                if annotationView == nil {
                    annotationView = MKAnnotationView(annotation: annotation, reuseIdentifier: identifier)
                } else {
                    annotationView?.annotation = annotation
                }

                // Load custom symbol from Assets
                annotationView?.image = UIImage(named: "TestChar")
                annotationView?.frame.size = CGSize(width: 30, height: 30) // Set the size to 30x30 pixels

                return annotationView
            }

            return nil
        }


        func mapView(_ mapView: MKMapView, regionDidChangeAnimated animated: Bool) {
            var newCenter = mapView.region.center
            let maxLatitude = 1.310306
            let minLatitude = 1.287961
            let maxLongitude = 103.788603
            let minLongitude = 103.764663

            // Restrict the center coordinates
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

            // Only update the center if it needs to be restricted
            if newCenter != mapView.region.center {
                mapView.setCenter(newCenter, animated: true)
            }

            parent.region = mapView.region
        }
    }
}

