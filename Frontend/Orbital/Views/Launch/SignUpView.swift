import SwiftUI

struct SignUpView: View {
    var body: some View {
        SignUpViewControllerWrapper()
    }
}

struct SignUpViewControllerWrapper: UIViewControllerRepresentable {
    func makeUIViewController(context: Context) -> SignUpViewController {
        let viewController = SignUpViewController()
        return viewController
    }
    
    func updateUIViewController(_ uiViewController: SignUpViewController, context: Context) {
        // Do nothing
    }
}

struct SignUpView_Previews: PreviewProvider {
    static var previews: some View {
        SignUpView()
    }
}
