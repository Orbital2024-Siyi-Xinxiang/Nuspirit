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
import FirebaseFirestore
import FirebaseStorage


@main
struct OrbitalApp: App {
    @State private var showingSettings = true
    
    let persistenceController = PersistenceController.shared
    

    @UIApplicationDelegateAdaptor(AppDelegate.self) var appDelegate
    var body: some Scene {
        WindowGroup {
            ZStack {
                if showingSettings {
                    SettingsOverlay()
                }
                
                LandingView().previewInterfaceOrientation(.landscapeLeft) // preview landscape left
                .environment(\.managedObjectContext, persistenceController.container.viewContext)
                .onAppear {
                    print("App is running")
                    if let user = Auth.auth().currentUser {
                        // The user's ID, unique to the Firebase project.
                        // Do NOT use this value to authenticate with your backend server,
                        // if you have one. Use getTokenWithCompletion:completion: instead.
                        let uid = user.uid
                        let email = user.email
                        let photoURL = user.photoURL
                        var multiFactorString = "MultiFactor: "
                        for info in user.multiFactor.enrolledFactors {
                            multiFactorString += info.displayName ?? "[DispayName]"
                            multiFactorString += " "
                            }
//                        navigateToMainMapView()
                        }
                    
                                        // Fetch all users
                    print("\n\n\nFetching all users\n\n\n")
                    let db = Firestore.firestore()
                    db.collection("users").getDocuments { (querySnapshot, error) in
                        if let error = error {
                            print("Error getting documents: \(error)")
                        } else {
                            for document in querySnapshot!.documents {
                                let data = document.data()
                                print(data)
                            }
                        }
                    }
                        
                }
                

                
                VStack {
                    HStack {
                        Spacer()
                        Button(action: {
                            showingSettings.toggle()
                        }) {
                            Image(systemName: "gearshape")
                                .foregroundColor(.blue)
                                .padding()
                        }
                    }
                    Spacer()
                }
                
            }
    
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
