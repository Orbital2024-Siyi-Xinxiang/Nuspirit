//
//  SettingsOverlayView.swift
//  Orbital
//
//  Created by Xu Siyi on 22/5/24.
//

import SwiftUI
import Firebase
import FirebaseCore
import FirebaseAuth
import FirebaseAuthUI

struct SettingsOverlay: View {
    @State private var showSettings = false

    var body: some View {
        VStack {
            Spacer()
            HStack {
                Spacer()

                VStack {
                    Button(action: {
                        withAnimation {
                            showSettings.toggle()
                        }
                    }) {
                        Image(systemName: "gearshape.fill") // Placeholder image for settings
                            .resizable()
                            .frame(width: 30, height: 30)
                            .padding()
                    }

                    if showSettings {
                        VStack(spacing: 10) {
                            Button(action: {
                                // Add action for other buttons if needed
                            }) {
                                Image(systemName: "bell.fill") // Placeholder for another setting
                                    .resizable()
                                    .frame(width: 30, height: 30)
                            }

                            Button(action: {
                                signOut()
                            }) {
                                Image(systemName: "arrowshape.turn.up.left.fill") // Placeholder for sign out
                                    .resizable()
                                    .frame(width: 30, height: 30)
                            }
                        }
                        .transition(.move(edge: .trailing))
                    }
                }
                .padding()
            }
        }
    }

    func signOut() {
        do {
            try Auth.auth().signOut()
            if let authUI = FUIAuth.defaultAuthUI() {
                try authUI.signOut()
            }
            print("User signed out")
            // Handle UI updates or redirection after sign out
        } catch let signOutError as NSError {
            print("Error signing out: %@", signOutError)
        }
    }
}

struct SettingsOverlay_Previews: PreviewProvider {
    static var previews: some View {
        SettingsOverlay()
    }
}
