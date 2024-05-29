import SwiftUI

struct CartView: View {
    var body: some View {
        VStack {
            Text("Cart")
                .font(.largeTitle)
            // List of cart items
            List {
                // Populate with cart items
                Text("Cart Item 1")
                Text("Cart Item 2")
                Text("Cart Item 3")
            }
        }
    }
}

struct CartView_Previews: PreviewProvider {
    static var previews: some View {
        CartView().previewInterfaceOrientation(.landscapeLeft)
    }
}
