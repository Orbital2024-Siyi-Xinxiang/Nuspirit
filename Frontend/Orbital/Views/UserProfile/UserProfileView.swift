import SwiftUI
import Firebase
import FirebaseFirestore
import FirebaseStorage

struct UserProfileView: View {
    @State private var userProfile: UserProfile?
    @State private var isShowingImagePicker = false
    @State private var isEditing = false
    @State private var showFullProfileImage = false
    @State private var imageUrl: URL?

    var body: some View {
        NavigationView {
            ScrollView {
                if let userProfile = userProfile {
                    VStack(alignment: .center) {
                        ProfileImageView(imageUrl: $imageUrl, showFullProfileImage: $showFullProfileImage, isShowingImagePicker: $isShowingImagePicker)
                        UserInfoView(userProfile: userProfile)
                        NavigationLinksView()
                    }
                    .padding()
                    .navigationBarTitle("User Profile", displayMode: .inline)
                    .navigationBarItems(trailing: Button(action: {
                        isEditing = true
                    }) {
                        Text("Edit")
                    })
                    .sheet(isPresented: $isEditing) {
                        EditUserProfileWrapper(userProfile: $userProfile, saveChanges: saveUserProfile)
                    }
                } else {
                    ProgressView()
                        .onAppear(perform: fetchUserProfile)
                }
            }
        }
    }

    func fetchUserProfile() {
        let db = Firestore.firestore()
        let userID = Auth.auth().currentUser?.uid ?? "defaultUserID"
        db.collection("users_profiles").document(userID).getDocument { (document, error) in
            if let document = document, document.exists {
                if let data = document.data() {
                    let displayName = data["displayName"] as? String ?? ""
                    let faculty = data["faculty"] as? String ?? ""
                    let level = data["level"] as? String ?? ""
                    let major = data["major"] as? String ?? ""
                    let nickname = data["nickname"] as? String ?? ""
                    let status = data["status"] as? String ?? ""
                    let profileImageURL = data["profileImageURL"] as? String ?? ""

                    self.userProfile = UserProfile(
                        displayName: displayName,
                        profileImage: UIImage(systemName: "person.crop.circle.fill") ?? UIImage(),
                        faculty: faculty,
                        level: level,
                        major: major,
                        nickname: nickname,
                        status: status
                    )
                    self.imageUrl = URL(string: profileImageURL)
                }
            } else {
                print("Document does not exist")
            }
        }
    }

    func saveUserProfile(userProfile: UserProfile) {
        let db = Firestore.firestore()
        let userID = Auth.auth().currentUser?.uid ?? "defaultUserID"
        let data: [String: Any] = [
            "displayName": userProfile.displayName,
            "faculty": userProfile.faculty,
            "level": userProfile.level,
            "major": userProfile.major,
            "nickname": userProfile.nickname,
            "status": userProfile.status
        ]

        db.collection("users_profiles").document(userID).setData(data) { error in
            if let error = error {
                print("Error writing document: \(error)")
            } else {
                print("Document successfully written!")
            }
        }
    }

    func uploadProfileImage(image: UIImage) {
        let storageRef = Storage.storage().reference()
        let userID = Auth.auth().currentUser?.uid ?? "defaultUserID"
        let imageRef = storageRef.child("profile_images/\(userID).jpg")

        guard let imageData = image.jpegData(compressionQuality: 0.75) else { return }

        imageRef.putData(imageData, metadata: nil) { (metadata, error) in
            if let error = error {
                print("Error uploading image: \(error)")
                return
            }

            imageRef.downloadURL { (url, error) in
                if let error = error {
                    print("Error getting download URL: \(error)")
                    return
                }

                guard let downloadURL = url else { return }
                let db = Firestore.firestore()
                db.collection("users_profiles").document(userID).updateData(["profileImageURL": downloadURL.absoluteString]) { error in
                    if let error = error {
                        print("Error updating profile image URL: \(error)")
                    } else {
                        self.imageUrl = downloadURL
                        print("Profile image URL successfully updated")
                    }
                }
            }
        }
    }
}

struct EditUserProfileWrapper: View {
    @Binding var userProfile: UserProfile?
    var saveChanges: (UserProfile) -> Void

    var body: some View {
        if let userProfile = userProfile {
            EditUserProfileView(userProfile: Binding(
                get: { userProfile },
                set: { newValue in
                    self.userProfile = newValue
                }
            ), saveChanges: saveChanges)
        } else {
            Text("No user profile found")
        }
    }
}


struct ProfileImageView: View {
    @Binding var imageUrl: URL?
    @Binding var showFullProfileImage: Bool
    @Binding var isShowingImagePicker: Bool

    var body: some View {
        if let imageUrl = imageUrl {
            AsyncImage(url: imageUrl) { phase in
                switch phase {
                case .empty:
                    ProgressView()
                case .success(let image):
                    image.resizable()
                        .frame(width: 100, height: 100)
                        .clipShape(Circle())
                        .overlay(Circle().stroke(Color.white, lineWidth: 4))
                        .shadow(radius: 10)
                        .onTapGesture {
                            showFullProfileImage = true
                        }
                        .sheet(isPresented: $showFullProfileImage) {
                            VStack {
                                AsyncImage(url: imageUrl) { phase in
                                    switch phase {
                                    case .empty:
                                        ProgressView()
                                    case .success(let image):
                                        image.resizable()
                                            .aspectRatio(contentMode: .fit)
                                            .onTapGesture {
                                                showFullProfileImage = false
                                            }
                                            .padding()
                                    case .failure:
                                        Image(systemName: "person.crop.circle.fill.badge.exclamationmark")
                                    @unknown default:
                                        EmptyView()
                                    }
                                }
                                Button("Upload New Image") {
                                    isShowingImagePicker = true
                                }
                                .padding()
                            }
                        }
                case .failure:
                    Image(systemName: "person.crop.circle.fill.badge.exclamationmark")
                @unknown default:
                    EmptyView()
                }
            }
        } else {
            ProgressView()
        }
    }
}

struct UserInfoView: View {
    var userProfile: UserProfile

    var body: some View {
        Group {
            Text(userProfile.displayName)
                .font(.title)
                .fontWeight(.bold)
                .padding(.top, 8)

            Text("Faculty: \(userProfile.faculty)")
            Text("Level: \(userProfile.level)")
            Text("Major: \(userProfile.major)")
            Text("Nickname: \(userProfile.nickname)")
            Text("Status: \(userProfile.status)")
        }
        .padding(.top, 4)
    }
}

struct NavigationLinksView: View {
    var body: some View {
        VStack(alignment: .leading) {
            NavigationLink(destination: FurnitureMarketView()) {
                Text("Furniture Market")
                    .padding()
                    .frame(maxWidth: .infinity)
                    .background(Color.blue)
                    .foregroundColor(.white)
                    .cornerRadius(10)
                    .padding(.bottom, 4)
            }
            NavigationLink(destination: MyAssetsView()) {
                Text("My Assets")
                    .padding()
                    .frame(maxWidth: .infinity)
                    .background(Color.blue)
                    .foregroundColor(.white)
                    .cornerRadius(10)
                    .padding(.bottom, 4)
            }
            NavigationLink(destination: MyIslandView()) {
                Text("My Island")
                    .padding()
                    .frame(maxWidth: .infinity)
                    .background(Color.blue)
                    .foregroundColor(.white)
                    .cornerRadius(10)
                    .padding(.bottom, 4)
            }
            NavigationLink(destination: SystemSettingsView()) {
                Text("System Settings")
                    .padding()
                    .frame(maxWidth: .infinity)
                    .background(Color.blue)
                    .foregroundColor(.white)
                    .cornerRadius(10)
                    .padding(.bottom, 4)
            }
            NavigationLink(destination: ContactsView()) {
                Text("User Contacts")
                    .padding()
                    .frame(maxWidth: .infinity)
                    .background(Color.blue)
                    .foregroundColor(.white)
                    .cornerRadius(10)
            }
        }
        .padding(.top, 16)
    }
}
