using UnityEngine;
using UnityEngine.Tilemaps;

public class PreviewSystem : MonoBehaviour
{
    private GameObject previewInstance;
    public Tilemap customPlacementTilemap;
    public Tile highlightTile;

    public void UpdatePreview(Vector3Int cellPosition, GameObject previewPrefab)
    {
        if (previewInstance == null)
        {
            previewInstance = Instantiate(previewPrefab, customPlacementTilemap.CellToWorld(cellPosition), Quaternion.identity);
        }
        else
        {
            previewInstance.transform.position = customPlacementTilemap.CellToWorld(cellPosition);
            previewInstance.SetActive(true);
        }
        HighlightCell(cellPosition);
    }

    public void HidePreview()
    {
        if (previewInstance != null)
        {
            Destroy(previewInstance);
            previewInstance = null;
        }
        ClearHighlights();
    }

    private void HighlightCell(Vector3Int cellPosition)
    {
        customPlacementTilemap.SetTile(cellPosition, highlightTile);
    }

    private void ClearHighlights()
    {
        customPlacementTilemap.ClearAllTiles();
    }
}
