import SwiftUI
import MapKit
import CoreLocation
import Foundation


struct MainMapView: View {
    @Binding var showSettingsOverlay: Bool

    var body: some View {
        NavigationView {
            ZStack {
                MapContentView()
                
                if showSettingsOverlay {
                    SettingsOverlay(showSettingsOverlay: $showSettingsOverlay)
                }
                
                HStack {
                    Spacer()
                    VStack(spacing: 20) {
                        NavigationLink(destination: FurnitureMarketView()) {
                            VStack {
                                Image(systemName: "cart.fill")
                                    .resizable()
                                    .frame(width: 50, height: 50)
                                    .padding()
                                    .background(Color.blue)
                                    .foregroundColor(.white)
                                    .clipShape(Circle())
                                Text("To Furniture Market")
                                    .foregroundColor(.blue)
                            }
                        }
                        .padding()

                        Button(action: {
//                            Unity.shared.show() 
                            // for launching Unity here
                            
                        })  {
                            VStack {
                                Image(systemName: "leaf.arrow.circlepath")
                                    .resizable()
                                    .frame(width: 50, height: 50)
                                    .padding()
                                    .background(Color.green)
                                    .foregroundColor(.white)
                                    .clipShape(Circle())
                                Text("My Island")
                                    .foregroundColor(.green)
                            }
                        }
                        .padding()
                        Spacer()
                    }
                    .padding()
                }
            }
            .navigationBarHidden(true)
        }
        .navigationViewStyle(StackNavigationViewStyle())
    }
}

