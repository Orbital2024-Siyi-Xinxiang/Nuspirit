import Foundation

struct Booking: Identifiable {
    var id = UUID()
    var bookingTime: Date
    var bookingSlot: String
    var venueName: String
    var bookableName: String
}
