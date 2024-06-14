import SwiftUI
import Foundation
import Firebase

// Edit User Profile View
struct EditUserProfileView: View {
    @Binding var userProfile: UserProfile
    var saveChanges: (UserProfile) -> Void

    var body: some View {
        VStack {
            Text("Edit Profile")
                .font(.largeTitle)
                .padding()
            TextField("Display Name", text: $userProfile.displayName)
                .textFieldStyle(RoundedBorderTextFieldStyle())
                .padding()
            TextField("Faculty", text: $userProfile.faculty)
                .textFieldStyle(RoundedBorderTextFieldStyle())
                .padding()
            TextField("Level", text: $userProfile.level)
                .textFieldStyle(RoundedBorderTextFieldStyle())
                .padding()
            TextField("Major", text: $userProfile.major)
                .textFieldStyle(RoundedBorderTextFieldStyle())
                .padding()
            TextField("Nickname", text: $userProfile.nickname)
                .textFieldStyle(RoundedBorderTextFieldStyle())
                .padding()
            TextField("Status", text: $userProfile.status)
                .textFieldStyle(RoundedBorderTextFieldStyle())
                .padding()
            Button("Save") {
                saveChanges(userProfile)
            }
            .padding()
            Spacer()
        }
        .padding()
    }
}

