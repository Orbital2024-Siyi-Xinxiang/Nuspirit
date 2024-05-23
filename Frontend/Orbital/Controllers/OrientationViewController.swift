//
//  OrientationViewController.swift
//  Orbital
//
//  Created by Xu Siyi on 22/5/24.
//

import SwiftUI

struct OrientationViewController: UIViewControllerRepresentable {
    var supportedOrientations: UIInterfaceOrientationMask

    func makeUIViewController(context: Context) -> UIViewController {
        let viewController = UIViewController()
        return viewController
    }

    func updateUIViewController(_ uiViewController: UIViewController, context: Context) {
        let appDelegate = UIApplication.shared.delegate as? AppDelegate
        appDelegate?.orientationLock = supportedOrientations
        UIDevice.current.setValue(UIInterfaceOrientation.unknown.rawValue, forKey: "orientation")
        UIDevice.current.setValue(supportedOrientations.rawValue, forKey: "orientation")
    }
}
