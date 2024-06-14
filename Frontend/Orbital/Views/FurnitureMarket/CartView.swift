import SwiftUI

struct CartItem: Identifiable {
    let id = UUID()
    let name: String
    var isSelected: Bool = false
}

struct CartView: View {
    @State private var cartItems: [CartItem] = [
        CartItem(name: "Cart Item 1"),
        CartItem(name: "Cart Item 2"),
        CartItem(name: "Cart Item 3")
    ]
    @State private var isSelectionMode: Bool = false
    @State private var selectAll: Bool = false
    
    var body: some View {
        VStack {
            HStack {
                Spacer()
                Text("Balance: $100.00")
                    .padding()
            }
            .padding(.top)

            Text("Cart")
                .font(.largeTitle)

            List {
                ForEach($cartItems) { $item in
                    HStack {
                        if isSelectionMode {
                            Button(action: {
                                item.isSelected.toggle()
                            }) {
                                Image(systemName: item.isSelected ? "checkmark.circle.fill" : "circle")
                                    .foregroundColor(item.isSelected ? .blue : .gray)
                            }
                        }
                        Text(item.name)
                            .onLongPressGesture {
                                withAnimation {
                                    isSelectionMode = true
                                }
                            }
                    }
                }
            }

            HStack {
                Spacer()
                if isSelectionMode {
                    Button(action: {
                        // Handle checkout action
                    }) {
                        Text("Checkout")
                            .padding()
                            .background(Color.green)
                            .foregroundColor(.white)
                            .cornerRadius(10)
                    }
                    .padding()
                }
            }

            if isSelectionMode {
                Button(action: {
                    selectAll.toggle()
                    for i in cartItems.indices {
                        cartItems[i].isSelected = selectAll
                    }
                }) {
                    Text(selectAll ? "Deselect All" : "Select All")
                        .padding()
                        .background(Color.blue)
                        .foregroundColor(.white)
                        .cornerRadius(10)
                }
                .padding()
            }
        }
    }
}

struct CartView_Previews: PreviewProvider {
    static var previews: some View {
        CartView().previewInterfaceOrientation(.landscapeLeft)
    }
}
