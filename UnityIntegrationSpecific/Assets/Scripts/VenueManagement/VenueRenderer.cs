using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VenueRenderer : MonoBehaviour
{
    public VenueDatabase venueDatabase;
    public GameObject backgroundPrefab;
    public GameObject solidLayerPrefab;

    public Camera mainCamera;
    public Venue venue;

    public void Initialize(string venueId)
    {
        venue = venueDatabase.GetVenue(venueId);
        // Create a new GameObject for the Grid
        GameObject gridObject = new GameObject("TilemapGrid");
        gridObject.transform.position = new Vector3(-15, -5, 0);

        // Add a Grid component to the Grid GameObject
        Grid grid = gridObject.AddComponent<Grid>();
        //print("venue renderer initialized");
    }

    public async Task InitializeBackground()
    {
        print($"start rendering background for {venue.id}");

        GameObject gridObject = GameObject.Find("TilemapGrid");
        GameObject tilemapObject = Instantiate(backgroundPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        tilemapObject.transform.SetParent(gridObject.transform, false);

        Tilemap backgroundTilemap = tilemapObject.GetComponent<Tilemap>();

        if (venue.venueBackground != null)
        {
            await RenderTilesAsync(backgroundTilemap, venue.venueBackground.tileSet, venue.venueBackground.dimension);
        }
    }

    public async Task InitializeSolidLayer()
    {
        print($"start rendering solid layer for {venue.id}");

        GameObject gridObject = GameObject.Find("TilemapGrid");
        GameObject tilemapObject = Instantiate(backgroundPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        tilemapObject.transform.SetParent(gridObject.transform, false);

        Tilemap solidLayerTilemap = tilemapObject.GetComponent<Tilemap>();

        if (venue.venueBackground != null)
        {
            await RenderTilesAsync(solidLayerTilemap, venue.venueSolidLayer.tileSet, venue.venueSolidLayer.dimension);
        }
    }


    private async Task RenderTilesAsync(Tilemap tilemapToRender, TileSet tileSet, Vector2 dimension)
    {
        print("rendering tiles ...");

        int numOfRows = (int)(dimension.x / TileUtility.gridSize);
        int numOfColumns = (int)(dimension.y / TileUtility.gridSize);

        if (tileSet != null && tileSet.tiles != null)
        {
            for (int y = 0; y < numOfColumns; y++)
            {
                for (int x = 0; x < numOfRows; x++)
                {
                    int index = x + y * numOfRows; // Corrected indexing
                    if (index < tileSet.tiles.Length)
                    {
                        TileBase tile = tileSet.tiles[index];
                        tilemapToRender.SetTile(new Vector3Int(x, y, 0), tile);
                    }

                    // Optional: yield every few tiles to allow the UI to update
                    if ((x * y) % 10 == 0)
                    {
                        await Task.Yield();
                    }
                }
            }
        }
    }
}
