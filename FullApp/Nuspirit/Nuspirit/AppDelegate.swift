import UIKit

@UIApplicationMain
class AppDelegate: UIResponder, UIApplicationDelegate {

    var window: UIWindow?

    func application(_ application: UIApplication, didFinishLaunchingWithOptions launchOptions: [UIApplication.LaunchOptionsKey: Any]?) -> Bool {
        window = UIWindow(frame: UIScreen.main.bounds)
        let initialViewController = NativeAppViewController()
        window?.rootViewController = UINavigationController(rootViewController: initialViewController)
        window?.makeKeyAndVisible()

        print("AppDelegate didFinishLaunchingWithOptions") // Debugging statement

        // Uncomment the next line when you want to enable Unity integration
        // Unity.shared.setHostMainWindow(window)
        return true
    }

    // Uncomment this function when you want to handle URL schemes for Unity
    /*
    func application(_ app: UIApplication, open url: URL, options: [UIApplication.OpenURLOptionsKey : Any] = [:]) -> Bool {
        if url.scheme == "unityApp" {
            if url.host == "unity" {
                Unity.shared.show()
            }
        }
        return true
    }
    */
}
