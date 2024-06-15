import UIKit
import SwiftUI

class OrientationViewController: UIViewController {
    var supportedOrientation: UIInterfaceOrientationMask = .portrait

    override var supportedInterfaceOrientations: UIInterfaceOrientationMask {
        return supportedOrientation
    }

    override var shouldAutorotate: Bool {
        return true
    }
}



struct OrientationViewControllerWrapper: UIViewControllerRepresentable {
    var supportedOrientation: UIInterfaceOrientationMask
    var content: AnyView

    func makeUIViewController(context: Context) -> OrientationViewController {
        let viewController = OrientationViewController()
        viewController.supportedOrientation = supportedOrientation
        let hostingController = UIHostingController(rootView: content)
        viewController.addChild(hostingController)
        viewController.view.addSubview(hostingController.view)
        hostingController.didMove(toParent: viewController)
        hostingController.view.translatesAutoresizingMaskIntoConstraints = false
        NSLayoutConstraint.activate([
            hostingController.view.topAnchor.constraint(equalTo: viewController.view.topAnchor),
            hostingController.view.bottomAnchor.constraint(equalTo: viewController.view.bottomAnchor),
            hostingController.view.leadingAnchor.constraint(equalTo: viewController.view.leadingAnchor),
            hostingController.view.trailingAnchor.constraint(equalTo: viewController.view.trailingAnchor)
        ])
        return viewController
    }

    func updateUIViewController(_ uiViewController: OrientationViewController, context: Context) {
        uiViewController.supportedOrientation = supportedOrientation
    }
}
