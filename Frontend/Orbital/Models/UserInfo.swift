//
//  UserInfo.swift
//  Orbital
//
//  Created by Xu Siyi on 6/6/24.
//

import Foundation
import SwiftUI

struct UserInfo: Identifiable {
    var id = UUID()
    var data: String
    var title: String
    var headline: String
    var image: String
    var gradientColors: [Color]
}

