//
//  HomePageView.swift
//  Orbital
//
//  Created by Wulala's Macbook on 12/5/24.
//

import SwiftUI

struct HomePageView: View {
    var body: some View {
        NavigationView {
            VStack {
                
                NavigationLink(destination: RegisterView()) {
                    Text("Register")
                        .foregroundColor(.white)
                        .frame(width: 200, height: 50)
                        .background(Color.blue)
                        .cornerRadius(10)
                }
                NavigationLink(destination: SignInView()) {
                    Text("Sign In")
                        .foregroundColor(.white)
                        .frame(width: 200, height: 50)
                        .background(Color.green)
                        .cornerRadius(10)
                }
            }
        }
    }
}

// Preview provider for SwiftUI canvas
struct HomePageView_Previews: PreviewProvider {
    static var previews: some View {
        HomePageView()
    }
}
