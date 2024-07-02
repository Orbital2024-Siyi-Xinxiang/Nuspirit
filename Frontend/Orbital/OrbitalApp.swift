import SwiftUI


@main
struct OrbitalApp: App {
    
    @State private var showSettingsOverlay = false

    let persistenceController = PersistenceController.shared

    @UIApplicationDelegateAdaptor(AppDelegate.self) var appDelegate
    
    var body: some Scene {
        WindowGroup {
            
                    LandingView()
                        .environment(\.managedObjectContext, persistenceController.container.viewContext)
                }
            
        
    }
}
