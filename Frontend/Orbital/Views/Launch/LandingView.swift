import SwiftUI
import Firebase

struct LandingView: View {
    @State private var showSignUp = false
    
    var body: some View {
        NavigationView {
            ZStack {
                // Background image
                Image("backgroundImage")
                    .resizable()
                    .scaledToFill()
                    .edgesIgnoringSafeArea(.all)
                
                VStack(spacing: 20) {
                    Spacer()
                    Image(systemName: "house")
                        .resizable()
                        .frame(width: 100, height: 100)
                        .foregroundColor(.white)
                        .shadow(radius: 10)
                    
                    Text("Welcome to NUSspirit")
                        .font(.largeTitle)
                        .fontWeight(.bold)
                        .foregroundColor(.white)
                        .shadow(radius: 5)
                    
                    Spacer()
                    
                    NavigationLink(destination: SignInView()) {
                        Text("Sign In")
                            .frame(maxWidth: .infinity)
                            .padding()
                            .background(
                                LinearGradient(gradient: Gradient(colors: [Color(red: 0.719, green: 0.383, blue: 0.142), Color(red: 0.919, green: 0.583, blue: 0.342)]), startPoint: .leading, endPoint: .trailing)
                            )
                            .foregroundColor(.white)
                            .cornerRadius(10)
                            .shadow(radius: 5)
                    }
                    .padding(.horizontal)
                    
                    Button(action: {
                        showSignUp = true
                    }) {
                        Text("Sign Up")
                            .frame(maxWidth: .infinity)
                            .padding()
                            .background(
                                LinearGradient(gradient: Gradient(colors: [Color(red: 0.583, green: 0.375, blue: 0.215), Color(red: 0.783, green: 0.575, blue: 0.415)]), startPoint: .leading, endPoint: .trailing)
                            )
                            .foregroundColor(.white)
                            .cornerRadius(10)
                            .shadow(radius: 5)
                    }
                    .padding(.horizontal)
                    
                    Spacer()
                }
                .sheet(isPresented: $showSignUp) {
                    SignUpViewControllerWrapper(isPresented: $showSignUp)
                }
                .padding()
            }
        }
    }
}

struct LandingView_Previews: PreviewProvider {
    static var previews: some View {
        LandingView()
    }
}
