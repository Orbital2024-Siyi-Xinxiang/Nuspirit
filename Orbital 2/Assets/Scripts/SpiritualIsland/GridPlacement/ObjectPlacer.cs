using UnityEngine;
using static ObjectsDatabaseSO;

public class ObjectPlacer : MonoBehaviour
{
    public Camera mainCamera;
    public GridData gridData;
    public InputManager inputManager;

    private GameObject objectToPlace;
    private GameObject currentPreviewObject;
    public AssetSelectionManager assetSelectionManager;
    public PreviewSystem previewSystem;

    void OnEnable()
    {
        InputManager.OnTouch += HandleTouch;
    }

    void OnDisable()
    {
        InputManager.OnTouch -= HandleTouch;
    }

    public void SetObjectToPlace(ObjectData objectData)
    {
        // pass the object data into object placer

        objectToPlace = objectData.prefab;
        if (currentPreviewObject != null)
        {
            Destroy(currentPreviewObject);
        }

        currentPreviewObject = Instantiate(objectToPlace);

        // Position the preview object over the selected button with a bright outline
        if (objectToPlace != null && currentPreviewObject != null && assetSelectionManager.selectedButton != null)
        {
            // Assuming you have a highlight effect component or script
            HighlightOutline outline = assetSelectionManager.selectedButton.GetComponent<HighlightOutline>();
            if (outline != null)
            {
                outline.EnableOutline(); // Enable bright outline
            }

            currentPreviewObject.transform.SetParent(assetSelectionManager.selectedButton.transform);
            currentPreviewObject.transform.localPosition = Vector3.zero;
        }

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
        if (objectToPlace == null || currentPreviewObject == null)
        {
            Debug.LogError("Object preview is none or object to place is none!");
            return;
        }

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
