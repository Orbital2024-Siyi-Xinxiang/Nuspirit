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


class SignInViewController: UIViewController, FUIAuthDelegate {
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        let authUI = FUIAuth.defaultAuthUI()
        authUI?.delegate = self
        
        let providers: [FUIAuthProvider] = [
            FUIEmailAuth(),
            FUIGoogleAuth(),
            FUIOAuth.appleAuthProvider()
        ]
        authUI?.providers = providers
        
        let authViewController = authUI!.authViewController()
        self.present(authViewController, animated: true, completion: nil)
    }
    
    func authUI(_ authUI: FUIAuth, didSignInWith user: User?, error: Error?) {
        if let user = user {
            let db = Firestore.firestore()
            db.collection("users").document(user.uid).setData([
                "email": user.email ?? "",
                "displayName": user.displayName ?? ""
            ]) { err in
                if let err = err {
                    print("Error adding user: \(err)")
                } else {
                    print("User added successfully")
                    // Navigate to the sign-in page or show a success message
                }
            }
        }
    }
}
