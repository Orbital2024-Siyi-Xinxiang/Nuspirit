//
//  SplashScreenView.swift
//  Orbital
//
//  Created by Xu Siyi on 18/5/24.
//

import SwiftUI

struct SplashScreenView: View {
    @State private var isActive = false

    var body: some View {
        Group {
            if isActive {
                ContentView() // Your homepage view
            } else {
                VStack {
                    // Your splash screen content
                    Image(systemName: "app.fill") // Replace with your app logo
                        .resizable()
                        .scaledToFit()
                        .frame(width: 100, height: 100)
                    Text("Your App Name")
                        .font(.largeTitle)
                        .fontWeight(.bold)
                }
                .onAppear {
                    // Delay for 2 seconds
                    DispatchQueue.main.asyncAfter(deadline: .now() + 2) {
                        self.isActive = true
                    }
                }
            }
        }
    }
}

struct SplashScreenView_Previews: PreviewProvider {
    static var previews: some View {
        SplashScreenView()
    }
}
