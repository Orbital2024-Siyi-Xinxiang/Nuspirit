import SwiftUI
import Firebase
import FirebaseFirestore

struct StartButtonView: View {
    @Binding var isOnboardingCompleted: Bool
    @Binding var nickname: String
    @Binding var selectedStatus: String
    @Binding var selectedLevel: String
    @Binding var selectedFaculty: String
    @Binding var selectedMajor: String
    @Binding var currentCardIndex: Int

    var body: some View {
        Button(action: {
            saveUserData(currentCardIndex: currentCardIndex)
//            if currentCardIndex == totalCards - 1 {
            isOnboardingCompleted = true
            SignUpViewController().navigateToMainAppView()
//            } else {
//                currentCardIndex += 1
//            }
        }) {
            HStack(spacing: 8) {
                Text(currentCardIndex == totalCards - 1 ? "Start" : "Continue")
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

    func saveUserData(currentCardIndex: Int) {
        guard let userId = Auth.auth().currentUser?.uid else { return }
        
//        print(nickname, selectedStatus, selectedLevel, selectedFaculty, selectedMajor)
        let db = Firestore.firestore()
        if (currentCardIndex == 0) {
            db.collection("users_profiles").document(userId).setData([
                "nickname": nickname,
            ]) { error in
                if let error = error {
                    print("Error writing document: \(error)")
                } else {
                    print("Document successfully written!")
                }
            }
        } else if (currentCardIndex == 1) {
            db.collection("users_profiles").document(userId).setData([
                "status": selectedStatus,
 
            ]) { error in
                if let error = error {
                    print("Error writing document: \(error)")
                } else {
                    print("Document successfully written!")
                }
            }
        } else if (currentCardIndex == 2) {
            db.collection("users_profiles").document(userId).setData([

                "level": selectedLevel
            ]) { error in
                if let error = error {
                    print("Error writing document: \(error)")
                } else {
                    print("Document successfully written!")
                }
            }
        } else if (currentCardIndex == 3) {
            db.collection("users_profiles").document(userId).setData([

                "faculty": selectedFaculty,

            ]) { error in
                if let error = error {
                    print("Error writing document: \(error)")
                } else {
                    print("Document successfully written!")
                }
            }
        } else if (currentCardIndex == 4) {
            db.collection("users_profiles").document(userId).setData([
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
}
