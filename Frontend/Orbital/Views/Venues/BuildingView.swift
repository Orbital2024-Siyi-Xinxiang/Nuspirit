import SwiftUI
import FirebaseFirestore

struct BuildingView: View {
    var buildingID: String
    @State private var venueName: String = "Loading..."
    @State private var capacity: Int = 0
    @State private var busyLevel: String = "Unknown"

    var body: some View {
        VStack {
            Text("Building ID: \(buildingID)")
            Text("Venue Name: \(venueName)")
            Text("Capacity: \(capacity)")
            Text("Busy Level: \(busyLevel)")
                .foregroundColor(getBusyLevelColor())
            
            // Add more UI elements to show building details
        }
        .navigationBarTitle("Building Details", displayMode: .inline)
        .onAppear {
            fetchVenueDetails()
            NotificationService.shared.subscribeToVenueTopic(buildingID: buildingID)
        }
        .onDisappear {
            NotificationService.shared.unsubscribeFromVenueTopic(buildingID: buildingID)
        }
    }

    private func fetchVenueDetails() {
        let db = Firestore.firestore()
        db.collection("key_venues").document(buildingID).getDocument { document, error in
            if let document = document, document.exists {
                let data = document.data()
                venueName = data?["name"] as? String ?? "Unknown"
                capacity = data?["capacity"] as? Int ?? 0
                busyLevel = data?["busyLevel"] as? String ?? "Unknown"
            }
        }
    }

    private func getBusyLevelColor() -> Color {
        switch busyLevel {
        case "busy":
            return .red
        case "not so busy":
            return .orange
        case "crowded":
            return .purple
        case "relaxed":
            return .green
        default:
            return .gray
        }
    }
}

struct BuildingView_Previews: PreviewProvider {
    static var previews: some View {
        BuildingView(buildingID: "exampleID")
    }
}
