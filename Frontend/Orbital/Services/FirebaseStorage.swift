//
//  FirebaseStorage.swift
//  Orbital
//
//  Created by Xu Siyi on 21/5/24.
//

import Foundation
import FirebaseFirestore

class FirestoreService {
    static let shared = FirestoreService()
    let db = Firestore.firestore()

    func addUser(uid: String, email: String, username: String) {
        db.collection("users").document(uid).setData([
            "email": email,
            "username": username,
            "createdAt": Timestamp()
        ]) { err in
            if let err = err {
                print("Error adding document: \(err)")
            } else {
                print("Document added with ID: \(uid)")
            }
        }
    }
}
