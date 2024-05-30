using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public Tilemap backgroundTilemap;
    public Tilemap customPlacementTilemap;
    public Tile highlightTile;

    private TileBase selectedTile;

    void Start()
    {
        // Load the first background tilemap by default
        LoadBackgroundTilemap(0);
    }

    public void LoadBackgroundTilemap(int index)
    {
        // Load the selected background tilemap
        // Example code to set a tile at a specific position
        Vector3Int position = new Vector3Int(0, 0, 0);
        backgroundTilemap.SetTile(position, highlightTile);
    }

    void Update()
    {
        // Handle user input for placing objects
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = customPlacementTilemap.WorldToCell(mouseWorldPos);

            // Highlight the cell where the object can be placed
            if (customPlacementTilemap.GetTile(gridPosition) == null)
            {
                customPlacementTilemap.SetTile(gridPosition, highlightTile);
            }
        }
    }

    public void SelectTile(TileBase tile)
    {
        selectedTile = tile;
    }

    public void PlaceTile(Vector3Int position)
    {
        if (customPlacementTilemap.GetTile(position) == null)
        {
            customPlacementTilemap.SetTile(position, selectedTile);
        }
    }
}
