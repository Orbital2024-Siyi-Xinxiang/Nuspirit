import SwiftUI
import Foundation

struct ContactDetailView: View {
    var contact: Contact

    var body: some View {
        VStack {
            Image(systemName: "person.crop.circle.fill")
                .resizable()
                .frame(width: 100, height: 100)
                .padding()
            Text(contact.name)
                .font(.title)
            Text(contact.email)
                .font(.subheadline)
            Text(contact.major)
                .font(.subheadline)
            Text(contact.year)
                .font(.subheadline)
        }
        .navigationTitle("Contact Details")
    }
}

struct EditContactView: View {
    @Binding var contact: Contact?

    var body: some View {
        if let contact = contact {
            Form {
                Section(header: Text("Edit Remark")) {
                    TextField("Remark", text: .constant(contact.remark))
                }
                Button("Save") {
                    // Save changes
                }
            }
            .navigationTitle("Edit Contact")
        }
    }
}
