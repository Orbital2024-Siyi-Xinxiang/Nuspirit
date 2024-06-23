import Foundation
import Firebase
import UserNotifications

class NotificationService {
    static let shared = NotificationService()
    private var subscribedTopics: Set<String> = []

    func sendNotification(to token: String, title: String, body: String) {
        let urlString = "https://fcm.googleapis.com/fcm/send"
        let url = URL(string: urlString)!
        let paramString: [String: Any] = [
            "to": token,
            "notification": ["title": title, "body": body],
            "data": ["user": "test_id"]
        ]
        
        let request = NSMutableURLRequest(url: url)
        request.httpMethod = "POST"
        request.httpBody = try? JSONSerialization.data(withJSONObject: paramString, options: .prettyPrinted)
        request.setValue("application/json", forHTTPHeaderField: "Content-Type")
        request.setValue("key=YOUR_SERVER_KEY", forHTTPHeaderField: "Authorization")

        let task = URLSession.shared.dataTask(with: request as URLRequest) { data, response, error in
            if let error = error {
                print("Error: \(error)")
                return
            }
            if let data = data {
                print("Response: \(String(describing: String(data: data, encoding: .utf8)))")
            }
        }
        task.resume()
    }

    func subscribeToVenueTopic(buildingID: String) {
        let db = Firestore.firestore()
        db.collection("key_venues").document(buildingID).getDocument { document, error in
            if let document = document, document.exists {
                if let venueName = document.data()?["name"] as? String {
                    Messaging.messaging().subscribe(toTopic: venueName) { error in
                        if let error = error {
                            print("Error subscribing to topic: \(error)")
                        } else {
                            print("Subscribed to topic: \(venueName)")
                            self.subscribedTopics.insert(venueName)
                        }
                    }
                }
            }
        }
    }

    func unsubscribeFromVenueTopic(buildingID: String) {
        let db = Firestore.firestore()
        db.collection("key_venues").document(buildingID).getDocument { document, error in
            if let document = document, document.exists {
                if let venueName = document.data()?["name"] as? String {
                    Messaging.messaging().unsubscribe(fromTopic: venueName) { error in
                        if let error = error {
                            print("Error unsubscribing from topic: \(error)")
                        } else {
                            print("Unsubscribed from topic: \(venueName)")
                            self.subscribedTopics.remove(venueName)
                        }
                    }
                }
            }
        }
    }

    func unsubscribeAll() {
        for topic in subscribedTopics {
            Messaging.messaging().unsubscribe(fromTopic: topic) { error in
                if let error = error {
                    print("Error unsubscribing from topic: \(error)")
                } else {
                    print("Unsubscribed from topic: \(topic)")
                }
            }
        }
        subscribedTopics.removeAll()
    }
}
