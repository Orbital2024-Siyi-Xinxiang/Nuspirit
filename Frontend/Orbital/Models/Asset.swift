//
//  Asset.swift
//  Orbital
//
//  Created by Xu Siyi on 18/5/24.
//

import Foundation


struct Asset: Identifiable, Equatable {
    var id: Int
    var cat: String
    var name: String
    var price: Double
    var icon: String

    static func ==(lhs: Asset, rhs: Asset) -> Bool {
        return lhs.id == rhs.id
    }
}
