import FirebaseFirestore

struct Asset: Identifiable, Codable, Equatable {
    @DocumentID var id: String? // Use String for id to align with Firestore document ID
    var cat: String
    var name: String
    var price: Double
    var icon: String // Assuming icon is the name of the icon resource

    // Implement Equatable protocol
    static func == (lhs: Asset, rhs: Asset) -> Bool {
        return lhs.id == rhs.id
    }
}
