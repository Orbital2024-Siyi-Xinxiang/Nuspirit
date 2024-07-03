import Firebase
import FirebaseFirestore
import FirebaseStorage

class AvatarService: ObservableObject {
    let db = Firestore.firestore()
    let storage = Storage.storage()

    func fetchAvatars(completion: @escaping ([Avatar]) -> Void) {
        db.collection("avatars").getDocuments { querySnapshot, error in
            if let error = error {
                print("Error fetching avatars: \(error.localizedDescription)")
                completion([])
                return
            }
            
            var avatars: [Avatar] = []
            for document in querySnapshot!.documents {
                do {
                    // Attempt to decode Avatar from Firestore document
                    if let avatar = try document.data(as: Avatar?.self) {
                        avatars.append(avatar)
                    } else {
                        print("Document \(document.documentID) does not contain valid Avatar data")
                    }
                } catch {
                    print("Error decoding avatar: \(error.localizedDescription)")
                }
            }
            
            completion(avatars)
        }
    }



    // Function to upload avatar image to Firebase Storage
    func uploadImage(imageData: Data, imageName: String, completion: @escaping (String?) -> Void) {
        let storageRef = storage.reference().child("avatars/\(imageName)")
        storageRef.putData(imageData, metadata: nil) { metadata, error in
            if let error = error {
                print("Error uploading avatar image: \(error.localizedDescription)")
                completion(nil)
            } else {
                storageRef.downloadURL { url, error in
                    if let error = error {
                        print("Error retrieving avatar image URL: \(error.localizedDescription)")
                        completion(nil)
                    } else {
                        completion(url?.absoluteString)
                    }
                }
            }
        }
    }
}
