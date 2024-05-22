//
//  OrbitalApp.swift
//  Orbital
//
//  Created by Wulala's Macbook on 12/5/24.
//

import SwiftUI
import FirebaseCore
import Firebase
import FirebaseAuth

@main
struct OrbitalApp: App {
    
    let persistenceController = PersistenceController.shared

    @UIApplicationDelegateAdaptor(AppDelegate.self) var appDelegate
    var body: some Scene {
        WindowGroup {
            ContentView().previewInterfaceOrientation(.landscapeLeft) // preview landscape left
                .environment(\.managedObjectContext, persistenceController.container.viewContext)
    
        }
    }
}
