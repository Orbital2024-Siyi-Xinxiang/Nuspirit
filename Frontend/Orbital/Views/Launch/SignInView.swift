import SwiftUI

struct SignInView: View {
    @State private var username = ""
    @State private var password = ""
    @State private var showingPassword = false
    @State private var message = ""
    @State private var isSuccess = false

    var body: some View {
        VStack(spacing: 10) {
            OrientationViewController(supportedOrientations: .landscape)
                .frame(width: 0, height: 0) // Hidden but functional

            TextField("Username", text: $username)
                .autocapitalization(.none)
                .textFieldStyle(RoundedBorderTextFieldStyle())
                .padding()

            if showingPassword {
                TextField("Password", text: $password)
                    .autocapitalization(.none)
                    .textFieldStyle(RoundedBorderTextFieldStyle())
                    .padding(.horizontal)
            } else {
                SecureField("Password", text: $password)
                    .textFieldStyle(RoundedBorderTextFieldStyle())
                    .padding(.horizontal)
            }

            Button("Show/Hide") {
                showingPassword.toggle()
            }
            .padding(.vertical, 5)
            
            NavigationLink(isActive: $isSuccess) {
                MainMapView()
            } label: {
                EmptyView()
            }

            Button("Sign In") {
                AuthService.shared.login(username: username, password: password) { success, message in
                    self.message = message
                    self.isSuccess = success
                }
            }
            .padding()
            .background(Color.blue)
            .foregroundColor(.white)
            .cornerRadius(8)
            .padding(.top, 30)

            Text(message)
                .foregroundColor(isSuccess ? .green : .red)
                .padding()
        }
        .padding()
    }
}


// Preview provider for SwiftUI canvas
struct SignInView_Previews: PreviewProvider {
    static var previews: some View {
        SignInView().previewInterfaceOrientation(.landscapeLeft)
    }
}
