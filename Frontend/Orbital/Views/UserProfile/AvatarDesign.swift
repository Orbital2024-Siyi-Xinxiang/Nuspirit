import SwiftUI

struct AvatarDesign: View {
    @StateObject private var avatarService = AvatarService()
    @State private var selectedHairImage: UIImage?
    @State private var selectedPantsImage: UIImage?
    @State private var avatarImageURL: String?
    @State private var avatars: [Avatar] = []
    
    var body: some View {
        VStack {
            Text("Customize Your Avatar")
                .font(.title)
                .padding()
            
            // Example UI for displaying avatars fetched from Firestore
            List(avatars) { avatar in
                VStack(alignment: .leading) {
                    Text("Avatar ID: \(avatar.id)")
                    if let hairImageURL = URL(string: avatar.hairImageURL) {
                        AsyncImage(url: hairImageURL) {phase in
                            switch phase {
                            case .empty:
                                ProgressView()
                            case .success(let image):
                                image
                                    .resizable()
                                    .scaledToFit()
                                    .frame(width: 50, height: 50)
                            case .failure:
                                Image(systemName: "person.fill")
                                    .foregroundColor(.gray)
                                    .frame(width: 50, height: 50)
                            @unknown default:
                                Image(systemName: "person.fill")
                                    .foregroundColor(.gray)
                                    .frame(width: 50, height: 50)
                            }
                        }
                    }
                    
//                    if let pantsImageURL = URL(string:avatar.pantsImageURL) {
                    if let hairImageURL = URL(string: avatar.hairImageURL) {
                        AsyncImage(url: hairImageURL) { phase in
                            switch phase {
                            case .empty:
                                ProgressView()
                            case .success(let image):
                                image
                                    .resizable()
                                    .scaledToFit()
                                    .frame(width: 50, height: 50)
                            case .failure:
                                Image(systemName: "person.fill")
                                    .foregroundColor(.gray)
                                    .frame(width: 50, height: 50)
                            @unknown default:
                                Image(systemName: "person.fill")
                                    .foregroundColor(.gray)
                                    .frame(width: 50, height: 50)
                            }
                        }
                    }
                }
            }
            .onAppear {
                // Fetch avatars from Firestore
                avatarService.fetchAvatars { fetchedAvatars in
                    self.avatars = fetchedAvatars
                }
            }
            
            Button(action: {
                // Upload selected avatar parts to Firebase Storage
                if let hairData = selectedHairImage?.jpegData(compressionQuality: 0.5) {
                    avatarService.uploadImage(imageData: hairData, imageName: "hair.jpg") { url in
                        if let url = url {
                            self.avatarImageURL = url
                        }
                    }
                }
                // Repeat for other parts like pants, etc.
            }) {
                Text("Save Avatar")
                    .padding()
                    .background(Color.blue)
                    .foregroundColor(.white)
                    .cornerRadius(10)
            }
            .padding()
            
            // Example: Select different parts of the avatar
            ImagePicker(sourceType: .photoLibrary) { image in
                // Handle selected hair image
                self.selectedHairImage = image
            }
            ImagePicker(sourceType: .photoLibrary) { image in
                // Handle selected pants image
                self.selectedPantsImage = image
            }
        }
    }
}
