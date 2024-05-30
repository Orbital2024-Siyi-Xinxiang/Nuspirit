//
//  FirebaseMessaging.swift
//  Orbital
//
//  Created by Xu Siyi on 21/5/24.
//

import Foundation

// before implementing this
//Configure FCM:

// Set up FCM for your project and get the server key.
// Use UNUserNotificationCenter to handle notifications.


//MainMapView displays other users on the map, respecting their privacy settings.
//ChatView handles sending and receiving messages and friend requests.
//NotificationService sends notifications using FCM.

import UserNotifications
import Firebase

class NotificationService {
    static let shared = NotificationService()

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
}


// Use the NotificationService class to send notifications to a device token. The sendNotification method sends a notification to the device token with a title and body. Replace YOUR_SERVER_KEY with your server key.
// to access FCM registration token at any time, use this method:
//Messaging.messaging().token { token, error in
//  if let error = error {
//    print("Error fetching FCM registration token: \(error)")
//  } else if let token = token {
//    print("FCM registration token: \(token)")
//    self.fcmRegTokenMessage.text  = "Remote FCM registration token: \(token)"
//  }
//}

// auto enable initiation of notification settings
//Messaging.messaging().autoInitEnabled = true
