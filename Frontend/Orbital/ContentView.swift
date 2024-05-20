//
//  HomePageView.swift
//  Orbital
//
//  Created by Wulala's Macbook on 12/5/24.
//

import SwiftUI

struct ContentView: View {
  var body: some View {
    ZStack() {
        ZStack() {
            NavigationLink(destination: RegisterView()) {
                Rectangle()
                    .foregroundColor(.clear)
                    .frame(width: 283, height: 60)
                    .background(Color(red: 0.61, green: 0.86, blue: 0.94).opacity(0.33))
                    .cornerRadius(20)
                    .offset(x: -0.50, y: -0.50)
                Text("Sign In")
                    .font(Font.custom("Press Start 2P", size: 20))
                    .foregroundColor(Color(red: 0.23, green: 0.23, blue: 0.23))
                    .offset(x: 0, y: 3.50)
            }
            .frame(width: 292, height: 67)
            .offset(x: -0.50, y: 40.50)
        }
        NavigationLink(destination: SignInView()) {
            ZStack() {
                Rectangle()
                    .foregroundColor(.clear)
                    .frame(width: 283, height: 60)
                    .background(Color(red: 0.61, green: 0.94, blue: 0.74).opacity(0.40))
                    .cornerRadius(20)
                    .offset(x: -0.50, y: -0.50)
                Text("Sign Up")
                    .font(Font.custom("Press Start 2P", size: 20))
                    .foregroundColor(Color(red: 0.23, green: 0.23, blue: 0.23))
                    .offset(x: -1, y: 3.50)
            }
            .frame(width: 292, height: 67)
            .offset(x: -0.50, y: 129.50)
        }
        
      Rectangle()
        .foregroundColor(.clear)
        .frame(width: 209, height: 45)
        .background(
          AsyncImage(url: URL(string: "https://via.placeholder.com/209x45"))
        )
        .offset(x: 0, y: -233.50)
      Rectangle()
        .foregroundColor(.clear)
        .frame(width: 149, height: 181)
        .background(
          AsyncImage(url: URL(string: "https://via.placeholder.com/149x181"))
        )
        .offset(x: -14, y: -110.50)
      HStack(spacing: 0) {
        ZStack() { }
        .frame(width: 39.20, height: 39)
      }
      .padding(EdgeInsets(top: 0, leading: 0, bottom: 0, trailing: 0.80))
      .frame(width: 40, height: 39)
      .offset(x: -94.50, y: 219.50)
      ZStack() {

      }
      .frame(width: 40, height: 39)
      .offset(x: -31.50, y: 219.50)
      ZStack() {

      }
      .frame(width: 40, height: 39)
      .offset(x: 31.50, y: 219.50)
      ZStack() {

      }
      .frame(width: 40, height: 39)
      .offset(x: 94.50, y: 218.50)
    }
    .frame(width: 375, height: 812)
    .background(.white)
    .cornerRadius(40)
    .shadow(
      color: Color(red: 0, green: 0, blue: 0, opacity: 0.25), radius: 4, y: 4
    );
  }
}



// Preview provider for SwiftUI canvas
struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView().previewInterfaceOrientation(.portrait)
    }
}
