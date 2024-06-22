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

    public Task InitializeBackground()
    {
        print($"start rendering background for {venue.id}");

        GameObject gridObject = GameObject.Find("TilemapGrid");
        // Create a new GameObject for the Tilemap and make it a child of the Grid
        GameObject tilemapObject = Instantiate(backgroundPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        tilemapObject.transform.SetParent(gridObject.transform, false);

        // Add a Tilemap component to the Tilemap GameObject
        Tilemap backgroundTilemap = tilemapObject.GetComponent<Tilemap>();

        if (venue.venueBackground != null)
        {
            // Render the tiles based on the current venue
            print("render!!!!!!!!!");
            venue.venueBackground.background = RenderTiles(backgroundTilemap, venue.venueBackground.tileSet, venue.venueBackground.dimension);
        }
        return Task.CompletedTask;
    }

    public Task InitializeSolidLayer()
    {
        print($"start rendering solidLayer for {venue.id}");
        // Create a new GameObject for the Grid
        GameObject gridObject = GameObject.Find("TilemapGrid");
        // Add a Grid component to the Grid GameObject
        Grid grid = gridObject.GetComponent<Grid>();

        // Create a new GameObject for the Tilemap and make it a child of the Grid
        GameObject tilemapObject = new GameObject("SolidLayerTilemap");
        tilemapObject.transform.SetParent(gridObject.transform, false);

        // Add a Tilemap component to the Tilemap GameObject
        Tilemap solidLayerTilemap = tilemapObject.GetComponent<Tilemap>();

        if (venue.venueSolidLayer != null)
        {
            // Render the tiles based on the current venue
            venue.venueSolidLayer.solidLayer = RenderTiles(solidLayerTilemap, venue.venueSolidLayer.tileSet, venue.venueSolidLayer.dimension);
        }
        return Task.CompletedTask;
    }

    //public async Task<Tilemap> RenderTilesAsync(Tilemap tilemapToRender, TileSet tileSet, Vector2 dimension)
    //{
    //    // Run CPU-bound work on a background thread
    //    return await Task.Run(() => RenderTiles(tilemapToRender, tileSet, dimension));
    //}

    private Tilemap RenderTiles(Tilemap tilemapToRender, TileSet tileSet, Vector2 dimension)
    {
        print("rendering tiles ...");
        //print(tileSet.tiles);
        //print(dimension);

        // Corrected calculations to ensure proper tiling
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
                }
            }

            // Complete the background object and assign it back to the scriptable object
            return tilemapToRender;
        }

        return null;
    }
}
