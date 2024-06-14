import SwiftUI
import Firebase

struct OnBoardingView: View {
    @Binding var isOnboardingCompleted: Bool
    @State private var currentCardIndex = 0
    
    @State private var nickname: String = ""
    @State private var selectedStatus: String = "Visitor"
    @State private var selectedLevel: String = "Undergraduate"
    @State private var selectedFaculty: String = ""
    @State private var selectedMajor: String = ""

    var users: [UserInfo] = UserData

    var body: some View {
        TabView(selection: $currentCardIndex) {
            ForEach(0..<users.count) { index in
                InfoCardView(
                    user: users[index],
                    isOnboardingCompleted: $isOnboardingCompleted,
                    currentCardIndex: $currentCardIndex,
                    nickname: $nickname,
                    selectedStatus: $selectedStatus,
                    selectedLevel: $selectedLevel,
                    selectedFaculty: $selectedFaculty,
                    selectedMajor: $selectedMajor
                )
                .tag(index)
            }
        }
        .tabViewStyle(PageTabViewStyle())
        .padding(.vertical, 20)
    }
}
