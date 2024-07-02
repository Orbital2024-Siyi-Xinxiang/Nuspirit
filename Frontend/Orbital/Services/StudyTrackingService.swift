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
        return hour
    }
    
    public func getCurrentMinInt() -> Int {
        let date = Date()
        let calendar = Calendar.current
        let minute = calendar.component(.minute, from: date)
        return minute
    }
    
    public func updateStudyTime(numOfMin: Int, venueId: String) {
        let currentDate = getCurrentDateString()
        let authService = FirebaseAuthService()
        let db = Firestore.firestore()
        let currentUserId = authService.getCurrentUid()
        
        guard !currentUserId.isEmpty else {
            print("No user is currently signed in.")
            return
        }
        
        let userStatsRef = db.collection("users_statistics").document(currentUserId)
        
        userStatsRef.getDocument { (document, error) in
            var studyTimeData = [String: Int]()
            var studyVenuesData = [String: Int]()
            
            if let document = document, document.exists {
                if let data = document.data() {
                    studyTimeData = data["study_time_data"] as? [String: Int] ?? [:]
                    studyVenuesData = data["study_venues_data"] as? [String: Int] ?? [:]
                }
            }
            
            // Update study time data
            studyTimeData[currentDate, default: 0] += numOfMin
            // Update study venues data
            studyVenuesData[venueId, default: 0] += numOfMin
            
            userStatsRef.updateData([
                "study_time_data": studyTimeData,
                "study_venues_data": studyVenuesData
            ]) { err in
                if let err = err {
                    print("Error updating document: \(err)")
                } else {
                    print("Document successfully updated")
                }
            }
        }
    }
}
