//
//  OrbitalApp.swift
//  Orbital
//
//  Created by Wulala's Macbook on 12/5/24.
//

import SwiftUI

@main
struct OrbitalApp: App {
    let persistenceController = PersistenceController.shared

    var body: some Scene {
        WindowGroup {
            ContentView()
                .environment(\.managedObjectContext, persistenceController.container.viewContext)
        }
    }
}
