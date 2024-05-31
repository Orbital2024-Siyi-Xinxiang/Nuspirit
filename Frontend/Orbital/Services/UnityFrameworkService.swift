import Foundation
import UnityFramework

class Unity: UIResponder, UIApplicationDelegate {

    static let shared = Unity()

    private let dataBundleId: String = "com.unity3d.framework"
    private let frameworkPath: String = "/Frameworks/UnityFramework.framework"

    private var ufw : UnityFramework?
    private var hostMainWindow : UIWindow?

    private var isInitialized: Bool {
        ufw?.appController() != nil
    }

    func preload() {
        if !isInitialized {
            DispatchQueue.global(qos: .background).async {
                self.initWindow()
            }
        }
    }
    
    func show() {
        if isInitialized {
            DispatchQueue.main.async {
                self.showWindow()
            }
        } else {
            preload()
            DispatchQueue.main.asyncAfter(deadline: .now() + 1.0) { // Adjust delay as needed
                self.showWindow()
            }
        }
    }

    func setHostMainWindow(_ hostMainWindow: UIWindow?) {
        self.hostMainWindow = hostMainWindow
    }

    private func initWindow() {
        if isInitialized {
            showWindow()
            return
        }

        guard let ufw = loadUnityFramework() else {
            print("ERROR: Was not able to load Unity")
            return unloadWindow()
        }

        self.ufw = ufw
        ufw.setDataBundleId(dataBundleId)
        ufw.register(self)
        ufw.runEmbedded(
            withArgc: CommandLine.argc,
            argv: CommandLine.unsafeArgv,
            appLaunchOpts: nil
        )
    }

    private func showWindow() {
        print("showing window")
        if isInitialized {
            ufw?.showUnityWindow()
        }
    }

    private func unloadWindow() {
        if isInitialized {
            ufw?.unloadApplication()
        }
    }

    private func loadUnityFramework() -> UnityFramework? {
        print("loading framework")
        let bundlePath: String = Bundle.main.bundlePath + frameworkPath

        let bundle = Bundle(path: bundlePath)
        if bundle?.isLoaded == false {
            bundle?.load()
        }

        let ufw = bundle?.principalClass?.getInstance()
        if ufw?.appController() == nil {
            let machineHeader = UnsafeMutablePointer<MachHeader>.allocate(capacity: 1)
            machineHeader.pointee = _mh_execute_header

            ufw?.setExecuteHeader(machineHeader)
        }
        return ufw
    }
}

extension Unity: UnityFrameworkListener {

    func unityDidUnload(_ notification: Notification!) {
        self.unloadWindow()
        ufw?.unregisterFrameworkListener(self)
        ufw = nil
        
        hostMainWindow?.makeKeyAndVisible()
        
    }
}
