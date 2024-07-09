import SwiftUI
import FirebaseFirestore
import Firebase
import FirebaseCore
import FirebaseAuth

struct CartItem: Identifiable {
    let id = UUID()
    let asset: Asset
    var isSelected: Bool = false
}

struct CartView: View {
    @Binding var balance: Double
    @State private var cartItems: [CartItem] = []
    @State private var isSelectionMode: Bool = false
    @State private var selectAll: Bool = false

    var body: some View {
        VStack {
            HStack {
                Spacer()
                Text("Balance: $\(balance, specifier: "%.2f")")
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
                        Text(item.asset.name)
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
                        checkout()
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

    func checkout() {
        // Handle checkout action
        let selectedItems = cartItems.filter { $0.isSelected }
        for item in selectedItems {
            balance -= item.asset.price
            cartItems.removeAll { $0.id == item.id }
        }
        // Update balance in Firestore
        let userId = "current_user_id" // Replace with actual user ID
        let db = Firestore.firestore()
        db.collection("users_tokens").document(userId).updateData(["studyToken": balance]) { error in
            if let error = error {
                print("Error updating balance: \(error)")
            } else {
                print("Checkout successful")
            }
        }
    }
}

struct CartView_Previews: PreviewProvider {
    static var previews: some View {
        CartView(balance: .constant(1000.0)).previewInterfaceOrientation(.landscapeLeft)
    }
}
