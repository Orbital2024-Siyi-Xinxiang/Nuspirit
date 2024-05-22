import SwiftUI
import Firebase
import FirebaseAuthUI
import FirebaseGoogleAuthUI
import FirebaseOAuthUI
import FirebaseEmailAuthUI
//import FirebaseAppleAuthUI
import FirebasePhoneAuthUI
import FirebaseFacebookAuthUI
import FirebaseAnonymousAuthUI
//import FirebaseGitHubAuthUI

struct LandingView: View {
    var body: some View {
//        VStack {
        Text("Welcome to Our App")
            .font(.largeTitle)
            .padding()
        
        Button(action: {
            showSignInView()
        }) {
            Text("Get Started")
                .padding()
                .background(Color.blue)
                .foregroundColor(.white)
                .cornerRadius(8)
        }
        .padding()
            
//            Button(action: {
//                showSignUpView()
//            }) {
//                Text("Sign Up")
//                    .padding()
//                    .background(Color.green)
//                    .foregroundColor(.white)
//                    .cornerRadius(8)
//            }
//            .padding()
//        }
    }
    
    private func showSignInView() {
        let authUI = FUIAuth.defaultAuthUI()
        authUI?.delegate = UIApplication.shared.delegate as? FUIAuthDelegate
        
        // Set the sign-in providers
        let providers: [FUIAuthProvider] = [
            FUIGoogleAuth(),
            FUIOAuth.appleAuthProvider(),
            FUIEmailAuth()
        ]
        authUI?.providers = providers
        
        let authViewController = authUI!.authViewController()
        if let rootViewController = UIApplication.shared.windows.first?.rootViewController {
            rootViewController.present(authViewController, animated: true, completion: nil)
        }
    }
    
//    private func showSignUpView() {
//        let authUI = FUIAuth.defaultAuthUI()
//        authUI?.delegate = UIApplication.shared.delegate as? FUIAuthDelegate
//        
//        // Set the sign-up providers
//        let providers: [FUIAuthProvider] = [
//            FUIGoogleAuth(),
//            FUIOAuth.appleAuthProvider(),
//            FUIEmailAuth()
//        ]
//        authUI?.providers = providers
//        
//        let authViewController = authUI!.authViewController()
//        if let rootViewController = UIApplication.shared.windows.first?.rootViewController {
//            rootViewController.present(authViewController, animated: true, completion: nil)
//        }
//    }
}

struct LandingView_Previews: PreviewProvider {
    static var previews: some View {
        LandingView()
    }
}
