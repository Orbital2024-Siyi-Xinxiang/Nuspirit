import UIKit
import FirebaseEmailAuthUI
import Foundation
import FirebaseCore
import Firebase
import FirebaseAuth
import FirebaseAuthUI
import UserNotifications
import FirebaseFacebookAuthUI
import FirebaseGoogleAuthUI
import FirebaseOAuthUI
import FirebasePhoneAuthUI
import UIKit
import SwiftUI
import GoogleSignIn

class SignUpViewController: UIViewController, FUIAuthDelegate {
//    var actionCodeSettings = ActionCodeSettings()
//    actionCodeSettings.url = URL(string: "https://example.appspot.com")
//    actionCodeSettings.handleCodeInApp = true
//    actionCodeSettings.setAndroidPackageName("com.firebase.example", installIfNotAvailable: false, minimumVersion: "12")
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        let authUI = FUIAuth.defaultAuthUI()
        authUI?.delegate = self
        let googleAuthProvider = FUIGoogleAuth(authUI: authUI!)
        
        let providers: [FUIAuthProvider] = [
            googleAuthProvider,
            FUIOAuth.appleAuthProvider(),
            FUIEmailAuth(),
//            FUIEmailAuth(authAuthUI: FUIAuth.defaultAuthUI()!,
//                                        signInMethod: FIREmailLinkAuthSignInMethod,
//                                        forceSameDevice: false,
//                                        allowNewEmailAccounts: true,
//                                        actionCodeSetting: actionCodeSettings)
        ]
        authUI?.providers = providers
        
        let authViewController = authUI!.authViewController()
        if let rootViewController = UIApplication.shared.windows.first?.rootViewController {
            rootViewController.present(authViewController, animated: true, completion: nil)
        }
    }
    
    func authUI(_ authUI: FUIAuth, didSignInWith user: User?, error: Error?)  {
        if let user = user {
            FirestoreService.shared.addUserCredential(uid: user.uid, email: user.email ?? "", userid: user.uid, password: "", display_name: user.displayName ?? "")
            print("User signed in")
            
            DispatchQueue.main.async {
                // Assuming you have a method to navigate to the main view
                
                self.navigateToMainAppView()
            }
        } else {
            if let error = error {
                print("Error signing in: \(error.localizedDescription)")
            }
        }
    }
    
    func navigateToMainAppView() {
        let mainMapView = OrientationViewControllerWrapper(supportedOrientation: .landscape, content: AnyView(MainMapView(showSettingsOverlay: Binding.constant(true))))
        let hostingController = UIHostingController(rootView: mainMapView)
        if let window = UIApplication.shared.windows.first {
            window.rootViewController = hostingController
            window.makeKeyAndVisible()
        }
    }
}


