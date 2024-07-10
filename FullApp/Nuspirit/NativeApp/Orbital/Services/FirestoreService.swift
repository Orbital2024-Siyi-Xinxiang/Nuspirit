//
//  FirebaseStorage.swift
//  Orbital
//
//  Created by Xu Siyi on 21/5/24.
//

import Foundation
import FirebaseFirestore
import Firebase
import FirebaseAuth
import FirebaseStorage
import FirebaseAuthUI

class FirestoreService {
    static let shared = FirestoreService()
    let db: Firestore
    
    private init() {
        db = Firestore.firestore()
    }

    func addUserCredential(uid: String, email: String, userid: String, display_name: String) {
        db.collection("users_credentials").document(uid).setData([
            "createdAt": Timestamp(),
            "userId": userid,
            "email": email,
            "display_name": display_name
            
        ]) { err in
            if let err = err {
                print("Error adding document: \(err)")
            } else {
                print("Document added with ID: \(uid)")
            }
        }
    }
 
}




