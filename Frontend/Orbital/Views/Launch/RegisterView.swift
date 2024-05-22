import SwiftUI

struct RegisterView: View {
    @State private var username = ""
    @State private var password = ""
    @State private var email = ""
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

            TextField("Email", text: $email)
                .autocapitalization(.none)
                .textFieldStyle(RoundedBorderTextFieldStyle())
                .padding()

            Button("Register") {
                AuthService.shared.register(username: username, password: password, email: email) { success, message in
                    self.message = message
                    self.isSuccess = success
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
        .padding()
    }
}
