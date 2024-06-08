import SwiftUI
import FirebaseAuth
import FirebaseCore
import FirebaseFirestore


struct InfoCardView: View {
    // MARK: - PROPERTIES
    
    var user: UserInfo
    @Binding var isOnboardingCompleted: Bool
    @Binding var currentCardIndex: Int

    @State private var isAnimating: Bool = false
    @State private var nickname: String = ""
    @State private var selectedStatus: String = "Alumni"
    @State private var selectedLevel: String = "Undergraduate"
    @State private var selectedFaculty: String = ""
    @State private var selectedMajor: String = ""
    
    // MARK: - BODY
    
    var body: some View {
        ZStack {
            VStack(spacing: 20) {
                // USER: IMAGE
                Image(user.image)
                    .resizable()
                    .scaledToFit()
                    .shadow(color: Color(red: 0, green: 0, blue: 0, opacity: 0.15), radius: 8, x: 6, y: 8)
                    .scaleEffect(isAnimating ? 1.0 : 0.6)
                
                // USER: TITLE
                Text(user.title)
                    .foregroundColor(Color.white)
                    .font(.largeTitle)
                    .fontWeight(.heavy)
                    .shadow(color: Color(red: 0, green: 0, blue: 0, opacity: 0.15), radius: 2, x: 2, y: 2)
                
                // USER: HEADLINE
                Text(user.headline)
                    .foregroundColor(Color.white)
                    .multilineTextAlignment(.center)
                    .padding(.horizontal, 16)
                    .frame(maxWidth: 480)
                
                // Conditional Inputs
                if user.data == "nickname" {
                    TextField("Enter your preferred display name", text: $nickname)
                        .textFieldStyle(RoundedBorderTextFieldStyle())
                        .padding()
                } else if user.data == "isStudentOrNot" {
                    Picker("Select your status", selection: $selectedStatus) {
                        Text("Alumni").tag("Alumni")
                        Text("Current Student").tag("Current Student")
                        Text("Visitor").tag("Visitor")
                    }
                    .pickerStyle(SegmentedPickerStyle())
                    .padding()
                    
                } else if user.data == "levelOfStudy" {
                    Picker("Select your level of study", selection: $selectedLevel) {
                        Text("Undergraduate").tag("Undergraduate")
                        Text("Postgraduate").tag("Postgraduate")
                        
                    }
                    .pickerStyle(SegmentedPickerStyle())
                    .padding()
                } else if user.data == "faculty" /*&& selectedStatus == "Current Student"*/ {
                    TextField("Search or select your faculty", text: $selectedFaculty)
                        .textFieldStyle(RoundedBorderTextFieldStyle())
                        .padding()
                    Picker("Select your faculty", selection: $selectedFaculty) {
                        Text("FOS").tag("FOS")
                        Text("FASS").tag("FASS")
                        Text("SOC").tag("SOC")
                    }
                    .pickerStyle(MenuPickerStyle())
                    .padding()
                } else if user.data == "major" /*&& selectedStatus == "Current Student"*/ {
                    TextField("Search or select your major", text: $selectedMajor)
                        .textFieldStyle(RoundedBorderTextFieldStyle())
                        .padding()
                }
                
                if currentCardIndex == totalCards - 1 {
                    StartButtonView(isOnboardingCompleted: $isOnboardingCompleted, nickname: $nickname, selectedStatus: $selectedStatus, selectedLevel: $selectedLevel, selectedFaculty: $selectedFaculty, selectedMajor: $selectedMajor, currentCardIndex: $currentCardIndex)
                } 
            } //: VSTACK
        } //: ZSTACK
        .onAppear {
            withAnimation(.easeOut(duration: 0.5)) {
                isAnimating = true
            }
        }
        .frame(minWidth: 0, maxWidth: .infinity, minHeight: 0, maxHeight: .infinity, alignment: .center)
        .background(LinearGradient(gradient: Gradient(colors: user.gradientColors), startPoint: .top, endPoint: .bottom))
        .cornerRadius(20)
        .padding(.horizontal, 20)
    }
    

    
}

// Add totalCards variable to represent the total number of cards
let totalCards = 5

