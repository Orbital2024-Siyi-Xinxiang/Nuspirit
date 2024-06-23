import FirebaseStorage
import UIKit
import SwiftUI

class FirebaseStorageService {
    private let storage = Storage.storage()

    func downloadImage(name: String, completion: @escaping (UIImage?) -> Void) {
        let pathReference = storage.reference(withPath: "images/\(name).png")

        // Check local cache first
        if let localImage = loadImageFromLocalStorage(name: name) {
            completion(localImage)
            return
        }

        // Download from Firebase Storage
        pathReference.getData(maxSize: 5 * 1024 * 1024) { data, error in
            if let error = error {
                print("Error downloading image: \(error)")
                completion(nil)
                return
            }

            if let data = data, let image = UIImage(data: data) {
                completion(image)
            } else {
                completion(nil)
            }
        }
    }

    private func loadImageFromLocalStorage(name: String) -> UIImage? {
        let filename = getDocumentsDirectory().appendingPathComponent("\(name).png")
        return UIImage(contentsOfFile: filename.path)
    }

    private func getDocumentsDirectory() -> URL {
        return FileManager.default.urls(for: .documentDirectory, in: .userDomainMask)[0]
    }
}
