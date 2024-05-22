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
import FirebaseAuthUI
import AuthenticationServices
import GoogleSignIn

@main
struct OrbitalApp: App {
    
    let persistenceController = PersistenceController.shared
    

    @UIApplicationDelegateAdaptor(AppDelegate.self) var appDelegate
    var body: some Scene {
        WindowGroup {
            ZStack {
                LandingView().previewInterfaceOrientation(.landscapeLeft) // preview landscape left
                .environment(\.managedObjectContext, persistenceController.container.viewContext)
//                .onAppear {
//                    if let user = Auth.auth().currentUser {
//                        navigateToMainMapView()
//                    }
//                }
//                
//                // add settings service globally
                SettingsOverlay()
            }
//            ContentView().previewInterfaceOrientation(.landscapeLeft) // preview landscape left
//                .environment(\.managedObjectContext, persistenceController.container.viewContext)
    
        }
    }
    
    private func navigateToMainMapView() {
        if let window = UIApplication.shared.windows.first {
            window.rootViewController = UIHostingController(rootView: MainMapView())
            window.makeKeyAndVisible()
//            SettingsOverlay()
        }
    }
}
