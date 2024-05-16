import SwiftUI

struct CartView: View {
    @State private var items = [Item]() // Define items array

    var body: some View {
        VStack {
            Button(action: {
                print("Select All Button Tapped")
            }) {
                Text("Select All")
                    .frame(width: 100, height: 50)
                    .foregroundColor(.black)
            }
            
            Button(action: {
                print("Delete Button Tapped")
            }) {
                Text("Delete")
                    .frame(width: 100, height: 50)
                    .foregroundColor(.black)
            }
            
            Spacer()
            
            Button(action: {
                print("Checkout Button Tapped")
            }) {
                Text("Checkout")
                    .frame(width: 100, height: 50)
                    .foregroundColor(.black)
            }
        }
        .padding()
        
        List {
            ForEach(items) { item in
                NavigationLink(destination: Text("Item at \(item.timestamp)")) {
                    Text("Item at \(item.timestamp)")
                }
            }
            .onDelete(perform: deleteItems)
        }
        .toolbar {
            ToolbarItem(placement: .navigationBarTrailing) {
                EditButton()
            }
            ToolbarItem {
                Button(action: addItem) {
                    Label("Add Item", systemImage: "plus")
                }
            }
        }
    }
    
    // Define Item struct
    struct Item: Identifiable {
        let id = UUID()
        let timestamp = Date()
    }
    
    // Define deleteItems function
    func deleteItems(at offsets: IndexSet) {
        items.remove(atOffsets: offsets)
    }
    
    // Define addItem function
    func addItem() {
        items.append(Item())
    }
}

struct CartView_Previews: PreviewProvider {
    static var previews: some View {
        CartView()
    }
}
