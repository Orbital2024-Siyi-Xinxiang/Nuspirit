import SwiftUI

struct FurnitureMarketView: View {
    @State private var userBalance: Double = 0.0
    @State private var assets: [Asset] = []
    
    var body: some View {
        VStack {
            HStack {
                Spacer()
                Button(action: {
                    // Code to navigate back to the main map page
                }) {
                    Image(systemName: "xmark")
                        .font(.title)
                }
            }
            .padding()
            
            Text("Wallet Balance: $\(userBalance)")
                .font(.title)
            
            Button(action: {
                // Code to navigate to the user balance page
            }) {
                Text("Top up wallet")
                    .font(.headline)
                    .padding()
                    .background(Color.blue)
                    .foregroundColor(.white)
                    .cornerRadius(10)
            }
            
            // Add your furniture market content here
            
            Spacer()
        }
        NavigationView {
            List(assets) { asset in
                NavigationLink(destination: AssetView(asset: asset)) {
                    HStack {
                        Image(systemName: asset.icon)
                        Text(asset.name)
                        Spacer()
                        Text("$\(asset.price, specifier: "%.2f")")
                    }
                }
            }
            .onAppear(perform: loadAssets)
            .navigationTitle("Market")
        }
    }
    
    func loadAssets() {
        // Fetch assets from backend
        guard let url = URL(string: "http://localhost:3000/market") else { return }
        
        URLSession.shared.dataTask(with: url) { data, response, error in
            if let data = data {
                if let decodedAssets = try? JSONDecoder().decode([Asset].self, from: data) {
                    DispatchQueue.main.async {
                        self.assets = decodedAssets
                    }
                }
            }
        }.resume()
    }
}

struct FurnitureMarketView_Previews: PreviewProvider {
    static var previews: some View {
        FurnitureMarketView()
            .previewLayout(.fixed(width: 896, height: 414)) // iPhone 11 Landscape
    }
}
