import UIKit
import FirebaseEmailAuthUI
import FirebaseGoogleAuthUI
import FirebaseAuthUI
import FirebaseAuth
import FirebaseAuthUI
import FirebaseFacebookAuthUI
import FirebaseCore
import FirebaseAuth
import GoogleSignIn
import  FirebasePhoneAuthUI
import FirebaseOAuthUI
import FirebasePhoneAuthUI


class SignInViewController: UIViewController, FUIAuthDelegate {
    override func viewDidLoad() {
        super.viewDidLoad()
        let authUI = FUIAuth.defaultAuthUI()
        authUI?.delegate = self

        let providers: [FUIAuthProvider] = [
            FUIGoogleAuth(),
            FUIOAuth.appleAuthProvider(),
            FUIEmailAuth()
        ]
        authUI?.providers = providers

        let authViewController = authUI!.authViewController()
        self.present(authViewController, animated: true, completion: nil)
    }

    func authUI(_ authUI: FUIAuth, didSignInWith user: User?, error: Error?) {
        if let user = user {
            // User is signed in, perform any necessary actions
            print("User signed in: \(user.uid)")
            // Here you can store user info in Firestore
        } else if let error = error {
            // Handle error
            print("Error signing in: \(error.localizedDescription)")
        }
    }
}
