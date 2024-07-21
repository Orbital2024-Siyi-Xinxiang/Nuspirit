//
//  MyBookingView.swift
//  Orbital
//
//  Created by Xu Siyi on 27/6/24.
//

import SwiftUI
import Foundation

struct MyBookingsView: View {
    @ObservedObject var bookingData = BookingData()

    // TODO: connect to firebase database to retrieve user booking data.
    // TODO: add button beside each my booking item to navigate to BuildingView(pass building id to it)
    // TODO: add starting level logic
    var body: some View {
        NavigationView {
            List(bookingData.bookings) { booking in
                VStack(alignment: .leading) {
                    Text("Venue: \(booking.venueName)")
                        .font(.headline)
                    Text("Bookable: \(booking.bookableName)")
                        .font(.subheadline)
                    Text("Slot: \(booking.bookingSlot)")
                        .font(.subheadline)
                    Text("Time: \(formattedDate(booking.bookingTime))")
                        .font(.subheadline)
                }
                .padding(.vertical, 4)
            }
            .navigationTitle("My Bookings")
        }
    }

    private func formattedDate(_ date: Date) -> String {
        let formatter = DateFormatter()
        formatter.dateStyle = .short
        formatter.timeStyle = .short
        return formatter.string(from: date)
    }
}

#Preview {
    MyBookingsView()
}




class BookingData: ObservableObject {
    @Published var bookings: [Booking] = [
        Booking(bookingTime: Date(), bookingSlot: "09:00 - 10:00", venueName: "Conference Room A", bookableName: "Projector"),
        Booking(bookingTime: Date(), bookingSlot: "11:00 - 12:00", venueName: "Meeting Room B", bookableName: "Whiteboard"),
        Booking(bookingTime: Date(), bookingSlot: "13:00 - 14:00", venueName: "Auditorium", bookableName: "Sound System"),
    ]
}

