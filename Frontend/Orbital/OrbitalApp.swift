//
//  OrbitalApp.swift
//  Orbital
//
//  Created by Wulala's Macbook on 12/5/24.
//

import SwiftUI
// import FirebaseCore
// import Firebase
// import FirebaseAuth

// class AppDelegate: NSObject, UIApplicationDelegate {
//   func application(_ application: UIApplication,
//                    didFinishLaunchingWithOptions launchOptions: [UIApplication.LaunchOptionsKey : Any]? = nil) -> Bool {
//     FirebaseApp.configure()

//     return true
//   }
// }

@main
struct OrbitalApp: App {
    let persistenceController = PersistenceController.shared

    // @UIApplicationDelegateAdaptor(AppDelegate.self) var delegate
    var body: some Scene {
        WindowGroup {
            HomePageView() //
                .environment(\.managedObjectContext, persistenceController.container.viewContext)
    
        }
    }
}
