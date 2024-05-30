//
//  MyIsland.swift
//  Orbital
//
//  Created by Xu Siyi on 16/5/24.
//

import SwiftUI

struct MyIslandView: View {
    var body: some View {
        Text(/*@START_MENU_TOKEN@*/"Hello, World!"/*@END_MENU_TOKEN@*/)
    }
    onAppear {
        Unity.shared.show()
    }
}

#Preview {
    MyIslandView().previewInterfaceOrientation(.landscapeLeft)
}
