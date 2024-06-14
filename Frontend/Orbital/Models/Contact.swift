//
//  Contact.swift
//  Orbital
//
//  Created by Xu Siyi on 14/6/24.
//


import Foundation
import SwiftUI

struct Contact: Identifiable {
    let id = UUID()
    var name: String
    var email: String
    var major: String
    var year: String
    var remark: String = ""
    var profilePicture: UIImage?
}

