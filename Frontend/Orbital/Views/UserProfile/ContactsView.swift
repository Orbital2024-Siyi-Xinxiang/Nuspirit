//
//  Contact.swift
//  Orbital
//
//  Created by Xu Siyi on 14/6/24.
//

import Foundation
import SwiftUI
import Firebase
import FirebaseFirestore
import FirebaseAuth
import FirebaseStorage

struct ContactsView: View {
  @State private var contacts: [Contact] = []
  @State private var showingEdit = false
  @State private var contactToEdit: Contact?
  @State private var searchText = ""

  var body: some View {
    NavigationView {
      VStack {
        SearchBar(text: $searchText)
        List {
          ForEach(filteredContacts) { contact in
            HStack {
              if let profilePicture = contact.profilePicture {
                Image(uiImage: profilePicture)
                  .resizable()
                  .frame(width: 40, height: 40)
                  .clipShape(Circle())
                  .padding(.trailing, 8)
              } else {
                Image(systemName: "person.crop.circle.fill")
                  .resizable()
                  .frame(width: 40, height: 40)
                  .padding(.trailing, 8)
                  .foregroundColor(.blue)
              }
              VStack(alignment: .leading) {
                Text(contact.name)
                  .font(.headline)
                Text(contact.email)
                  .font(.subheadline)
                  .foregroundColor(.gray)
              }
              Spacer()
            }
            .contentShape(Rectangle())
            .onTapGesture {
              // Navigate to ContactDetailView
            }
            .swipeActions(edge: .trailing, allowsFullSwipe: false) {
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
        .listStyle(InsetGroupedListStyle())
        .navigationTitle("Contacts")
        .onAppear {
          loadContacts()
        }
        .sheet(isPresented: $showingEdit) {
          if let contactToEdit = contactToEdit {
            EditContactView(
              contact: $contacts[contacts.firstIndex(where: { $0.id == contactToEdit.id })!])
          }
        }
        .overlay(
          VStack {
            Spacer()
            HStack {
              Spacer()
              Button(action: {
                // Action to add a new contact
              }) {
                Image(systemName: "plus.circle.fill")
                  .resizable()
                  .frame(width: 60, height: 60)
                  .foregroundColor(.blue)
                  .padding()
              }
            }
          }
        )
      }
    }
  }

  private var filteredContacts: [Contact] {
    if searchText.isEmpty {
      return contacts
    } else {
      return contacts.filter { $0.name.contains(searchText) || $0.email.contains(searchText) }
    }
  }

  private func loadContacts() {
    // Fetch contacts from your database
    // Example data for preview
    contacts = [
      Contact(
        name: "Alice", email: "alice@example.com", major: "Computer Science", year: "Sophomore"),
      Contact(name: "Bob", email: "bob@example.com", major: "Mathematics", year: "Junior"),
      Contact(name: "Charlie", email: "charlie@example.com", major: "Physics", year: "Senior"),
    ]
  }
}

struct EditContactView: View {
  @Binding var contact: Contact
  @State private var selectedImage: UIImage?
  @State private var showingImagePicker = false

  var body: some View {
    NavigationView {
      Form {
        Section(header: Text("Edit Remark")) {
          TextField("Remark", text: $contact.remark)
        }
        Section(header: Text("Profile Picture")) {
          if let profilePicture = selectedImage {
            Image(uiImage: profilePicture)
              .resizable()
              .frame(width: 100, height: 100)
              .clipShape(Circle())
              .onTapGesture {
                showingImagePicker.toggle()
              }
          } else {
            Image(systemName: "person.crop.circle.fill")
              .resizable()
              .frame(width: 100, height: 100)
              .foregroundColor(.blue)
              .onTapGesture {
                showingImagePicker.toggle()
              }
          }
        }
        Button(action: {
          if let selectedImage = selectedImage {
            contact.profilePicture = selectedImage
          }
          // Save changes
        }) {
          Text("Save")
            .frame(maxWidth: .infinity, alignment: .center)
            .padding()
            .background(Color.blue)
            .foregroundColor(.white)
            .cornerRadius(8)
        }
      }
      .navigationTitle("Edit Contact")
      .sheet(isPresented: $showingImagePicker) {
          ImagePicker(sourceType: .photoLibrary) { image in
              uploadProfileImage(image: image)
          }
        }
    }
  }
    func uploadProfileImage(image: UIImage) {
        let storageRef = Storage.storage().reference()
        let userID = Auth.auth().currentUser?.uid ?? "defaultUserID"
        let imageRef = storageRef.child("profile_images/\(userID).jpg")

        guard let imageData = image.jpegData(compressionQuality: 0.75) else { return }

        imageRef.putData(imageData, metadata: nil) { (metadata, error) in
            if let error = error {
                print("Error uploading image: \(error)")
                return
            }

            imageRef.downloadURL { (url, error) in
                if let error = error {
                    print("Error getting download URL: \(error)")
                    return
                }

                guard let downloadURL = url else { return }
                let db = Firestore.firestore()
                db.collection("users_profiles").document(userID).updateData(["profileImageURL": downloadURL.absoluteString]) { error in
                    if let error = error {
                        print("Error updating profile image URL: \(error)")
                    } else {
                        print("Profile image URL successfully updated")
                        self.selectedImage = image
                        // assign the new profile image URL to the selectedImage property
                    }
                }
            }
        }
    }
}

struct SearchBar: View {
  @Binding var text: String

  var body: some View {
    HStack {
      Image(systemName: "magnifyingglass")
        .foregroundColor(.gray)
      TextField("Search contacts...", text: $text)
        .padding(7)
        .background(Color(.systemGray6))
        .cornerRadius(8)
    }
    .padding(.horizontal)
  }
}
