using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VenueRenderer : MonoBehaviour
{
    public VenueDatabase venueDatabase;
    public GameObject backgroundPrefab;
    public Camera mainCamera;

    public Venue venue;

    // Prefab with Tilemap component
    private Tilemap backgroundTilemap;

    public void Initialize(string venueId)
    {
        venue = venueDatabase.GetVenue(venueId);

        
    }

    public Task InitializeBackground()
    {
        // Create a new GameObject for the Grid
        GameObject gridObject = new GameObject("TilemapGrid");
        gridObject.transform.position = new Vector3(-5, -5, 0);

        // Add a Grid component to the Grid GameObject
        Grid grid = gridObject.AddComponent<Grid>();

        // Create a new GameObject for the Tilemap and make it a child of the Grid
        GameObject tilemapObject = new GameObject("BackgroundTilemap");
        tilemapObject.transform.SetParent(gridObject.transform, false);

        // Add a Tilemap component to the Tilemap GameObject
        backgroundTilemap = tilemapObject.AddComponent<Tilemap>();
        TilemapRenderer tilemapRenderer = tilemapObject.AddComponent<TilemapRenderer>();

        if (venue.venueBackground != null)
        {
            // Render the tiles based on the current venue
            RenderTiles();
        }

        return Task.CompletedTask;
    }

    public void RenderTiles()
    {
        VenueBackground venueBackground = venue.venueBackground;

        if (venueBackground.tileSet != null && venueBackground.tileSet.tiles != null)
        {
            for (int y = 0; y < 100; y++)
            {
                for (int x = 0; x < 100; x++)
                {
                    int index = x + y * 100;
                    if (index < venueBackground.tileSet.tiles.Length)
                    {
                        TileBase tile = venueBackground.tileSet.tiles[index];
                        backgroundTilemap.SetTile(new Vector3Int(x, y, 0), tile);
                    }
                }
            }

            // Complete the background object and assign it back to the scriptable object
            venueBackground.background = backgroundTilemap;
        }
    }
}
