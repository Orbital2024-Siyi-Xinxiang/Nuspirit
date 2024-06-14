
import SwiftUI

struct ContactDetailView: View {
    var contact: Contact

    var body: some View {
        VStack(spacing: 16) {
            if let profilePicture = contact.profilePicture {
                Image(uiImage: profilePicture)
                    .resizable()
                    .frame(width: 100, height: 100)
                    .clipShape(Circle())
                    .padding()
            } else {
                Image(systemName: "person.crop.circle.fill")
                    .resizable()
                    .frame(width: 100, height: 100)
                    .padding()
                    .foregroundColor(.blue)
            }
            Text(contact.name)
                .font(.title)
                .fontWeight(.bold)
            Text(contact.email)
                .font(.subheadline)
                .foregroundColor(.gray)
            Text(contact.major)
                .font(.subheadline)
                .foregroundColor(.gray)
            Text(contact.year)
                .font(.subheadline)
                .foregroundColor(.gray)
        }
        .padding()
        .background(Color(.systemGroupedBackground))
        .cornerRadius(10)
        .shadow(radius: 5)
        .navigationTitle("Contact Details")
    }
}
