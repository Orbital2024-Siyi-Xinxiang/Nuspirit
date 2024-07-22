//
//  MyIsland.swift
//  Orbital
//
//  Created by Xu Siyi on 16/5/24.
//

import SwiftUI

struct MyIslandView: View {
    var body: some View {
        Text("MyIsland")
            .onAppear {
                print("start navigating to unityApp")
                navigateToUnityApp()
            }
    }

    func navigateToUnityApp() {
        let userId = FirebaseAuthService().getCurrentUid()
        let scene = "MyIsland"
        let id = 0
        let urlString = "unityApp://\(userId)/\(scene)/\(id)/na"
 
        if let url = URL(string: urlString) {
            UIApplication.shared.open(url)
        } else {
            print("Invalid URL")
        }
    }
}
#Preview {
    MyIslandView().previewInterfaceOrientation(.landscapeLeft)
}
