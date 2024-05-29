import MapKit
import SwiftUI

<<<<<<< Updated upstream
class CustomMapOverlay: NSObject, MKOverlay {
    var coordinate: CLLocationCoordinate2D
    var boundingMapRect: MKMapRect

    init(coordinate: CLLocationCoordinate2D, boundingMapRect: MKMapRect) {
        self.coordinate = coordinate
        self.boundingMapRect = boundingMapRect
=======
class CustomMapOverlay: NSObject, MKAnnotation {
    var coordinate: CLLocationCoordinate2D {
        return coordinate1
    }
    var coordinate1: CLLocationCoordinate2D
    var coordinate2: CLLocationCoordinate2D
    var title: String?
    var levels: Int
    var capacity: Int
    var buildingID: String

    init(coordinate1: CLLocationCoordinate2D, coordinate2: CLLocationCoordinate2D, title: String, levels: Int, capacity: Int, buildingID: String) {
        self.coordinate1 = coordinate1
        self.coordinate2 = coordinate2
        self.title = title
        self.levels = levels
        self.capacity = capacity
        self.buildingID = buildingID
>>>>>>> Stashed changes
    }
}

class CustomMapOverlayRenderer: MKOverlayRenderer {
    override func draw(_ mapRect: MKMapRect, zoomScale: MKZoomScale, in context: CGContext) {
        guard let overlay = overlay as? CustomMapOverlay else { return }
        
        let rect1 = self.rect(for: MKMapPoint(overlay.coordinate1))
        let rect2 = self.rect(for: MKMapPoint(overlay.coordinate2))
        
        let rect = CGRect(x: min(rect1.origin.x, rect2.origin.x), y: min(rect1.origin.y, rect2.origin.y), width: abs(rect1.origin.x - rect2.origin.x), height: abs(rect1.origin.y - rect2.origin.y))

        context.setFillColor(UIColor.red.withAlphaComponent(0.5).cgColor)
        context.fill(rect)
    }
}
