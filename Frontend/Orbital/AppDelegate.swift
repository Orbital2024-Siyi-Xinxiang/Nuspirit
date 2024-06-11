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
import FirebaseEmailAuthUI
import FirebaseEmailAuthUI
import UIKit
import SwiftUI
import GoogleSignIn
import FBSDKCoreKit
import FBSDKLoginKit



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
        
        // configure firebase authentication
        print("\n\n\nloading unity host window ... \n\n\n")
        FirebaseApp.configure()
        // set landing view
        
        
        self.window = UIWindow(frame: UIScreen.main.bounds)
        self.window?.rootViewController = UIHostingController(rootView: LandingView())
        self.window?.makeKeyAndVisible()
        
//        Unity.shared.setHostMainWindow(window)
//        Unity.shared.preload()
       
        // register remote notifications
        UNUserNotificationCenter.current().delegate = self
        Messaging.messaging().delegate = self
        
        let authOptions: UNAuthorizationOptions = [.alert, .badge, .sound]
        UNUserNotificationCenter.current().requestAuthorization(
            options: authOptions,
            completionHandler: { granted, error in
                // Handle errors
            }
        )
        
        application.registerForRemoteNotifications()
        
        print("finished loading unity :)")
        
        NotificationCenter.default.addObserver(self, selector: #selector(apnsTokenReceived), name: Notification.Name("APNSTokenReceived"), object: nil)

        
        return true
    }

    
    func application(_ application: UIApplication, didRegisterForRemoteNotificationsWithDeviceToken deviceToken: Data) {
//        self.apnsToken = deviceToken
        Messaging.messaging().apnsToken = deviceToken
        // Notify that the APNS token is received
        NotificationCenter.default.post(name: Notification.Name("APNSTokenReceived"), object: nil)
    }

    func application(_ application: UIApplication, didFailToRegisterForRemoteNotificationsWithError error: Error) {
        print("Failed to register for remote notifications: \(error)")
    }
    
    @objc func apnsTokenReceived() {
        // Re-retrieve the FCM token now that the APNS token is set
        Messaging.messaging().token { token, error in
            if let error = error {
                print("Error fetching FCM registration token: \(error)")
            } else if let token = token {
                print("FCM registration token: \(token)")
                // Handle the token if needed, e.g., send it to your server
            }
        }
    }
    
    func application(_ app: UIApplication, open url: URL, options: [UIApplication.OpenURLOptionsKey : Any] = [:]) -> Bool {
        let sourceApplication = options[UIApplication.OpenURLOptionsKey.sourceApplication] as! String?
        if FUIAuth.defaultAuthUI()?.handleOpen(url, sourceApplication: sourceApplication) ?? false {
            return true
        }
        return false
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


