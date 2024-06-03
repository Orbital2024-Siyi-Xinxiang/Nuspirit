import SwiftUI

struct LandingView: View {


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

                NavigationLink(destination: SignUpView()) {
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
        }
    }
}
/*
 struct LandingView_Previews: PreviewProvider {
 static var previews: some View {
 LandingView(isSignedIn: .constant(false))
 }
 }
 */
