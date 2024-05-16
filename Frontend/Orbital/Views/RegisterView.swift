import SwiftUI

struct RegisterView: View {
    @State private var username = ""
    @State private var password = ""
    @State private var email = ""
    @State private var showingPassword = false
    @State private var message = ""
    @State private var isSuccess = false

    var body: some View {
        VStack(spacing: 10) {  // Reduced default spacing between elements
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
            .padding(.vertical, 5)  // Reduced padding for a closer appearance

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
            .background(Color.green)  // Style the pbutton with a blue background
            .foregroundColor(.white)
            .cornerRadius(8)
            .padding(.top, 30)  // Increased padding to separate from other fields

            Text(message)
                .foregroundColor(isSuccess ? .green : .red)
                .padding()
        }
    }
}

// Preview provider for SwiftUI canvas
struct RegisterView_Previews: PreviewProvider {
    static var previews: some View {
        RegisterView()
    }
}

