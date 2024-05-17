import SwiftUI

struct SignInView: View {
    @State private var username = ""
    @State private var password = ""
    @State private var showingPassword = false  // State to toggle password visibility
    @State private var message = ""
    @State private var isSuccess = false  // Add this line to track success

    var body: some View {
        VStack {
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
                showingPassword.toggle()  // Toggle the password visibility
            }

            Button("Sign In") {
                AuthService.shared.login(username: username, password: password) { success, message in
                    self.message = message
                    self.isSuccess = success  // Update success status based on the API response
                }
            }
            .padding()
            .background(Color.green)
            .foregroundColor(.white)
            .cornerRadius(8)
            .padding(.top, 30)

            Text(message)
                .foregroundColor(isSuccess ? .green : .red)
                .padding()
        }
    }
}

// Preview provider for SwiftUI canvas
struct SignInView_Previews: PreviewProvider {
    static var previews: some View {
        SignInView().previewInterfaceOrientation(.landscapeLeft)
    }
}

