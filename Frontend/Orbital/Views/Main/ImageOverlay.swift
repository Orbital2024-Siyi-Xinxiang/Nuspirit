import SwiftUI
import UIKit
import MapKit

class ImageOverlay: NSObject, MKOverlay {
    var coordinate: CLLocationCoordinate2D
    var boundingMapRect: MKMapRect
    var image: UIImage
    
    init(coordinate: CLLocationCoordinate2D, boundingMapRect: MKMapRect, image: UIImage) {
        self.coordinate = coordinate
        self.boundingMapRect = boundingMapRect
        self.image = image
    }
}

class ImageOverlayRenderer: MKOverlayRenderer {
    var overlayImage: UIImage
    
    init(overlay: MKOverlay, overlayImage: UIImage) {
        self.overlayImage = overlayImage
        super.init(overlay: overlay)
    }
    
    override func draw(_ mapRect: MKMapRect, zoomScale: MKZoomScale, in context: CGContext) {
        guard let imageOverlay = overlay as? ImageOverlay else { return }
        
        let rect = self.rect(for: imageOverlay.boundingMapRect)
        context.draw(imageOverlay.image.cgImage!, in: rect)
    }
}
