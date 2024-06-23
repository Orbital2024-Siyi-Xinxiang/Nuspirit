import SwiftUI
import Firebase
import FirebaseCore
import FirebaseStorage
import FirebaseFirestore


struct SpecificAssetView: View {
    let asset: Asset
    @State private var purchaseMessage: String = ""
    @Binding var balance: Double

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

            Button(action: {
                purchaseAsset()
            }) {
                Text("Purchase")
                    .padding()
                    .background(Color.green)
                    .foregroundColor(.white)
                    .cornerRadius(10)
            }
        }
    }

    func purchaseAsset() {
        // Implement the purchase logic here
        let userId = "current_user_id" // Replace with actual user ID
        let db = Firestore.firestore()
        let assetPrice = asset.price

        if balance >= assetPrice {
            balance -= assetPrice
            db.collection("users_tokens").document(userId).updateData(["studyToken": balance]) { error in
                if let error = error {
                    print("Error updating balance: \(error)")
                } else {
                    purchaseMessage = "Purchase successful"
                }
            }
        } else {
            purchaseMessage = "Insufficient balance"
        }
    }
}

