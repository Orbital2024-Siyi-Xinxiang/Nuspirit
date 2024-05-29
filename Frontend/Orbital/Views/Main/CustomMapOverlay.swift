import MapKit

class CustomMapOverlay: NSObject, MKAnnotation, MKOverlay {
    var boundingMapRect: MKMapRect
    
    var coordinate: CLLocationCoordinate2D {
        return coordinate1
    }
    var coordinate1: CLLocationCoordinate2D
    var coordinate2: CLLocationCoordinate2D
    var title: String?
    var levels: Int
    var capacity: Int
    var buildingID: String

    init(coordinate1: CLLocationCoordinate2D, coordinate2: CLLocationCoordinate2D, title: String, levels: Int, capacity: Int, buildingID: String, boundingMapRect: MKMapRect) {
        self.coordinate1 = coordinate1
        self.coordinate2 = coordinate2
        self.title = title
        self.levels = levels
        self.capacity = capacity
        self.buildingID = buildingID
        self.boundingMapRect = boundingMapRect
    }
}

class CustomMapOverlayRenderer: MKOverlayRenderer {
    override func draw(_ mapRect: MKMapRect, zoomScale: MKZoomScale, in context: CGContext) {
        guard let overlay = overlay as? CustomMapOverlay else { return }
        
        let point1 = MKMapPoint(overlay.coordinate1)
        let point2 = MKMapPoint(overlay.coordinate2)
        
        let rect = MKMapRect(
            origin: MKMapPoint(
                x: min(point1.x, point2.x),
                y: min(point1.y, point2.y)
            ),
            size: MKMapSize(
                width: abs(point1.x - point2.x),
                height: abs(point1.y - point2.y)
            )
        )
        
        let contextRect = self.rect(for: rect)
        
        context.setFillColor(UIColor.red.withAlphaComponent(0.5).cgColor)
        context.fill(contextRect)
    }
}
