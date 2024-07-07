import UIKit

class NativeAppViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()
        view.backgroundColor = .white

        let navigateButton = UIButton(type: .system)
        navigateButton.setTitle("Go to Unity App", for: .normal)
        // Uncomment the next line when you want to enable navigation to Unity
        // navigateButton.addTarget(self, action: #selector(navigateToUnity), for: .touchUpInside)
        navigateButton.translatesAutoresizingMaskIntoConstraints = false
        view.addSubview(navigateButton)

        NSLayoutConstraint.activate([
            navigateButton.centerXAnchor.constraint(equalTo: view.centerXAnchor),
            navigateButton.centerYAnchor.constraint(equalTo: view.centerYAnchor)
        ])

        print("NativeAppViewController loaded") // Debugging statement
    }

    // Uncomment this function when you want to enable navigation to Unity
    /*
    @objc func navigateToUnity() {
        if let url = URL(string: "unityApp://unity") {
            UIApplication.shared.open(url, options: [:], completionHandler: nil)
        }
    }
    */
}
