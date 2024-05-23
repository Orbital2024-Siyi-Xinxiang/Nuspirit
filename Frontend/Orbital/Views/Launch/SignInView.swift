import SwiftUI
import FirebaseAuth
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



struct SignInView: View {
    @State private var email: String = ""
    @State private var password: String = ""
    @State private var showingPassword: Bool = false
    @State private var errorMessage: String?
    @State private var isSignedIn: Bool = false
    
    var body: some View {
        VStack(spacing: 20) {
            Text("Welcome to NUSspirit")
                .font(.largeTitle)
                .bold()
            
            TextField("Email", text: $email)
                .padding()
                .background(Color(.secondarySystemBackground))
                .cornerRadius(10)
            
            HStack {
                if showingPassword {
                    TextField("Password", text: $password)
                } else {
                    SecureField("Password", text: $password)
                }
                Button(action: {
                    showingPassword.toggle()
                }) {
                    Image(systemName: showingPassword ? "eye.slash" : "eye")
                        .foregroundColor(.gray)
                }
            }
            .padding()
            .background(Color(.secondarySystemBackground))
            .cornerRadius(10)
            
            if let errorMessage = errorMessage {
                Text(errorMessage)
                    .foregroundColor(.red)
            }
            
            Button(action: {
                signIn()
            }) {
                Text("Sign In")
                    .frame(maxWidth: .infinity)
                    .padding()
                    .background(Color.blue)
                    .foregroundColor(.white)
                    .cornerRadius(10)
            }
            .padding(.horizontal)
            
            Button(action: {
                // Navigate to forgot password view
            }) {
                Text("Forgot Password?")
                    .foregroundColor(.blue)
            }
            
            Spacer()
        }
        .padding()
        .fullScreenCover(isPresented: $isSignedIn) {
            MainMapView(showSettingsOverlay: $isSignedIn)
        }
    }
    
    private func signIn() {
        Auth.auth().signIn(withEmail: email, password: password) { authResult, error in
            if let error = error {
                errorMessage = error.localizedDescription
            } else {
                isSignedIn = true
                print("User Signed In successfully")
                if let user = Auth.auth().currentUser {
                    // The user's ID, unique to the Firebase project.
                    // Do NOT use this value to authenticate with your backend server,
                    // if you have one. Use getTokenWithCompletion:completion: instead.
                    let uid = user.uid
                    let email = user.email
                    let photoURL = user.photoURL
                    var multiFactorString = "MultiFactor: "
                    let displayName = user.displayName
                    for info in user.multiFactor.enrolledFactors {
                        multiFactorString += info.displayName ?? "[DispayName]"
                        multiFactorString += " "
                        }
//                        navigateToMainMapView()
                    
                    // store user in firestore
                    let db = Firestore.firestore()
                    db.collection("users_credentials").document(uid).setData([
                        "display_name": displayName ?? "",
                        "email": email ?? "",
                        "password": password
                    ]) { err in
                        if let err = err {
                            print("Error adding user: \(err)")
                        } else {
                            print("User added successfully")
                        }
                        
                    }
                }
            }
        }
    }
}

struct SignInView_Previews: PreviewProvider {
    static var previews: some View {
        SignInView()
    }
}
