using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectPlacer : MonoBehaviour
{
    public Camera mainCamera;
    public GridData gridData;
    public InputManager inputManager;

    private GameObject objectToPlace;
    private GameObject currentPreviewObject;

    public PreviewSystem previewSystem;

    void OnEnable()
    {
        InputManager.OnTouch += HandleTouch;
    }

    void OnDisable()
    {
        InputManager.OnTouch -= HandleTouch;
    }

    public void SetObjectToPlace(GameObject prefab)
    {
        objectToPlace = prefab;
        if (currentPreviewObject != null)
        {
            Destroy(currentPreviewObject);
        }

        currentPreviewObject = Instantiate(objectToPlace);
        currentPreviewObject.SetActive(false);
    }

    void PlaceObject(Vector3Int cellPosition)
    {
        if (!gridData.IsCellOccupied(cellPosition))
        {
            GameObject placedObject = Instantiate(objectToPlace, gridData.tilemap.CellToWorld(cellPosition), Quaternion.identity);
            gridData.OccupyCell(cellPosition, placedObject);
        }

        if (currentPreviewObject != null)
        {
            Destroy(currentPreviewObject);
            currentPreviewObject = null;
        }

        previewSystem.enabled = false;
    }

    private void HandleTouch(Vector2 position, bool isDragging)
    {
        if (objectToPlace == null || currentPreviewObject == null) return;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, Camera.main.nearClipPlane));
        Vector3Int cellPosition = gridData.tilemap.WorldToCell(worldPosition);

        if (isDragging)
        {
            currentPreviewObject.transform.position = worldPosition;
            currentPreviewObject.SetActive(true);
        }
        else
        {
            PlaceObject(cellPosition);
            previewSystem.HidePreview();
        }
    }
}
