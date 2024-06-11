import SwiftUI
import FirebaseCore
import FirebaseAuth

struct FirebaseAuthService {
    
    // get authenticated user credentials
    
    func getCurrentUid() -> String {
        // Get the currently signed-in user
        if let user = Auth.auth().currentUser {
            // The user is signed in, retrieve the UID
            let uid = user.uid
            return uid
        } else {
            return ""
        }
    }
    
}
