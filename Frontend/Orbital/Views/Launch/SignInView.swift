import SwiftUI
import FirebaseAuth
import Foundation
import FirebaseCore
import Firebase
import FirebaseAuthUI
import UserNotifications
import FirebaseFacebookAuthUI
import FirebaseGoogleAuthUI
import FirebaseOAuthUI
import FirebasePhoneAuthUI
import UIKit
import FirebaseStorage
import FirebaseFirestore

struct SignInView: View {
    @State private var email: String = ""
    @State private var password: String = ""
    @State private var showingPassword: Bool = false
    @State private var errorMessage: String?
    @State private var isSignedIn: Bool = false
    @State private var showOnboarding: Bool = false
    
    var body: some View {
        VStack(spacing: 20) {
            Text("Sign in to NUSspirit")
                .font(.largeTitle)
                .bold()
                .foregroundColor(Color(red: 0.719, green: 0.383, blue: 0.136))
                
            TextField("Email", text: $email)
                .padding()
                .foregroundColor(Color(hue: 0.088, saturation: 0.198, brightness: 0.988))
                .background(Color(red: 0.973, green: 0.83, blue: 0.729, opacity: 0.688))
                .cornerRadius(10)
                 // Change text color here
                .textFieldStyle(PlainTextFieldStyle())
    
            
            HStack {
                if showingPassword {
                    TextField("Password", text: $password)
                        .font(.title)
                        .foregroundColor(Color("AccentColor")) // Change text color here
                        .textFieldStyle(PlainTextFieldStyle())
                } else {
                    SecureField("Password", text: $password)
                        .foregroundColor(Color(hue: 0.088, saturation: 0.198, brightness: 0.988))// Change text color here
                        .textFieldStyle(PlainTextFieldStyle())
                }
                Button(action: {
                    showingPassword.toggle()
                }) {
                    Image(systemName: showingPassword ? "eye.slash" : "eye")
                        .foregroundColor(Color(red: 0.408, green: 0.247, blue: 0.137))
                }
            }
            .padding()
            .background(Color(red: 0.977, green: 0.883, blue: 0.811))
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
                    .background(Color(red: 0.723, green: 0.382, blue: 0.141))
                    .foregroundColor(Color(hue: 0.088, saturation: 0.198, brightness: 0.988))
                    .cornerRadius(10)
            }
            .padding(.horizontal)
            
            Button(action: {
                // Navigate to forgot password view
            }) {
                Text("Forgot Password?")
                    .foregroundColor(Color(red: 0.722, green: 0.378, blue: 0.142))
            }
            
            Spacer()
        }
        .padding()
        .fullScreenCover(isPresented: $isSignedIn) {
            MainMapView(showSettingsOverlay: Binding.constant(true))
        }
        .fullScreenCover(isPresented: $showOnboarding) {
            OnBoardingView(isOnboardingCompleted: $showOnboarding)
        }
    }
    
    private func signIn() {
        Auth.auth().signIn(withEmail: email, password: password) { authResult, error in
            if let error = error {
                errorMessage = error.localizedDescription
            } else {
                if let user = Auth.auth().currentUser {
                    let uid = user.uid
                    checkUserExists(uid: uid)
                }
            }
        }
    }
    
    private func checkUserExists(uid: String) {
        let db = Firestore.firestore()
        let docRef = db.collection("users_profiles").document(uid)
        
        docRef.getDocument { (document, error) in
            if let document = document, document.exists {
                isSignedIn = true
            } else {
                showOnboarding = true
            }
        }
    }
}


// preview
struct SignInView_Previews: PreviewProvider {
    static var previews: some View {
        SignInView()
    }
}
