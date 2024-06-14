import SwiftUI

struct LandingView: View {
    @State private var showSignUp = false
    
    var body: some View {
        NavigationView {
            VStack(spacing: 20) {
                Spacer()
                Image(systemName: "house")
                    .resizable()
                    .frame(width: 100, height: 100)
                Text("Welcome to NUSspirit")
                    .font(.largeTitle)
                    .bold()
                Spacer()
                NavigationLink(destination: SignInView()) {
                    Text("Sign In")
                        .frame(maxWidth: .infinity)
                        .padding()
                        .background(Color.blue)
                        .foregroundColor(.white)
                        .cornerRadius(10)
                }
                .padding(.horizontal)

                Button(action: {
                    showSignUp = true
                }) {
                    Text("Sign Up")
                        .frame(maxWidth: .infinity)
                        .padding()
                        .background(Color.green)
                        .foregroundColor(.white)
                        .cornerRadius(10)
                }
                .padding(.horizontal)
                Spacer()
            }
            .sheet(isPresented: $showSignUp) {
                SignUpViewControllerWrapper()
            }
        }
    }
}

struct LandingView_Previews: PreviewProvider {
    static var previews: some View {
        LandingView()
    }
}
