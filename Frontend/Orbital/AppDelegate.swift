//
//  AppDelegate.swift
//  Orbital
//
//  Created by Xu Siyi on 22/5/24.
//

import Foundation
import FirebaseCore
import Firebase
import FirebaseAuth
import FirebaseAuthUI
import UserNotifications
import FirebaseFacebookAuthUI
import FirebaseGoogleAuthUI
import FirebaseOAuthUI
import FirebasePhoneAuthUI
import UIKit
import SwiftUI

class AppDelegate: NSObject, UIApplicationDelegate, FUIAuthDelegate {
    var window: UIWindow?
    var orientationLock = UIInterfaceOrientationMask.all
    
    // set orientation to all
    // set orientation lock
    func application(_ application: UIApplication, supportedInterfaceOrientationsFor window: UIWindow?) -> UIInterfaceOrientationMask {
        return self.orientationLock
    }
    
    // set up appDelegate configurations for notifications and firebase authentication
    func application(_ application: UIApplication,
                didFinishLaunchingWithOptions launchOptions: [UIApplication.LaunchOptionsKey : Any]? = nil) -> Bool {
        FirebaseApp.configure()

        // set landing view
//        self.window = UIWindow(frame: UIScreen.main.bounds)
//        self.window?.rootViewController = UIHostingController(rootView: LandingView())
//        self.window?.makeKeyAndVisible()
        // return true
        let authUI = FUIAuth.defaultAuthUI()
        // You need to adopt a FUIAuthDelegate protocol to receive callback
        authUI?.delegate = self
        
        UNUserNotificationCenter.current().delegate = self
        
        let authOptions: UNAuthorizationOptions = [.alert, .badge, .sound]
        UNUserNotificationCenter.current().requestAuthorization(
            options: authOptions,
            completionHandler: { granted, error in
                // Handle errors
            }
        )
        
        application.registerForRemoteNotifications()

        return true
    }
    
//    func authUI(_ authUI: FUIAuth, didSignInWith user: User?, error: Error?) {
//        if user != nil {
//            // User is signed in, navigate to MainMapView
//            let mainMapView = UIHostingController(rootView: MainMapView())
//            self.window?.rootViewController = mainMapView
//            window?.makeKeyAndVisible()
//            
//        } else if let error = error {
//            // Handle error
//            print("Error signing in: \(error.localizedDescription)")
//        }
//    }
//    
    func application(_ app: UIApplication, open url: URL, options: [UIApplication.OpenURLOptionsKey : Any] = [:]) -> Bool {
        let sourceApplication = options[UIApplication.OpenURLOptionsKey.sourceApplication] as! String?
        if FUIAuth.defaultAuthUI()?.handleOpen(url, sourceApplication: sourceApplication) ?? false {
            return true
        }
        return false
    }
    
    func application(_ application: UIApplication, didRegisterForRemoteNotificationsWithDeviceToken deviceToken: Data) {
        Messaging.messaging().apnsToken = deviceToken
    }

    func application(_ application: UIApplication, didFailToRegisterForRemoteNotificationsWithError error: Error) {
        print("Failed to register for remote notifications: \(error)")
    }
}


// MARK: - UNUserNotificationCenterDelegate

extension AppDelegate: UNUserNotificationCenterDelegate {
    func userNotificationCenter(_ center: UNUserNotificationCenter,
                                willPresent notification: UNNotification,
                                withCompletionHandler completionHandler: @escaping (UNNotificationPresentationOptions) -> Void) {
        completionHandler([.alert, .badge, .sound])
    }

    func userNotificationCenter(_ center: UNUserNotificationCenter,
                                didReceive response: UNNotificationResponse,
                                withCompletionHandler completionHandler: @escaping () -> Void) {
        completionHandler()
    }
}

// MARK: - MessagingDelegate
// For Firebase cloud messaging registration token
extension AppDelegate: MessagingDelegate {
    func messaging(_ messaging: Messaging, didReceiveRegistrationToken fcmToken: String?) {
        print("FCM registration token: \(String(describing: fcmToken))")
        
        let dataDict: [String: String] = ["token": fcmToken ?? ""]
        NotificationCenter.default.post(name: Notification.Name("FCMToken"), object: nil, userInfo: dataDict)
        // Send the token to your server or use it as needed
    }
    
}

extension AppDelegate {

}

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
