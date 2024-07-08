import UIKit

//class : UIViewController {
//
//    override func viewDidLoad() {
//        super.viewDidLoad()
//        view.backgroundColor = .white
//
//        let navigateButton = UIButton(type: .system)
//        navigateButton.setTitle("Go to Unity App", for: .normal)
//        // Uncomment the next line when you want to enable navigation to Unity
//        // navigateButton.addTarget(self, action: #selector(navigateToUnity), for: .touchUpInside)
//        navigateButton.translatesAutoresizingMaskIntoConstraints = false
//        view.addSubview(navigateButton)
//
//        NSLayoutConstraint.activate([
//            navigateButton.centerXAnchor.constraint(equalTo: view.centerXAnchor),
//            navigateButton.centerYAnchor.constraint(equalTo: view.centerYAnchor)
//        ])
//
//        print("NativeAppViewController loaded") // Debugging statement
//    }
//
//    // Uncomment this function when you want to enable navigation to Unity
//    /*
//    @objc func navigateToUnity() {
//        if let url = URL(string: "unityApp://unity") {
//            UIApplication.shared.open(url, options: [:], completionHandler: nil)
//        }
//    }
//    */
//}


class NativeAppViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
        
        setupUI()
    }
    
    func setupUI() {
        // Create a label
        let label = UILabel(frame: CGRect(x: 50, y: 100, width: 200, height: 50))
        label.text = "Hello, UIApplication!"
        label.textColor = .black
        
        // Create a button
        let button = UIButton(type: .system)
        button.frame = CGRect(x: 100, y: 200, width: 100, height: 50)
        button.setTitle("Start", for: .normal)
        button.addTarget(self, action: #selector(buttonTapped), for: .touchUpInside)
        
        // Add UI elements to the view
        view.addSubview(label)
        view.addSubview(button)
    }
    
    @objc func buttonTapped() {
        print("Button tapped!")
        showAlert()
    }
    
    func showAlert() {
        let alert = UIAlertController(title: "Hello!", message: "You tapped the button!", preferredStyle: .alert)
        alert.addAction(UIAlertAction(title: "OK", style: .default, handler: nil))
        present(alert, animated: true, completion: nil)
    }
}
