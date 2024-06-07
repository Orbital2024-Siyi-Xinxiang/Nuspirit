import SwiftUI
import Firebase

struct OnBoardingView: View {
    @Binding var isOnboardingCompleted: Bool

    var users: [UserInfo] = UserData

    var body: some View {
        TabView {
            ForEach(users) { user in
                InfoCardView(user: user, isOnboardingCompleted: $isOnboardingCompleted)
            }
        }
        .tabViewStyle(PageTabViewStyle())
        .padding(.vertical, 20)
    }
}

