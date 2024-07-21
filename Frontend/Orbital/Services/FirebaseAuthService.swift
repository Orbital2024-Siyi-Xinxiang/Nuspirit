import SwiftUI
import FirebaseCore
import FirebaseAuth

struct FirebaseAuthService {
    
    // get authenticated user credentials
    
    public func getCurrentUid() -> String {
        // Get the currently signed-in user
        if let user = Auth.auth().currentUser {
            // The user is signed in, retrieve the UID
            let uid = user.uid
            return uid
        } else {
            return ""
        }
    }

    public func getCurrentEmail() -> String {
        // Get the currently signed-in user
        if let user = Auth.auth().currentUser {
            // The user is signed in, retrieve the email
            let email = user.email
            return email ?? ""
        } else {
            return ""
        }
    }

    public func getCurrentDisplayName() -> String {
        // Get the currently signed-in user
        if let user = Auth.auth().currentUser {
            // The user is signed in, retrieve the display name
            let displayName = user.displayName
            return displayName ?? ""
        } else {
            return ""
        }
    }

    public func getCurrentPhotoURL() -> URL {
        // Get the currently signed-in user
        if let user = Auth.auth().currentUser {
            // The user is signed in, retrieve the photo URL
            let photoURL = user.photoURL
            return photoURL ?? URL(string: "")!
        } else {
            return URL(string: "")!
        }
    }

}
