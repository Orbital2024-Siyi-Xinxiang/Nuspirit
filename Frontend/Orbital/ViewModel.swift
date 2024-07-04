//
//  ViewModel.swift
//  Orbital
//
//  Created by Xu Siyi on 1/7/24.


import Foundation
import UnityFramework

class ViewModel: NSObject, ObservableObject, NativeCallsProtocol {
    func showHostMainWindow(_ color: String!) {
        
    }
    
    override init() {
        super.init()

        NSClassFromString("FrameworkLibAPI")?.registerAPIforNativeCalls(self)
    }

    func sendMessage(toMobileApp message: String) {
        UnityMessage().handleMessage(message: message)
    }
}
