import Foundation
import FirebaseFirestore
import Combine
import UIKit

class AssetFetchingService: ObservableObject {
    @Published var furnitureAssets: [Asset] = []
    @Published var housingAssets: [Asset] = []
    @Published var plantAssets: [Asset] = []
    @Published var animalAssets: [Asset] = []
    @Published var avatarDesignAssets: [Asset] = []

    var categories: [String] {
        return ["Furniture", "Housing", "Plant", "Animal", "Avatar"]
    }

    private var db = Firestore.firestore()
    private var listener: ListenerRegistration?

    init() {
        initialFetch()
    }

    deinit {
        listener?.remove()
    }

    func fetchAssets() {
        // Set up listener for real-time updates
        listener = db.collection("assets").addSnapshotListener { [weak self] (snapshot, error) in
            guard let self = self else { return }
            if let error = error {
                print("Error fetching assets: \(error)")
                return
            }

            self.processSnapshot(snapshot)
        }
    }

    private func initialFetch() {
        db.collection("assets").getDocuments { [weak self] (snapshot, error) in
            guard let self = self else { return }
            if let error = error {
                print("Error fetching assets: \(error)")
                return
            }

            self.processSnapshot(snapshot)
            self.fetchAssets()
        }
    }

    private func processSnapshot(_ snapshot: QuerySnapshot?) {
        guard let documents = snapshot?.documents else {
            print("No documents in snapshot")
            return
        }

        var newFurnitureAssets: [Asset] = []
        var newHousingAssets: [Asset] = []
        var newPlantAssets: [Asset] = []
        var newAnimalAssets: [Asset] = []
        var newAvatarDesignAssets: [Asset] = []

        for document in documents {
            do {
                let data = document.data()
                let asset = Asset(
                    id: document.documentID,
                    cat: data["category"] as? String ?? "",
                    name: data["name"] as? String ?? "",
                    price: data["price"] as? Double ?? 0.0,
                    icon: document.documentID
                )
                guard data["is_public"] as? Bool == true else { continue }

                switch asset.cat {
                case "Furniture":
                    newFurnitureAssets.append(asset)
                case "Housing":
                    newHousingAssets.append(asset)
                case "Plant":
                    newPlantAssets.append(asset)
                case "Animal":
                    newAnimalAssets.append(asset)
                case "Avatar":
                    newAvatarDesignAssets.append(asset)
                default:
                    break
                }
            } catch let error {
                print("Error decoding asset: \(error)")
            }
        }

        self.furnitureAssets = newFurnitureAssets
        self.housingAssets = newHousingAssets
        self.plantAssets = newPlantAssets
        self.animalAssets = newAnimalAssets
        self.avatarDesignAssets = newAvatarDesignAssets

        // Fetch images for all assets
        self.fetchImages(for: newFurnitureAssets + newHousingAssets + newPlantAssets + newAnimalAssets + newAvatarDesignAssets)
    }

    private func fetchImages(for assets: [Asset]) {
        let storageService = FirebaseStorageService()
        for asset in assets {
            storageService.downloadImageAsset(name: asset.icon) { image in
                if let image = image {
                    self.saveImageToLocalStorage(name: asset.icon, image: image)
                }
            }
        }
    }

    private func saveImageToLocalStorage(name: String, image: UIImage) {
        guard let data = image.pngData() else { return }
        let filename = getDocumentsDirectory().appendingPathComponent("\(name).png")
        try? data.write(to: filename)
    }

    private func getDocumentsDirectory() -> URL {
        return FileManager.default.urls(for: .documentDirectory, in: .userDomainMask)[0]
    }

    func getAssets(for category: String) -> [Asset] {
        switch category {
        case "Furniture":
            return furnitureAssets
        case "Housing":
            return housingAssets
        case "Plant":
            return plantAssets
        case "Animal":
            return animalAssets
        case "Avatar":
            return avatarDesignAssets
        default:
            return []
        }
    }
}
