using UnityEngine;
using UnityEngine.Tilemaps;

public class VenueRenderer : MonoBehaviour
{
    private Venue currentVenue;
    public GameObject backgroundPrefab; // Prefab with Tilemap component
    private Tilemap backgroundTilemap;
    private Camera mainCamera;

    public void Initialize(Venue venue)
    {
        currentVenue = venue;
        mainCamera = Camera.main;
        InitializeBackground();
    }

    private void InitializeBackground()
    {
        // Instantiate the background prefab and get the Tilemap component
        GameObject background = Instantiate(backgroundPrefab, new Vector3(-5, -5, 0), Quaternion.identity);
        backgroundTilemap = background.GetComponent<Tilemap>();

        // Render the initial visible tiles based on the current venue
        RenderTiles();
    }

    private void RenderTiles()
    {
        if (currentVenue.venueBackground != null)
        {
            VenueBackground venueBackground = currentVenue.venueBackground;

            if (venueBackground.tileSet != null && venueBackground.tileSet.tiles != null)
            {
                // Load tiles within the initial view
                LoadVisibleTiles();
            }
        }
    }

    private void LoadVisibleTiles()
    {
        // Calculate the visible area based on the camera view
        float cameraHeight = mainCamera.orthographicSize * 2;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        Vector3 cameraCenter = mainCamera.transform.position;

        float left = cameraCenter.x - cameraWidth / 2;
        float right = cameraCenter.x + cameraWidth / 2;
        float bottom = cameraCenter.y - cameraHeight / 2;
        float top = cameraCenter.y + cameraHeight / 2;

        // Load and render tiles within the visible area
        for (int x = Mathf.FloorToInt(left / 64); x <= Mathf.CeilToInt(right / 64); x++)
        {
            for (int y = Mathf.FloorToInt(bottom / 64); y <= Mathf.CeilToInt(top / 64); y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                if (!backgroundTilemap.HasTile(tilePosition))
                {
                    // Load tile from the venueBackground data
                    int index = x + y * currentVenue.venueBackground.tileSet.tiles.Length;
                    if (index >= 0 && index < currentVenue.venueBackground.tileSet.tiles.Length)
                    {
                        TileBase tile = currentVenue.venueBackground.tileSet.tiles[index];
                        backgroundTilemap.SetTile(tilePosition, tile);
                    }
                }
            }
        }
    }

    private void Update()
    {
        // Implement lazy rendering based on camera zoom level and position
        LoadVisibleTiles();
    }
}
