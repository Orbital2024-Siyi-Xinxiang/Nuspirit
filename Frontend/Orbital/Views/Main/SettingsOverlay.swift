//
//  SettingsOverlayView.swift
//  Orbital
//
//  Created by Xu Siyi on 22/5/24.
//

import SwiftUI
import FirebaseCore
import FirebaseAuth
import FirebaseAuthUI

struct SettingsOverlay: View {
    @State private var showingSignOut = false
    
    var body: some View {
        VStack {
            Spacer()
            HStack {
                Spacer()
                if showingSignOut {
                    Button(action: {
                        signOut()
                    }) {
                        Text("Sign Out")
                            .padding()
                            .background(Color.red)
                            .foregroundColor(.white)
                            .cornerRadius(10)
                    }
                }
                Button(action: {
                    showingSignOut.toggle()
                }) {
                    Image(systemName: "gearshape.fill")
                        .foregroundColor(.blue)
                        .padding()
                }
            }
        }
        .padding()
    }
    
    private func signOut() {
        do {
            try Auth.auth().signOut()
            LandingView()
            
        } catch {
            print("Error signing out: \(error.localizedDescription)")
        }
    }
}

struct SettingsOverlay_Previews: PreviewProvider {
    static var previews: some View {
        SettingsOverlay()
    }
}
