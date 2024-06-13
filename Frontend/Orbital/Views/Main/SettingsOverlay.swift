import SwiftUI
import FirebaseCore
import FirebaseAuth
import FirebaseAuthUI

struct SettingsOverlay: View {
    @Binding var showSettingsOverlay: Bool
    @State private var showSettings = false

    var body: some View {
        ZStack {
            VStack {
                Spacer()
                HStack {
                    Spacer()
                    if showSettings {
                        VStack {
                            NavigationLink(destination: UserProfileView()) {
                                Text("User Profile")
                                    .padding()
                                    .background(Color.blue)
                                    .foregroundColor(.white)
                                    .cornerRadius(10)
                            }
                            .padding(.bottom, 10)
                            
                            Button(action: {
                                showSettingsOverlay = false
                                signOut()
                            }) {
                                Text("Sign Out")
                                    .padding()
                                    .background(Color.red)
                                    .foregroundColor(.white)
                                    .cornerRadius(10)
                            }
                        }
                        .padding()
                        .background(Color.black.opacity(0.6))
                    }
                }
                .padding()
            }
            
            VStack {
                Spacer()
                HStack {
                    Spacer()
                    Button(action: {
                        showSettings.toggle()
                    }) {
                        Image(systemName: "gear")
                            .padding()
                            .background(Color.white)
                            .foregroundColor(.black)
                            .clipShape(Circle())
                    }
                    .padding()
                }
            }
        }
    }

    private func signOut() {
        do {
            try Auth.auth().signOut()
            if let window = UIApplication.shared.windows.first {
                window.rootViewController = UIHostingController(rootView: LandingView())
                window.makeKeyAndVisible()
            }
        } catch {
            print("Error signing out: \(error.localizedDescription)")
        }
    }
}

struct SettingsOverlay_Previews: PreviewProvider {
    static var previews: some View {
        SettingsOverlay(showSettingsOverlay: .constant(true))
    }
}
