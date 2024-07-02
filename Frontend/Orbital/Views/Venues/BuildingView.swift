import SwiftUI
import FirebaseFirestore
import CoreLocation

struct BuildingView: View {
    var buildingID: String
    @State private var venueName: String = "Loading..."
    @State private var capacity: Int = 0
    @State private var busyLevel: String = "Unknown"
    @State private var elapsedTime: Int = 0
    @State private var timerColor: Color = .black
    @State private var timer: Timer?
    @State private var isStill: Bool = true

    var body: some View {
        VStack {
            Text("Building ID: \(buildingID)")
            Text("Venue Name: \(venueName)")
            Text("Capacity: \(capacity)")
            Text("Busy Level: \(busyLevel)")
                .foregroundColor(getBusyLevelColor())
            Text(String(format: "%02d:%02d:%02d", elapsedTime / 3600, (elapsedTime % 3600) / 60, elapsedTime % 60))
                .foregroundColor(timerColor)
                .font(.system(size: 24))
                .padding()
            
            // Add more UI elements to show building details
        }
        .navigationBarTitle("Building Details", displayMode: .inline)
        .onAppear {
            fetchVenueDetails()
            NotificationService.shared.subscribeToVenueTopic(buildingID: buildingID)
            startTimer()
<<<<<<< HEAD
//            Unity.shared.show()
//            Unity.shared.sendMessage(
//                "SceneLoader",
//                methodName: "LoadScene",
//                message: "SpecificVenue"
//            )
//            
//            Unity.shared.sendMessage(
//                "GameStateManager",
//                methodName: "SetVenueId",
//                message: buildingID
//            )
=======
>>>>>>> 708afefdc16dfb1a92f50e2bc9e39b1fdcb2c906
        }
        .onDisappear {
            NotificationService.shared.unsubscribeFromCurrentTopic {}
            stopTimer()
        }
        .onReceive(NotificationCenter.default.publisher(for: NSNotification.Name("LocationUpdate"))) { notification in
            if let location = notification.userInfo?["location"] as? CLLocation {
                checkUserStillness(location: location)
            }
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

    private func startTimer() {
        timer = Timer.scheduledTimer(withTimeInterval: 1, repeats: true) { _ in
            if isStill {
                elapsedTime += 1
                if elapsedTime >= 300 {
                    timerColor = .green
                }
            }
        }
    }

    private func stopTimer() {
        timer?.invalidate()
        timer = nil
    }

    private func checkUserStillness(location: CLLocation) {
        // Assuming lastLocation is a stored property
        var lastLocation: CLLocation?

        if let lastLocation = lastLocation {
            let distance = location.distance(from: lastLocation)
            if distance < 5 {
                isStill = true
            } else {
                isStill = false
                if elapsedTime < 300 {
                    elapsedTime = 0
                }
            }
        }

        lastLocation = location
    }
}

struct BuildingView_Previews: PreviewProvider {
    static var previews: some View {
        BuildingView(buildingID: "exampleID")
    }
}
