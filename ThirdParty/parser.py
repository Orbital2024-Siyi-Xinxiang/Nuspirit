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

if geojson_data:
    for feature in geojson_data['features']:
        if feature['geometry']['type'] == 'Point':
            continue
        else:
            coordinates1 = [feature['bbox'][0], feature['bbox'][1]]
            coordinates2 = [feature['bbox'][2], feature['bbox'][3]]
            id = feature.get('id', None)[8:-1] # Extract the building ID
            buildings.append({
                'name': id,
                'coordinates': [coordinates1, coordinates2]
            })


# Print the extracted building data
for building in buildings:
    print(f"Building Name: {building['name']}")
    print(f"Coordinates: {building['coordinates']}\n")

# Optionally, save to a JSON file
with open('/Users/emma/Desktop/Repos/Orbital2024/Monorepo/Nuspirit/ThirdParty/buildings_data.json', 'w') as json_file:
    json.dump(buildings, json_file, indent=4)
