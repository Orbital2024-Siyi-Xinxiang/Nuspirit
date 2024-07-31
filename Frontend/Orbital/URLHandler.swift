//
//  URLHandler.swift
//  Orbital
//
//  Created by Xu Siyi on 21/7/24.
//

import SwiftUI
import FirebaseMessaging

struct URLHandler: View {
    @State private var userId: String = ""
    @State private var currentView: String = ""
    @State private var action: String = ""
    @State private var otherInfo: String = ""

    var body: some View {
        NavigationView {
            VStack {
                if currentView.isEmpty {
                    Text("Welcome to the Orbital App")
                } else {
                    navigateToView()
                }
            }
            .onOpenURL { url in
                handleURL(url)
            }
        }
    }

    func handleURL(_ url: URL) {
        guard url.scheme == "swiftUIApp" else {
            print("Invalid URL scheme")
            return
        }
        
        let urlString = url.absoluteString
        let components = urlString.components(separatedBy: "://")
        
        guard components.count == 2 else {
            print("Invalid URL format")
            return
        }
        
        let payload = components[1]
        let parts = payload.components(separatedBy: "/")
        
        guard parts.count >= 3 else {
            print("Incomplete URL parts")
            return
        }
        
        userId = parts[0]
        currentView = parts[1]
        action = parts[2]
        otherInfo = parts[-1]
        
        // Perform any additional setup based on parsed URL
        performActionBasedOnURL()
    }
    
    func performActionBasedOnURL() {
        // Implement the logic to perform actions based on URL
        // Example:
        print("UserId: \(userId)")
        print("Navigating to \(currentView) with action: \(action) and info: \(otherInfo)")
        // Perform additional actions if needed
        
        if (currentView == "MainMapView") {
            if (action == "unsubscribe") {
                // Unsubscribe from Firebase Messaging topic
                Messaging.messaging().unsubscribe(fromTopic: otherInfo) { error in
                    if let error = error {
                        print("Error unsubscribing from topic: \(error.localizedDescription)")
                    } else {
                        print("Successfully unsubscribed from topic: \(otherInfo)")
                    }
                }
            }
        }
    }

    @ViewBuilder
    func navigateToView() -> some View {
        switch currentView {
        case "MainMapView":
            MainMapView(showSettingsOverlay: Binding.constant(true))
        case "LandingView":
            LandingView()
//        case "ProfileView":
//            ProfileView(action: action, otherInfo: otherInfo)
//        default:
//            Text("Unknown view: \(currentView)")
        default:
            LandingView()
        }
    }
}

#Preview {
    URLHandler()
}
