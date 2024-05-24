import SwiftUI
import MapKit

struct MapView: UIViewRepresentable {
    @Binding var region: MKCoordinateRegion
    var nusRegion: MKCoordinateRegion

    func makeUIView(context: Context) -> MKMapView {
        let mapView = MKMapView()
        mapView.delegate = context.coordinator
        mapView.showsUserLocation = true
        mapView.setRegion(region, animated: true)
        return mapView
    }

    func updateUIView(_ uiView: MKMapView, context: Context) {
        uiView.setRegion(region, animated: true)
    }

    func makeCoordinator() -> Coordinator {
        Coordinator(self, nusRegion: nusRegion)
    }

    class Coordinator: NSObject, MKMapViewDelegate {
        var parent: MapView
        var nusRegion: MKCoordinateRegion

        init(_ parent: MapView, nusRegion: MKCoordinateRegion) {
            self.parent = parent
            self.nusRegion = nusRegion
        }

        func mapView(_ mapView: MKMapView, regionDidChangeAnimated animated: Bool) {
            let northWest = CLLocationCoordinate2D(
                latitude: nusRegion.center.latitude + (nusRegion.span.latitudeDelta / 2.0),
                longitude: nusRegion.center.longitude - (nusRegion.span.longitudeDelta / 2.0)
            )
            let southEast = CLLocationCoordinate2D(
                latitude: nusRegion.center.latitude - (nusRegion.span.latitudeDelta / 2.0),
                longitude: nusRegion.center.longitude + (nusRegion.span.longitudeDelta / 2.0)
            )

            let visibleRegion = mapView.region
            let visibleNorthWest = CLLocationCoordinate2D(
                latitude: visibleRegion.center.latitude + (visibleRegion.span.latitudeDelta / 2.0),
                longitude: visibleRegion.center.longitude - (visibleRegion.span.longitudeDelta / 2.0)
            )
            let visibleSouthEast = CLLocationCoordinate2D(
                latitude: visibleRegion.center.latitude - (visibleRegion.span.latitudeDelta / 2.0),
                longitude: visibleRegion.center.longitude + (visibleRegion.span.longitudeDelta / 2.0)
            )

            if visibleNorthWest.latitude > northWest.latitude ||
                visibleNorthWest.longitude < northWest.longitude ||
                visibleSouthEast.latitude < southEast.latitude ||
                visibleSouthEast.longitude > southEast.longitude {
                
                mapView.setRegion(nusRegion, animated: true)
            }
        }
    }
}

