from bs4 import BeautifulSoup
import json

# Load the HTML file
with open('/Users/emma/Desktop/Repos/Orbital2024/Monorepo/Nuspirit/ThirdParty/buildings_raw_data.json', 'r') as file:

    geojson_data = json.load(file)

# for script in script_tags:
#     if 'geo_json_f064cd4f875a46ff469c8a29919046ff_add' in script.text:
#         start_index = script.text.find('geo_json_f064cd4f875a46ff469c8a29919046ff_add') + len('geo_json_f064cd4f875a46ff469c8a29919046ff_add(')
#         end_index = script.text.find(');', start_index)
#         geojson_str = script.text[start_index:end_index].strip()
#         if geojson_str:  # Check if the string is not empty
#             try:
#                 geojson_data = json.loads(geojson_str)
#             except json.decoder.JSONDecodeError as e:
#                 print(f"Failed to decode JSON: {e}")
#                 continue
#         else:
#             print("geojson_str is empty")
#         break

# Extract coordinates from the GeoJSON data
buildings = []
key_buildings = []

if geojson_data:
    for feature in geojson_data['features']:
        if feature['geometry']['type'] == 'Point':
            continue
        else:
            coordinates1 = [feature['bbox'][0], feature['bbox'][1]]
            coordinates2 = [feature['bbox'][2], feature['bbox'][3]]
            id = feature.get('id', None) # Extract the building ID
            properties = feature.get('properties', None)
            buildings.append({
                'name': id,
                'coordinates': [coordinates1, coordinates2]
            })
            if properties:
                if properties.get('name'):
                    # if properties.get('name') != 'null':
                    id = ''.join(filter(str.isdigit, id))  # Extract only numeric characters from the ID
                    levels = properties.get("building:levels")
                    capacity = properties.get('capacity')
                    if not levels:
                        levels = 1
                    if not capacity:
                        capacity = 0
                    
                    key_buildings.append({
                        'id': id,
                        'coordinates': [coordinates1, coordinates2],
                        'name': properties['name'],
                        'levels': int(properties.get("building:levels") or 1),
                        'capacity': int(properties.get('capacity') or 0)
                    })
                    # key_buildings.append({
                    #     'id': id,
                    #     'coordinates': [coordinates1, coordinates2],
                    #     'name': properties['name'],
                    #     'levels': properties.get("building:levels", 1),
                    #     'capacity': properties.get('capacity', 0)
                    # })


# Print the extracted building data
for building in buildings:
    print(f"Building Name: {building['name']}")
    print(f"Coordinates: {building['coordinates']}\n")

# Optionally, save to a JSON file
with open('/Users/emma/Desktop/Repos/Orbital2024/Monorepo/Nuspirit/ThirdParty/buildings_data.json', 'w') as json_file:
    json.dump(buildings, json_file, indent = 4)
with open('/Users/emma/Desktop/Repos/Orbital2024/Monorepo/Nuspirit/ThirdParty/key_buildings_data.json', 'w') as json_file:
    json.dump(key_buildings, json_file, indent = 4)