import SwiftUI
import Firebase
import FirebaseFirestore
import FirebaseAuth

struct StudyTrackingService {
    
    public func getCurrentDateString() -> String {
        let date = Date()
        let dateFormatter = DateFormatter()
        dateFormatter.dateFormat = "yyyyMMdd"
        return dateFormatter.string(from: date)
    }
    
    public func getCurrentTimeInt() -> Int {
        let date = Date()
        let calendar = Calendar.current
        let hour = calendar.component(.hour, from: date)
        let minute = calendar.component(.minute, from: date)
        return hour * 100 + minute
    }
    
    public func getCurrentHrInt() -> Int {
        let date = Date()
        let calendar = Calendar.current
        let hour = calendar.component(.hour, from: date)
        let minute = calendar.component(.minute, from: date)
        return hour
    }
    
    public func getCurrentMinInt() -> Int {
        let date = Date()
        let calendar = Calendar.current
        let hour = calendar.component(.hour, from: date)
        let minute = calendar.component(.minute, from: date)
        return minute
    }
    
    public func updateStudyTime(numOfMin: Int, venueId: String) {
        let currentDate = getCurrentDateString()
        let currentTime = getCurrentTimeInt()
        let authService = FirebaseAuthService()
        let db = Firestore.firestore()
        let currentUserId = authService.getCurrentUid()
        
        guard !currentUserId.isEmpty else {
            print("No user is currently signed in.")
            return
        }
        
        let userStatsRef = db.collection("users_statistics").document(currentUserId)
        
        userStatsRef.getDocument { (document, error) in
            if let document = document, document.exists {
                
                
                if var data = document.data(), var mapData = data["studyTime"] as? [String: Int] {
                    mapData["totalMinutes", default: 0] += numOfMin
                    userStatsRef.updateData(["studyTime": mapData]) { err in
                        if let err = err {
                            print("Error updating document: \(err)")
                        } else {
                            print("Document successfully updated")
                        }
                    }
                } else {
                    userStatsRef.setData(["studyTime": ["totalMinutes": numOfMin]]) { err in
                        if let err = err {
                            print("Error setting document: \(err)")
                        } else {
                            print("Document successfully written")
                        }
                    }
                }
            } else {
                print("Document does not exist")
                
                userStatsRef.setData(["study_time_data": [currentDate : numOfMin]]) {
                    err in
                    if let err = err {
                        print("Error setting document: \(err)")
                    } else {
                     // do nothing
                    }
                }
            }
        }
    }
}
