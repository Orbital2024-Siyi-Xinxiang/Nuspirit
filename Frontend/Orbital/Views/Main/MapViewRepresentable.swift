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
    @Binding var userTrackingMode: MKUserTrackingMode
    @Binding var annotations: [CustomMapOverlay]

    func makeUIView(context: Context) -> MKMapView {
        let mapView = MKMapView()
        mapView.delegate = context.coordinator
        mapView.showsUserLocation = true
        mapView.setRegion(region, animated: false)
        mapView.userTrackingMode = userTrackingMode
        
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

        let overlay = CustomMapOverlay(
            coordinate1: nusCoordinate,
            coordinate2: nusCoordinate,  // Use the same coordinate for the initial overlay
            title: "NUS",
            levels: 0,
            capacity: 0,
            buildingID: "initial_overlay"
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
        
        // make user location center
        func mapView(_ mapView: MKMapView, didUpdate userLocation: MKUserLocation) {
            parent.region.center = userLocation.coordinate
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

                annotationView?.image = UIImage(named: "TestChar")
                annotationView?.frame.size = CGSize(width: 30, height: 30)

                return annotationView
            } else if let customAnnotation = annotation as? CustomMapOverlay {
                let identifier = "BuildingAnnotation"
                var annotationView = mapView.dequeueReusableAnnotationView(withIdentifier: identifier) as? MKPinAnnotationView
                
                if annotationView == nil {
                    annotationView = MKPinAnnotationView(annotation: annotation, reuseIdentifier: identifier)
                    annotationView?.canShowCallout = true
                    
                    let button = UIButton(type: .detailDisclosure)
                    button.setTitle("Enter", for: .normal)
                    annotationView?.rightCalloutAccessoryView = button

                    let imageView = UIImageView(image: UIImage(systemName: "photo"))
                    imageView.frame = CGRect(x: 0, y: 0, width: 30, height: 30)
                    annotationView?.leftCalloutAccessoryView = imageView
                } else {
                    annotationView?.annotation = annotation
                }
                
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
    
    func mapView(_ mapView: MKMapView, annotationView view: MKAnnotationView, calloutAccessoryControlTapped control: UIControl) {
        if let customAnnotation = view.annotation as? CustomMapOverlay {
            parent.selectedBuildingID = customAnnotation.buildingID
        }
    }
}

