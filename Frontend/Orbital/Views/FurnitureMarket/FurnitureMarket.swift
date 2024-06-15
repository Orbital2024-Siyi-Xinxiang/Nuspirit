import SwiftUI

struct FurnitureMarketView: View {
    @State private var selectedCategory: String? = nil
    @State private var selectedAsset: Asset? = nil
    @State private var assets: [Asset] = [] // Populate this with your assets

    var body: some View {
        NavigationView {
            HStack {
                // Left: Category buttons
                VStack {
                    ForEach(getCategories(), id: \.self) { category in
                        Button(action: {
                            selectedCategory = category
                            assets = getAssets(for: category)
                        }) {
                            Text(category)
                                .padding()
                                .background(selectedCategory == category ? Color.gray : Color.clear)
                                .cornerRadius(10)
                        }
                    }
                }
                .padding()
                
                // Middle: Asset collection
                ScrollView {
                    LazyVGrid(columns: Array(repeating: GridItem(.flexible()), count: 3), spacing: 16) {
                        ForEach(assets) { asset in
                            VStack {
                                Image(systemName: asset.icon)
                                    .resizable()
                                    .scaledToFit()
                                    .frame(width: 100, height: 100)
                                    .background(selectedAsset == asset ? Color.yellow : Color.clear)
                                    .onTapGesture {
                                        selectedAsset = asset
                                    }
                                Text("$\(asset.price, specifier: "%.2f")")
                            }
                        }
                    }
                    .padding()
                }
                
                // Right: Asset preview
                if let selectedAsset = selectedAsset {
                    VStack {
                        Image(systemName: selectedAsset.icon)
                            .resizable()
                            .scaledToFit()
                            .frame(width: 200, height: 200)
                        Text(selectedAsset.name)
                        Text("$\(selectedAsset.price, specifier: "%.2f")")
                    }
                    .padding()
                }
                
                Spacer()
                
                // Top right: Cart button and balance
                VStack {
                    HStack {
                        Text("Balance: $1000.00")
                        // Replace with actual balance
                        NavigationLink(destination: CartView()) {
                            Image(systemName: "cart")
                                .resizable()
                                .frame(width: 30, height: 30)
                        }
                        
                    }
                    Spacer()
                }
                .padding()
            }
            .padding()
        }
    }

    func getCategories() -> [String] {
        // Replace with actual category fetching logic
        return ["Category 1", "Category 2", "Category 3"]
    }

    func getAssets(for category: String) -> [Asset] {
        // Replace with actual assets fetching logic for the selected category
        return [Asset(id: 1, cat: category, name: "Asset 1", price: 100.0, icon: "house"),
                Asset(id: 2, cat: category, name: "Asset 2", price: 200.0, icon: "car"),
                Asset(id: 3, cat: category, name: "Asset 3", price: 300.0, icon: "star")]
    }
}



struct FurnitureMarketView_Previews: PreviewProvider {
    static var previews: some View {
        FurnitureMarketView().previewInterfaceOrientation(.landscapeLeft)
    }
}
