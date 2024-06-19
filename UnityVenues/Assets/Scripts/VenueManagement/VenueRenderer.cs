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

        InitializeBackground();
    }

    public void InitializeBackground()
    {
        // Instantiate the background prefab and get the Tilemap component
        GameObject background = Instantiate(backgroundPrefab, new Vector3(-5, -5, 0), Quaternion.identity);
        backgroundTilemap = background.GetComponent<Tilemap>();

        if(venue.venueBackground != null)
        {
            // Render the tiles based on the current venue
            RenderTiles();
        }

    }

    public void RenderTiles()
    {
        VenueBackground venueBackground = venue.venueBackground;

            if (venueBackground.tileSet != null && venueBackground.tileSet.tiles != null)
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
   
