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

// Image Picker for Profile Image
struct ImagePicker: UIViewControllerRepresentable {
    @Binding var image: UIImage
    var saveImage: (UIImage) -> Void

    class Coordinator: NSObject, UINavigationControllerDelegate, UIImagePickerControllerDelegate {
        var parent: ImagePicker

        init(parent: ImagePicker) {
            self.parent = parent
        }

        func imagePickerController(_ picker: UIImagePickerController, didFinishPickingMediaWithInfo info: [UIImagePickerController.InfoKey : Any]) {
            if let uiImage = info[.originalImage] as? UIImage {
                parent.image = uiImage
                parent.saveImage(uiImage)
            }

            picker.dismiss(animated: true)
        }
    }

    func makeCoordinator() -> Coordinator {
        Coordinator(parent: self)
    }

    func makeUIViewController(context: Context) -> UIImagePickerController {
        let picker = UIImagePickerController()
        picker.delegate = context.coordinator
        return picker
    }

    func updateUIViewController(_ uiViewController: UIImagePickerController, context: Context) {}
}

struct UserProfileView_Previews: PreviewProvider {
    static var previews: some View {
        UserProfileView()
    }
}
