import SwiftUI
import Firebase
import FirebaseFirestore

struct OnBoardingView: View {
    @AppStorage("isOnboardingCompleted") var isOnboardingCompleted: Bool = false
    @State private var userExists: Bool = false
    @State private var isLoading: Bool = true

    var users: [UserInfo] = UserData

    var body: some View {
        Group {
            if isLoading {
                ProgressView("Loading...")
            } else if !userExists {
                TabView {
                    ForEach(users) { user in
                        InfoCardView(user: user)
                    }
                }
                .tabViewStyle(PageTabViewStyle())
                .padding(.vertical, 20)
            } else {
                MainMapView()
            }
        }
        .onAppear {
            checkUserExists()
        }
    }

    func checkUserExists() {
        guard let userId = Auth.auth().currentUser?.uid else {
            isLoading = false
            return
        }

        let db = Firestore.firestore()
        let docRef = db.collection("users").document(userId)
        
        docRef.getDocument { (document, error) in
            if let document = document, document.exists {
                userExists = true
            } else {
                userExists = false
            }
            isLoading = false
        }
    }
}
