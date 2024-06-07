import SwiftUI
import Firebase
import FirebaseFirestore

struct InfoCardView: View {
    // MARK: - PROPERTIES
    
    var user: UserInfo
    @Binding var isOnboardingCompleted: Bool
    
    @State private var isAnimating: Bool = false
    @State private var nickname: String = ""
    @State private var selectedStatus: String = "Alumni"
    @State private var selectedLevel: String = "Undergraduate"
    @State private var selectedFaculty: String = ""
    @State private var selectedMajor: String = ""
    
    // MARK: - BODY
    
    var body: some View {
        NavigationView {
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
                    } else if user.data == "faculty" && selectedStatus == "Current Student" {
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
                    } else if user.data == "major" && selectedStatus == "Current Student" {
                        TextField("Search or select your major", text: $selectedMajor)
                            .textFieldStyle(RoundedBorderTextFieldStyle())
                            .padding()
                    }
                    
                    // BUTTON: SAVE
                    Button(action: {
                        saveUserData()
                    }) {
                        HStack(spacing: 8) {
                            Text("Save")
                            Image(systemName: "checkmark.circle")
                                .imageScale(.large)
                        }
                        .padding(.horizontal, 16)
                        .padding(.vertical, 10)
                        .background(
                            Capsule().strokeBorder(Color.green, lineWidth: 1.25)
                        )
                    }
                    .accentColor(Color.green)
                    
                    // BUTTON: START
                    StartButtonView(isOnboardingCompleted: $isOnboardingCompleted, nickname: $nickname, selectedStatus: $selectedStatus, selectedLevel: $selectedLevel, selectedFaculty: $selectedFaculty, selectedMajor: $selectedMajor)
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
    
    func saveUserData() {
        guard let userId = Auth.auth().currentUser?.uid else { return }

        let db = Firestore.firestore()
        db.collection("users_profiles").document(userId).setData([
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
