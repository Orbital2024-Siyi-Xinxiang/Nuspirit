import SwiftUI
import Firebase

struct OnBoardingView: View {
    @Binding var isOnboardingCompleted: Bool
    @State private var currentCardIndex = 0
    var users: [UserInfo] = UserData

    var body: some View {
        TabView(selection: $currentCardIndex) {
            ForEach(0..<users.count) { index in
                InfoCardView(user: users[index], isOnboardingCompleted: $isOnboardingCompleted, currentCardIndex: $currentCardIndex)
                    .tag(index)
            }
        }
        .tabViewStyle(PageTabViewStyle())
        .padding(.vertical, 20)
    }
}
