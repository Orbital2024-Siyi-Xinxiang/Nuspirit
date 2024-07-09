//
//  UserAnnotaion.swift
//  Orbital
//
//  Created by Xu Siyi on 11/6/24.
//
import SwiftUI
import Foundation
import MapKit

class UserAnnotation: NSObject, MKAnnotation {
    var coordinate: CLLocationCoordinate2D
    var title: String?
    var subtitle: String?
    var userID: String
    var profileImage: UIImage?
    var major: String?
    
    init(coordinate: CLLocationCoordinate2D, title: String, subtitle: String, userID: String, profileImage: UIImage?, major: String?) {
        self.coordinate = coordinate
        self.title = title
        self.subtitle = subtitle
        self.userID = userID
        self.profileImage = profileImage
        self.major = major
    }
}
// preview
struct UserAnnotation_Previews: PreviewProvider {
    static var previews: some View {
        Text("Hello, World!")
    }
}
