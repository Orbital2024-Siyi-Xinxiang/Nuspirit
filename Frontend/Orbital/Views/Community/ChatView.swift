//
//  ChatView.swift
//  Orbital
//
//  Created by Xu Siyi on 21/5/24.
//

// ChatView.swift
import SwiftUI
import FirebaseFirestore

struct ChatView: View {
    @State private var message = ""
    @State private var messages: [Message] = []
    let currentUserID: String
    let recipientID: String
    let db = FirestoreService.shared.db

    var body: some View {
        VStack {
            List(messages) { message in
                Text("\(message.senderID): \(message.text)")
            }

            HStack {
                TextField("Enter message", text: $message)
                    .textFieldStyle(RoundedBorderTextFieldStyle())
                    .padding()

                Button(action: sendMessage) {
                    Text("Send")
                        .padding()
                        .background(Color.blue)
                        .foregroundColor(.white)
                        .cornerRadius(8)
                }
            }
            .padding()
        }
        .onAppear(perform: fetchMessages)
    }

    func sendMessage() {
        let newMessage = Message(senderID: currentUserID, recipientID: recipientID, text: message)
        db.collection("messages").addDocument(data: newMessage.dictionary)
        message = ""
    }

    func fetchMessages() {
        db.collection("messages")
            .whereField("recipientID", isEqualTo: recipientID)
            .addSnapshotListener { (snapshot, error) in
                guard let documents = snapshot?.documents else { return }
                self.messages = documents.map { doc -> Message in
                    let data = doc.data()
                    let senderID = data["senderID"] as? String ?? ""
                    let recipientID = data["recipientID"] as? String ?? ""
                    let text = data["text"] as? String ?? ""
                    return Message(senderID: senderID, recipientID: recipientID, text: text)
                }
            }
    }
}

struct Message: Identifiable {
    var id = UUID()
    var senderID: String
    var recipientID: String
    var text: String

    var dictionary: [String: Any] {
        return [
            "senderID": senderID,
            "recipientID": recipientID,
            "text": text
        ]
    }
}
