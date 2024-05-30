import SwiftUI

struct BuildingView: View {
    var buildingID: String

    var body: some View {
        VStack {
            Text("Building ID: \(buildingID)")
            // Add more UI elements to show building details
        }
        .navigationBarTitle("Building Details", displayMode: .inline)
    }
}

struct BuildingView_Previews: PreviewProvider {
    static var previews: some View {
        BuildingView(buildingID: "exampleID")
    }
}
