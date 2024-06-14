import UIKit
import Firebase
import FirebaseAuthUI
import FirebaseGoogleAuthUI
import FirebaseOAuthUI
import FirebaseEmailAuthUI
import SwiftUI

class SignUpViewController: UIViewController, FUIAuthDelegate {
    var onDismiss: (() -> Void)?

    override func viewDidLoad() {
        super.viewDidLoad()
        
        // Setup Firebase Auth UI
        let authUI = FUIAuth.defaultAuthUI()
        authUI?.delegate = self
        let googleAuthProvider = FUIGoogleAuth(authUI: authUI!)
        let providers: [FUIAuthProvider] = [
            googleAuthProvider,
            FUIOAuth.appleAuthProvider(),
            FUIEmailAuth(),
        ]
        authUI?.providers = providers
    }
    
    override func viewDidAppear(_ animated: Bool) {
        super.viewDidAppear(animated)
        
        // Present Firebase Auth UI
        let authUI = FUIAuth.defaultAuthUI()
        let authViewController = authUI!.authViewController()
        self.present(authViewController, animated: true, completion: nil)
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
                self.onDismiss?()
            }
        }
    }
    
    func navigateToMainAppView() {
        let mainMapView = OrientationViewControllerWrapper(supportedOrientation: .landscape, content: AnyView(MainMapView(showSettingsOverlay: Binding.constant(true))))
        let hostingController = UIHostingController(rootView: mainMapView)
        if let window = UIApplication.shared.windows.first {
            UIView.transition(with: window, duration: 0.5, options: .transitionCrossDissolve, animations: {
                window.rootViewController = hostingController
            }) { completed in
                window.makeKeyAndVisible()
            }
        }
        self.onDismiss?()
    }

    func navigateToOnboardingView() {
        let onboardingView = OrientationViewControllerWrapper(supportedOrientation: .portrait, content: AnyView(OnBoardingView(isOnboardingCompleted: Binding.constant(false))))
        let hostingController = UIHostingController(rootView: onboardingView)
        if let window = UIApplication.shared.windows.first {
            UIView.transition(with: window, duration: 0.5, options: .transitionCrossDissolve, animations: {
                window.rootViewController = hostingController
            }) { completed in
                window.makeKeyAndVisible()
            }
        }
        self.onDismiss?()
    }
}



struct SignUpViewControllerWrapper: UIViewControllerRepresentable {
    @Binding var isPresented: Bool
    
    func makeCoordinator() -> Coordinator {
        Coordinator(self)
    }

    func makeUIViewController(context: Context) -> SignUpViewController {
        let viewController = SignUpViewController()
        viewController.onDismiss = {
            self.isPresented = false
        }
        return viewController
    }

    func updateUIViewController(_ uiViewController: SignUpViewController, context: Context) {
        // No need to update anything
    }

    class Coordinator: NSObject, UINavigationControllerDelegate {
        var parent: SignUpViewControllerWrapper

        init(_ parent: SignUpViewControllerWrapper) {
            self.parent = parent
        }
    }
}
