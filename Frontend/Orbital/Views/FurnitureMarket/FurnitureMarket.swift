import SwiftUI
import Firebase

struct FurnitureMarketView: View {
    @State private var selectedCategory: String? = nil
    @State private var selectedAsset: Asset? = nil
    @State private var assets: [Asset] = []
    @State private var balance: Double = 1000.0

    var body: some View {
        NavigationView {
            VStack {
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
                            Button(action: {
                                purchaseAsset(asset: selectedAsset)
                            }) {
                                Text("Purchase")
                                    .padding()
                                    .background(Color.green)
                                    .foregroundColor(.white)
                                    .cornerRadius(10)
                            }
                        }
                        .padding()
                    }
                }
                
                // Top right: Cart button and balance
                HStack {
                    Text("Balance: $\(balance, specifier: "%.2f")")
                    NavigationLink(destination: CartView(balance: $balance)) {
                        Image(systemName: "cart")
                            .resizable()
                            .frame(width: 30, height: 30)
                    }
                }
                .padding()
            }
            .padding()
        }
        .onAppear {
            fetchBalance()
        }
    }

    func getCategories() -> [String] {
        return ["Furniture", "Housing", "Plant", "Animal", "Avatar"]
    }

    func getAssets(for category: String) -> [Asset] {
        switch category {
        case "Furniture":
            return furnitureAssets
        case "Housing":
            return housingAssets
        case "Plant":
            return plantAssets
        case "Animal":
            return animalAssets
        case "Avatar":
            return avatarDesignAssets
        default:
            return []
        }
    }

    func fetchBalance() {
        // Fetch balance from Firestore
        let userId = "current_user_id" // Replace with actual user ID
        let db = Firestore.firestore()
        db.collection("users_tokens").document(userId).getDocument { (document, error) in
            if let document = document, document.exists {
                let data = document.data()
                balance = data?["studyToken"] as? Double ?? 1000.0
            }
        }
    }

    func purchaseAsset(asset: Asset) {
        // Implement purchase logic and update Firestore
        let userId = "current_user_id" // Replace with actual user ID
        let db = Firestore.firestore()
        let assetPrice = asset.price

        if balance >= assetPrice {
            balance -= assetPrice
            db.collection("users_tokens").document(userId).updateData(["studyToken": balance]) { error in
                if let error = error {
                    print("Error updating balance: \(error)")
                } else {
                    print("Purchase successful")
                }
            }
        } else {
            print("Insufficient balance")
        }
    }
}

struct FurnitureMarketView_Previews: PreviewProvider {
    static var previews: some View {
        FurnitureMarketView().previewInterfaceOrientation(.landscapeLeft)
    }
}
