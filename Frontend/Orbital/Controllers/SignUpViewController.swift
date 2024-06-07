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
import SwiftUI
import GoogleSignIn


class SignUpViewController: UIViewController, FUIAuthDelegate {
    override func viewDidLoad() {
        super.viewDidLoad()
        
        let authUI = FUIAuth.defaultAuthUI()
        authUI?.delegate = self
        let googleAuthProvider = FUIGoogleAuth(authUI: authUI!)

        let providers: [FUIAuthProvider] = [
            googleAuthProvider,
            FUIOAuth.appleAuthProvider(),
            FUIEmailAuth(),
        ]
        authUI?.providers = providers
        
        let authViewController = authUI!.authViewController()
        if let rootViewController = UIApplication.shared.windows.first?.rootViewController {
            rootViewController.present(authViewController, animated: true, completion: nil)
        }
    }
    
    func authUI(_ authUI: FUIAuth, didSignInWith user: User?, error: Error?) {
        if let user = user {
            let db = Firestore.firestore()
            let docRef = db.collection("users_profiles").document(user.uid)
            
            docRef.getDocument { (document, error) in
                if let document = document, document.exists {
                    print("User profile exists, navigating to main app view.")
                    DispatchQueue.main.async {
                        self.navigateToMainAppView()
                    }
                } else {
                    print("User profile does not exist, navigating to onboarding.")
                    DispatchQueue.main.async {
                        self.navigateToOnboardingView()
                    }
                }
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

    func navigateToOnboardingView() {
        let onboardingView = OrientationViewControllerWrapper(supportedOrientation: .landscape, content: AnyView(OnBoardingView(isOnboardingCompleted: Binding.constant(false))))
        let hostingController = UIHostingController(rootView: onboardingView)
        if let window = UIApplication.shared.windows.first {
            window.rootViewController = hostingController
            window.makeKeyAndVisible()
        }
    }
}


