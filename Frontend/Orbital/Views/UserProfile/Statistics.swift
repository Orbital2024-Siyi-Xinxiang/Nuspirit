//
//  PersonalStudyStatistics.swift
//  Orbital
//
//  Created by Xu Siyi on 23/6/24.
//

import SwiftUI

// TODO: after clicking statistics summary can direct to personal study statistic page
struct Statistics: View {
    var body: some View {
        VStack {
            // Header
            Text("Personal Study Statistics")
                .font(.largeTitle)
                .fontWeight(.bold)
                .padding(.top)
            
            // Total Study Time
            HStack {
                VStack(alignment: .leading) {
                    Text("Total Study Time")
                        .font(.headline)
                        .foregroundColor(.gray)
                    Text("150 hours")
                        .font(.title)
                        .fontWeight(.bold)
                }
                Spacer()
            }
            .padding()
            
            // Average Study Time
            HStack {
                VStack(alignment: .leading) {
                    Text("Average Study Time")
                        .font(.headline)
                        .foregroundColor(.gray)
                    Text("2 hours/day")
                        .font(.title)
                        .fontWeight(.bold)
                }
                Spacer()
            }
            .padding()
            
            // Progress Bar
            VStack {
                Text("Weekly Progress")
                    .font(.headline)
                    .foregroundColor(.gray)
                ProgressBar(progress: 0.7)
                    .frame(height: 20)
                    .padding()
            }
            
            // Recent Study Sessions
            VStack(alignment: .leading) {
                Text("Recent Study Sessions")
                    .font(.headline)
                    .padding(.bottom, 5)
                
                List {
                    StudySessionView(sessionDate: "June 22, 2024", studyTime: "3 hours")
                    StudySessionView(sessionDate: "June 21, 2024", studyTime: "2.5 hours")
                    StudySessionView(sessionDate: "June 20, 2024", studyTime: "2 hours")
                }
                .listStyle(PlainListStyle())
            }
            .padding()
            
            Spacer()
        }
        .padding()
    }
}

struct ProgressBar: View {
    var progress: Float
    
    var body: some View {
        ZStack(alignment: .leading) {
            Rectangle()
                .frame(maxWidth: .infinity)
                .frame(height: 20)
                .opacity(0.3)
                .foregroundColor(Color(UIColor.systemTeal))
            
            Rectangle()
                .frame(width: CGFloat(progress) * UIScreen.main.bounds.width)
                .frame(height: 20)
                .foregroundColor(Color(UIColor.systemBlue))
                .animation(.linear)
        }
        .cornerRadius(10)
    }
}

struct StudySessionView: View {
    var sessionDate: String
    var studyTime: String
    
    var body: some View {
        HStack {
            VStack(alignment: .leading) {
                Text(sessionDate)
                    .font(.headline)
                Text(studyTime)
                    .font(.subheadline)
                    .foregroundColor(.gray)
            }
            Spacer()
        }
        .padding(.vertical, 5)
    }
}
