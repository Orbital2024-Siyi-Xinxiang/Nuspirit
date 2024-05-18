//
//  AssetView.swift
//  Orbital
//
//  Created by Xu Siyi on 18/5/24.
//
import SwiftUI

struct AssetView: View {
    let asset: Asset
    @State private var purchaseMessage: String = ""
    
    var body: some View {
        VStack {
            Image(systemName: asset.icon)
                .resizable()
                .scaledToFit()
                .frame(width: 100, height: 100)
            Text(asset.name)
                .font(.largeTitle)
            Text("$\(asset.price, specifier: "%.2f")")
                .font(.title)
            
            Button(action: purchaseAsset) {
                Text("Purchase")
            }
        }
    }
    
    func purchaseAsset() {
        // Implement the purchase logic here
        // Purchase asset from backend
        guard let url = URL(string: "http://localhost:3000/purchase") else { return }
        var request = URLRequest(url: url)
        request.httpMethod = "POST"
        request.setValue("Application/json", forHTTPHeaderField: "Content-Type")
        
        let purchase = Purchase(userId: 1, assetId: asset.id) // Replace with actual user ID
        guard let encoded = try? JSONEncoder().encode(purchase) else { return }
        
        request.httpBody = encoded
        
        URLSession.shared.dataTask(with: request) { data, response, error in
            if let data = data {
                if let responseMessage = try? JSONDecoder().decode(PurchaseResponse.self, from: data) {
                    DispatchQueue.main.async {
                        self.purchaseMessage = responseMessage.message
                    }
                }
            }
        }.resume()
    }
}


struct AssetView_Previews: PreviewProvider {
    static var previews: some View {
        AssetView(asset: Asset(id: 1, name: "Gold", price: 1000, icon: "dollarsign.circle")).previewInterfaceOrientation(.landscapeLeft) // iPhone 11 Landscape
    }
}
