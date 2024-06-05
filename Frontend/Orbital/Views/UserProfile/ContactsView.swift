import SwiftUI

struct Contact: Identifiable {
    let id = UUID()
    let name: String
    let email: String
    let major: String
    let year: String
    var remark: String = ""
}

struct ContactsView: View {
    @State private var contacts: [Contact] = []
    @State private var showingEdit = false
    @State private var contactToEdit: Contact?

    var body: some View {
        NavigationView {
            List {
                ForEach(contacts) { contact in
                    HStack {
                        Text(contact.name)
                        Spacer()
                    }
                    .contentShape(Rectangle())
                    .onTapGesture {
                        // Navigate to ContactDetailView
                    }
                    .swipeActions {
                        Button {
                            contactToEdit = contact
                            showingEdit.toggle()
                        } label: {
                            Label("Edit", systemImage: "pencil")
                        }
                        .tint(.yellow)

                        Button {
                            // Navigate to chat view
                        } label: {
                            Label("Chat", systemImage: "message")
                        }
                        .tint(.blue)

                        Button(role: .destructive) {
                            if let index = contacts.firstIndex(where: { $0.id == contact.id }) {
                                contacts.remove(at: index)
                            }
                        } label: {
                            Label("Delete", systemImage: "trash")
                        }
                    }
                }
            }
            .navigationTitle("Contacts")
            .onAppear {
                loadContacts()
            }
            .sheet(isPresented: $showingEdit) {
                EditContactView(contact: $contactToEdit)
            }
        }
    }

    private func loadContacts() {
        // Fetch contacts from your database
        // Example data for preview
        contacts = [
            Contact(name: "Alice", email: "alice@example.com", major: "Computer Science", year: "Sophomore"),
            Contact(name: "Bob", email: "bob@example.com", major: "Mathematics", year: "Junior"),
            Contact(name: "Charlie", email: "charlie@example.com", major: "Physics", year: "Senior")
        ]
    }
}
