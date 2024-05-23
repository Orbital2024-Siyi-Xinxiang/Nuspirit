import SwiftUI
import FirebaseCore
import Firebase
import FirebaseAuth
import FirebaseAuthUI
import AuthenticationServices
import GoogleSignIn
import FirebaseFirestore
import FirebaseStorage
import FirebaseMessaging
import FirebaseGoogleAuthUI

@main
struct OrbitalApp: App {
    @State private var showSettingsOverlay = false

    let persistenceController = PersistenceController.shared

    @UIApplicationDelegateAdaptor(AppDelegate.self) var appDelegate

    var body: some Scene {
        WindowGroup {

                    LandingView()
                        .environment(\.managedObjectContext, persistenceController.container.viewContext)
                }
            
        
    }
}
