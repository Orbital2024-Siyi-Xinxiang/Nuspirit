import SwiftUI
import Firebase
import FirebaseFirestore

struct StartButtonView: View {
    @AppStorage("isOnboardingCompleted") var isOnboardingCompleted: Bool?
    
    @State private var nickname: String = ""
    @State private var selectedStatus: String = "Alumni"
    @State private var selectedLevel: String = "Undergraduate"
    @State private var selectedFaculty: String = ""
    @State private var selectedMajor: String = ""
    
    var body: some View {
        Button(action: {
            saveUserData()
            isOnboardingCompleted = true
        }) {
            HStack(spacing: 8) {
                Text("Start")
                Image(systemName: "arrow.right.circle")
                    .imageScale(.large)
            }
            .padding(.horizontal, 16)
            .padding(.vertical, 10)
            .background(
                Capsule().strokeBorder(Color.white, lineWidth: 1.25)
            )
        }
        .accentColor(Color.white)
    }

    func saveUserData() {
        guard let userId = Auth.auth().currentUser?.uid else { return }

        let db = Firestore.firestore()
        db.collection("users").document(userId).setData([
            "nickname": nickname,
            "status": selectedStatus,
            "level": selectedLevel,
            "faculty": selectedFaculty,
            "major": selectedMajor
        ]) { error in
            if let error = error {
                print("Error writing document: \(error)")
            } else {
                print("Document successfully written!")
            }
        }
    }
}
