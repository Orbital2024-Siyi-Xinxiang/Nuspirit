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
            
            let userId = FirebaseAuthService().getCurrentUid()
            let scene = "SpecificVenue"
            let buildingID = buildingID
            
            if let url = URL(string:"unityApp://\(userId)/\(scene)/\(buildingID)/na")
            {
                if UIApplication.shared.canOpenURL(url) {
                    UIApplication.shared.open(url, options: [:], completionHandler: nil)
                } else {
                    print("Cannot open url of app 'unityApp'")
                }
                
            } else {
                print("Failed to construct URL")
            }
            
            //            Unity.shared.show()
            //            Unity.shared.sendMessage(
            //                "SceneLoader",
            //                methodName: "LoadScene",
            //                message: "SpecificVenue"
            //            )
            //            Unity.shared.sendMessage(
            //                "GameStateManager",
            //                methodName: "SetVenueId",
            //                message: buildingID
            //            )
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
    
//    func constructUnityAppURL(userId: String, scene: String, venueId: String, trailingInfo: String = "na") -> URL? {
//        // Define a set of characters that are allowed in a URL query
//        var allowedCharacterSet = CharacterSet.urlPathAllowed
//        allowedCharacterSet.insert(charactersIn: "/")
//
//        // Encode special characters in userId, scene, venueId, and trailingInfo
//        guard let encodedUserId = userId.addingPercentEncoding(withAllowedCharacters: allowedCharacterSet),
//              let encodedScene = scene.addingPercentEncoding(withAllowedCharacters: allowedCharacterSet),
//              let encodedVenueId = venueId.addingPercentEncoding(withAllowedCharacters: allowedCharacterSet),
//              let encodedTrailingInfo = trailingInfo.addingPercentEncoding(withAllowedCharacters: allowedCharacterSet) else {
//            print("Failed to encode URL components")
//            return nil
//        }
//
//        // Construct the URL string
//        let urlString = "unityApp://\(encodedUserId)/\(encodedScene)/\(encodedVenueId)/\(encodedTrailingInfo)"
//        
//        // Convert to URL object
//        guard let url = URL(string: urlString) else {
//            print("Failed to create URL from string")
//            return nil
//        }
//        
//        return url
//    }
}


struct BuildingView_Previews: PreviewProvider {
    static var previews: some View {
        BuildingView(buildingID: "exampleID")
    }
}
