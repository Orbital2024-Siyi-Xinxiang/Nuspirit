import osmnx as ox
import folium
import geopandas as gpd

# Define the area of interest (NUS)
place_name = "National University of Singapore, Singapore"

# Download building footprints
buildings = ox.geometries_from_place(place_name, tags={'building': True})

# Create a GeoDataFrame
buildings_gdf = gpd.GeoDataFrame(buildings)

# Initialize a folium map centered around NUS
nus_map = folium.Map(location=[1.2966, 103.7764], zoom_start=15, tiles='OpenStreetMap')
print("map created")
# Function to style each building
def style_function(feature):
    return {
        'fillColor': 'blue',
        'color': 'blue',
        'weight': 1.5,
        'fillOpacity': 0.5,
    }

# Add buildings to the map
folium.GeoJson(
    buildings_gdf,
    style_function=style_function,
    tooltip=folium.GeoJsonTooltip(fields=['building'], aliases=['Building: ']),
    highlight_function=lambda x: {'weight': 3, 'color': 'yellow'}
).add_to(nus_map)

# Save the map to an HTML file
nus_map.save("nus_interactive_map.html")

# Print a message to indicate the map has been saved
print("Interactive map has been saved to nus_interactive_map.html")
