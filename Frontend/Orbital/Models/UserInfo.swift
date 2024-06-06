//
//  UserInfo.swift
//  Orbital
//
//  Created by Xu Siyi on 6/6/24.
//

import Foundation
import SwiftUI

// MARK: - FRUITS DATA MODEL

struct UserInfo: Identifiable {
  var id = UUID()
  var title: String
  var headline: String
  var image: String
  var gradientColors: [Color]
}
