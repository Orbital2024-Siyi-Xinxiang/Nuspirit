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
    
//    func authUI(_ authUI: FUIAuth, didSignInWith user: User?, error: Error?) {
//        if let user = user {
//            
//            db.collection("users").document(user.uid).setData([
//                "email": user.email ?? "",
//                "displayName": user.displayName ?? ""
//            ]) { err in
//                if let err = err {
//                    print("Error writing document: \(err)")
//                } else {
//                    print("Document successfully written!")
//                }
//            }
//        }
//    }
}




