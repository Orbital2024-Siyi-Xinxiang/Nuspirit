//
//  Asset.swift
//  Orbital
//
//  Created by Xu Siyi on 18/5/24.
//

import Foundation

struct Asset: Identifiable, Codable {
    var id: Int
    var name: String
    var price: Double
    var icon: String
}
