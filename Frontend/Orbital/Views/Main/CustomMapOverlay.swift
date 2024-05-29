import MapKit

//class CustomMapOverlay: NSObject, MKOverlay {
//    var coordinate: CLLocationCoordinate2D
//    var boundingMapRect: MKMapRect
//
//    init(coordinate: CLLocationCoordinate2D, boundingMapRect: MKMapRect) {
//        self.coordinate = coordinate
//        self.boundingMapRect = boundingMapRect
//    }
//}

class CustomMapOverlay: MKAnnotation {
    var coordinate1: CLLocationCoordinate2D
    var coordinate2: CLLocationCoordinate2D
    var title: String?
    var subtitle: String?
    var buildingID: String
    var
    
    init(coordinate: CLLocationCoordinate2D, title: String, subtitle: String, buildingID: String) {
        self.coordinate = coordinate
        self.title = title
        self.subtitle = subtitle
        self.buildingID = buildingID
    }
}


class CustomMapOverlayRenderer: MKOverlayRenderer {
    override func draw(_ mapRect: MKMapRect, zoomScale: MKZoomScale, in context: CGContext) {
        guard let image = UIImage(named: "TestMap") else { return }

        let rect = self.rect(for: overlay.boundingMapRect)

        // Save the context state
        context.saveGState()

        // Flip the context vertically
        context.translateBy(x: rect.midX, y: rect.midY)
        context.scaleBy(x: 1.0, y: -1.0)
        context.translateBy(x: -rect.midX, y: -rect.midY)

        // Draw the image
        context.draw(image.cgImage!, in: rect)

        // Restore the context state
        context.restoreGState()
    }
}
