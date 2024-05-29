const admin = require('firebase-admin');
const serviceAccount = require('../Backend/config/firebaseAccountKey.json');
const jsonData = require('ThirdParty/key_buildings_data.json');

admin.initializeApp({
    credential: admin.credential.cert(serviceAccount),
    databaseURL: 'https://orbital2024-9f1b1.firebaseio.com'
});

const firestore = admin.firestore();

// Replace 'collectionName' with the name of your Firestore collection
const collectionRef = firestore.collection('venues_info');

// Replace '/path/to/key_buildings_data.json' with the actual path to your JSON file

// Loop through the JSON data and add each document to the collection
jsonData.forEach((data) => {
    collectionRef.add(data)
        .then((docRef) => {
            console.log('Document written with ID: ', docRef.id);
        })
        .catch((error) => {
            console.error('Error adding document: ', error);
        });
});