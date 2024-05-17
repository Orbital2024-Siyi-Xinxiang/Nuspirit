import SwiftUI

struct FurnitureMarketView: View {
    @State private var userBalance: Double = 0.0
    
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
    }
}

struct FurnitureMarketView_Previews: PreviewProvider {
    static var previews: some View {
        FurnitureMarketView()
            .previewLayout(.fixed(width: 896, height: 414)) // iPhone 11 Landscape
    }
}
