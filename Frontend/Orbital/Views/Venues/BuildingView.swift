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
            
            
            
            // Check if the URL scheme is unityApp
            //            url =
            //            if url.scheme == "unityApp" {
            //                // Open the URL if the device can handle it
            //                if UIApplication.shared.canOpenURL(url) {
            //                    UIApplication.shared.open(url, options: [:], completionHandler: nil)
            //                } else {
            //                    print("Cannot open url of app 'unityApp'")
            //                }
            //                return true
            //            }
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
    
    func constructUnityAppURL(userId: String, scene: String, buildingID: String) -> URL? {
        // Encode special characters in userId, scene, and buildingID
        guard let encodedUserId = userId.addingPercentEncoding(withAllowedCharacters: .urlHostAllowed),
              let encodedScene = scene.addingPercentEncoding(withAllowedCharacters: .urlHostAllowed),
              let encodedBuildingID = buildingID.addingPercentEncoding(withAllowedCharacters: .urlHostAllowed) else {
            print("Failed to encode URL components")
            return nil
        }
        
        // Construct the URL string
        let urlString = "unityApp://\(encodedUserId)|\(encodedScene)|\(encodedBuildingID)"
        
        // Convert to URL object
        guard let url = URL(string: urlString) else {
            print("Failed to create URL from string")
            return nil
        }
        
        return url
    }
    
    func handleUnityAppURL(_ url: URL) -> Bool {
        // Check if the URL scheme is unityApp
        guard url.scheme == "unityApp" else { return false }
        
        // Parse URL components
        guard let urlComponents = URLComponents(url: url, resolvingAgainstBaseURL: false),
              let host = urlComponents.host,
              let path = urlComponents.path.removingPercentEncoding else {
            print("Invalid URL format")
            return false
        }
        
        // Split the path into components using '|' delimiter
        let components = path.components(separatedBy: "|")
        guard components.count == 3 else {
            print("Invalid number of components in URL path")
            return false
        }
        
        // Extract userId, scene, and id (buildingID)
        let userId = components[0]
        let scene = components[1]
        let buildingID = components[2]
        
        // Set scene to "SpecificVenue"
        guard scene == "SpecificVenue" else {
            print("Invalid scene in URL")
            return false
        }
        
        // Get current user's ID
        
        let currentUserId = FirebaseAuthService().getCurrentUid()
        
        // Check if the userId from URL matches the current user's ID
        guard userId == currentUserId else {
            print("User ID mismatch")
            return false
        }
        
        // Open the URL if the device can handle it
        if UIApplication.shared.canOpenURL(url) {
            UIApplication.shared.open(url, options: [:], completionHandler: nil)
        } else {
            print("Cannot open url of app 'unityApp'")
        }
        
        // Handle additional actions if needed
        fetchVenueDetails()
        NotificationService.shared.subscribeToVenueTopic(buildingID: buildingID)
        startTimer()
        
        return true
    }
}


struct BuildingView_Previews: PreviewProvider {
    static var previews: some View {
        BuildingView(buildingID: "exampleID")
    }
}
