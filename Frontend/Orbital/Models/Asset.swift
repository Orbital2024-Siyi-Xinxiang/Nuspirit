//
//  Asset.swift
//  Orbital
//
//  Created by Xu Siyi on 18/5/24.
//

import Foundation


struct Asset: Identifiable, Equatable {
    var id: Int
    var cat: String
    var name: String
    var price: Double
    var icon: String

    static func ==(lhs: Asset, rhs: Asset) -> Bool {
        return lhs.id == rhs.id
    }
}

let furnitureAssets = [
    Asset(id: 1, cat: "Furniture", name: "Sofa", price: 100.0, icon: "sofa"),
    Asset(id: 2, cat: "Furniture", name: "Table", price: 50.0, icon: "table"),
    Asset(id: 3, cat: "Furniture", name: "Chair", price: 20.0, icon: "chair"),
    Asset(id: 4, cat: "Furniture", name: "Bed", price: 150.0, icon: "bed"),
    Asset(id: 5, cat: "Furniture", name: "Wardrobe", price: 80.0, icon: "wardrobe"),
    Asset(id: 6, cat: "Furniture", name: "Bookshelf", price: 40.0, icon: "bookshelf"),
    Asset(id: 7, cat: "Furniture", name: "Dining Table", price: 60.0, icon: "diningtable"),
    Asset(id: 8, cat: "Furniture", name: "Coffee Table", price: 30.0, icon: "coffeetable"),
    Asset(id: 9, cat: "Furniture", name: "TV Console", price: 70.0, icon: "tvconsole"),
    Asset(id: 10, cat: "Furniture", name: "Side Table", price: 25.0, icon: "sidetable"),
]

// create some housing assets
let housingAssets = [
    Asset(id: 11, cat: "Housing", name: "HDB", price: 100000.0, icon: "hdb"),
    Asset(id: 12, cat: "Housing", name: "Condo", price: 500000.0, icon: "condo"),
    Asset(id: 13, cat: "Housing", name: "Landed", price: 1000000.0, icon: "landed"),
    Asset(id: 14, cat: "Housing", name: "Studio", price: 200000.0, icon: "studio"),
    Asset(id: 15, cat: "Housing", name: "Apartment", price: 300000.0, icon: "apartment"),
    Asset(id: 16, cat: "Housing", name: "Penthouse", price: 800000.0, icon: "penthouse"),
    Asset(id: 17, cat: "Housing", name: "Townhouse", price: 400000.0, icon: "townhouse"),
    Asset(id: 18, cat: "Housing", name: "Bungalow", price: 1200000.0, icon: "bungalow"),
    Asset(id: 19, cat: "Housing", name: "Cluster House", price: 600000.0, icon: "clusterhouse"),
    Asset(id: 20, cat: "Housing", name: "Shophouse", price: 700000.0, icon: "shophouse"),
]

let plantAssets = [
    Asset(id: 21, cat: "Plant", name: "Aloe Vera", price: 10.0, icon: "aloe"),
    Asset(id: 22, cat: "Plant", name: "Cactus", price: 5.0, icon: "cactus"),
    Asset(id: 23, cat: "Plant", name: "Fern", price: 8.0, icon: "fern"),
    Asset(id: 24, cat: "Plant", name: "Lavender", price: 12.0, icon: "lavender"),
    Asset(id: 25, cat: "Plant", name: "Orchid", price: 15.0, icon: "orchid"),
    Asset(id: 26, cat: "Plant", name: "Palm", price: 20.0, icon: "palm"),
    Asset(id: 27, cat: "Plant", name: "Rose", price: 18.0, icon: "rose"),
    Asset(id: 28, cat: "Plant", name: "Succulent", price: 6.0, icon: "succulent"),
    Asset(id: 29, cat: "Plant", name: "Tulip", price: 14.0, icon: "tulip"),
    Asset(id: 30, cat: "Plant", name: "Violet", price: 9.0, icon: "violet"),
]

let animalAssets = [
    Asset(id: 31, cat: "Animal", name: "Cat", price: 50.0, icon: "cat"),
    Asset(id: 32, cat: "Animal", name: "Dog", price: 100.0, icon: "dog"),
    Asset(id: 33, cat: "Animal", name: "Rabbit", price: 30.0, icon: "rabbit"),
    Asset(id: 34, cat: "Animal", name: "Hamster", price: 10.0, icon: "hamster"),
    Asset(id: 35, cat: "Animal", name: "Parrot", price: 80.0, icon: "parrot"),
    Asset(id: 36, cat: "Animal", name: "Fish", price: 5.0, icon: "fish"),
    Asset(id: 37, cat: "Animal", name: "Turtle", price: 20.0, icon: "turtle"),
    Asset(id: 38, cat: "Animal", name: "Guinea Pig", price: 15.0, icon: "guineapig"),
    Asset(id: 39, cat: "Animal", name: "Hedgehog", price: 25.0, icon: "hedgehog"),
    Asset(id: 40, cat: "Animal", name: "Chinchilla", price: 35.0, icon: "chinchilla"),
]

let avatarDesignAssets = [
    Asset(id: 41, cat: "Avatar", name: "HairPonyTailBrown", price: 0.0, icon: "HairPonyTailBrown"),
    Asset(id: 42, cat: "Avatar", name: "HairPonyTailBlonde", price: 0.0, icon: "HairPonyTailBlonde"),
    Asset(id: 43, cat: "Avatar", name: "HairPonyTailBlack", price: 0.0, icon: "HairPonyTailBlack"),
]
