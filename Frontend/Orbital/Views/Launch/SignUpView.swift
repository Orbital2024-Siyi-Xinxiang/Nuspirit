import SwiftUI
import FirebaseAuth
import FirebaseAuthUI

struct SignUpView: View {
    var body: some View {
        SignUpViewControllerWrapper()
    }
}

struct SignUpViewControllerWrapper: UIViewControllerRepresentable {
    func makeUIViewController(context: Context) -> SignInViewController {
        let viewController = SignInViewController()
        return viewController
    }
    
    func updateUIViewController(_ uiViewController: SignInViewController, context: Context) {}
    


}

struct SignUpView_Previews: PreviewProvider {
    static var previews: some View {
        SignUpView()
    }
}
