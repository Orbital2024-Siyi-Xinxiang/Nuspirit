import SwiftUI

struct ContactsView: View {
    @State private var contacts: [String] = [] // Replace with your data model

    var body: some View {
        List(contacts, id: \.self) { contact in
            Text(contact) // Customize this as per your data model
        }
        .navigationBarTitle("Contacts", displayMode: .inline)
        .onAppear {
            loadContacts()
        }
    }

    private func loadContacts() {
        // Fetch contacts from your database
        // Example data for preview
        contacts = ["Alice", "Bob", "Charlie"]
    }
}

struct ContactsView_Previews: PreviewProvider {
    static var previews: some View {
        ContactsView()
    }
}
