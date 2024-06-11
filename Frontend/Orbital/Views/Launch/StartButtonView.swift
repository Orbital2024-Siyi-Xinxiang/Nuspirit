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
//            saveUserData(currentCardIndex: currentCardIndex)
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


}
