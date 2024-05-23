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
            MainMapView()
        }
    }
    
    private func signIn() {
        Auth.auth().signIn(withEmail: email, password: password) { authResult, error in
            if let error = error {
                errorMessage = error.localizedDescription
            } else {
                isSignedIn = true
                Auth.auth().createUser(withEmail: email, password: password) { authResult, error in
                  // ...
                }
            }
        }
    }
    
    
    

    // Unhashed nonce.
    fileprivate var currentNonce: String?
}

struct SignInView_Previews: PreviewProvider {
    static var previews: some View {
        SignInView()
    }
}
