import SwiftUI

struct ContentView: View {
    var body: some View {
        VStack {
            OrientationViewController(supportedOrientations: .landscape)
                .frame(width: 0, height: 0) // Hidden but functional
            NavigationView {
                ZStack() {
                    NavigationLink(destination: RegisterView()) {
                        Text("Sign In")
                            .font(Font.custom("Press Start 2P", size: 20))
                            .foregroundColor(Color(red: 0.23, green: 0.23, blue: 0.23))
                            .offset(x: 0, y: 3.50)
                        
                        Rectangle()
                            .foregroundColor(.clear)
                            .frame(width: 283, height: 60)
                            .background(Color(red: 0.61, green: 0.86, blue: 0.94).opacity(0.33))
                            .cornerRadius(20)
                            .offset(x: -0.50, y: -0.50)
                        
                        
                        
                    }
                    
                    ZStack() {
                        NavigationLink(destination: SignInView()) {
                            Text("Sign Up")
                                .font(Font.custom("Press Start 2P", size: 20))
                                .foregroundColor(Color(red: 0.23, green: 0.23, blue: 0.23))
                                .offset(x: -1, y: 3.50)
                            
                            Rectangle()
                                .foregroundColor(.clear)
                                .frame(width: 283, height: 60)
                                .background(Color(red: 0.61, green: 0.94, blue: 0.74).opacity(0.40))
                                .cornerRadius(20)
                                .offset(x: -0.50, y: -0.50)
                            
                            
                        }
                    }
                    
                    Rectangle()
                        .foregroundColor(.clear)
                        .frame(width: 209, height: 45)
                        .background(
                            AsyncImage(url: URL(string: "https://via.placeholder.com/209x45"))
                        )
                        .offset(x: -9, y: -253.50)
                    
                    Rectangle()
                        .foregroundColor(.clear)
                        .frame(width: 149, height: 181)
                        .background(
                            AsyncImage(url: URL(string: "https://via.placeholder.com/149x181"))
                        )
                        .offset(x: -23, y: -130.50)
                    
                    
                }
            }
            // Your content view code here
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
