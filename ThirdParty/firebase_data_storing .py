import firebase_admin
from firebase_admin import firestore
from firebase_admin import credentials
import json
# Use the application default credentials.
cred = credentials.ApplicationDefault()
# Application Default credentials are automatically created.
app = firebase_admin.initialize_app(cred, {
    'projectId': 'orbital2024-9f1b1',
})
db = firestore.client()

city_ref = db.collection("key_venues")

with open('ThirdParty/key_buildings_data.json', 'r') as file:
    geojson_data = json.load(file)
    print(len(geojson_data))

for building in geojson_data:
    doc = city_ref.document(building['id'])
    data = {
        'id': building['id'],
        'name': building['name'],
        'coordinates': building['coordinates'],
        'coordinates': [firestore.GeoPoint(building['coordinates'][0][1], building['coordinates'][0][0]),
                        firestore.GeoPoint(building['coordinates'][1][1], building['coordinates'][1][0])],
        'levels': building['levels'],
        'capacity': building['capacity']
    }
    doc.set(data)


