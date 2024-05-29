using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectPlacer : MonoBehaviour
{
    public Camera mainCamera;
    public GridData gridData;
    public GameObject previewObjectPrefab;
    private GameObject previewObjectInstance;
    private GameObject objectToPlace;
    private Vector3Int lastCellPosition;

    void OnEnable()
    {
        InputManager.OnTouch += HandleTouch;
    }

    void OnDisable()
    {
        InputManager.OnTouch -= HandleTouch;
    }

    void HandleTouch(Vector2 touchPosition)
    {
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
        Vector3Int cellPosition = gridData.tilemap.WorldToCell(worldPosition);

        if (objectToPlace != null)
        {
            PlaceObject(cellPosition);
        }
        else
        {
            PreviewObject(cellPosition);
        }
    }

    void PreviewObject(Vector3Int cellPosition)
    {
        if (previewObjectInstance == null)
        {
            previewObjectInstance = Instantiate(previewObjectPrefab, gridData.tilemap.CellToWorld(cellPosition), Quaternion.identity);
        }
        else
        {
            previewObjectInstance.transform.position = gridData.tilemap.CellToWorld(cellPosition);
        }

        if (lastCellPosition != cellPosition)
        {
            HighlightCell(cellPosition, true);
            if (lastCellPosition != null)
            {
                HighlightCell(lastCellPosition, false);
            }
            lastCellPosition = cellPosition;
        }
    }

    void PlaceObject(Vector3Int cellPosition)
    {
        if (!gridData.IsCellOccupied(cellPosition))
        {
            GameObject placedObject = Instantiate(objectToPlace, gridData.tilemap.CellToWorld(cellPosition), Quaternion.identity);
            gridData.OccupyCell(cellPosition, placedObject);
            Destroy(previewObjectInstance);
            previewObjectInstance = null;
        }
    }

    void HighlightCell(Vector3Int cellPosition, bool highlight)
    {
        // Implement logic to highlight the cell
        // Example: Change the color of the tile
        TileBase tile = gridData.tilemap.GetTile(cellPosition);
        if (tile != null)
        {
            Color color = highlight ? Color.yellow : Color.white;
            gridData.tilemap.SetColor(cellPosition, color);
        }
    }

    public void SetObjectToPlace(GameObject newObject)
    {
        objectToPlace = newObject;
    }
}
