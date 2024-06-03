using UnityEngine;

public class PreviewSystem : MonoBehaviour
{
    public GameObject previewPrefab;
    private GameObject previewInstance;

    public void ShowPreview(Vector3Int cellPosition)
    {
        if (previewInstance == null)
        {
            previewInstance = Instantiate(previewPrefab, cellPosition, Quaternion.identity);
        }
        else
        {
            previewInstance.transform.position = cellPosition;
        }
    }

    public void HidePreview()
    {
        if (previewInstance != null)
        {
            Destroy(previewInstance);
            previewInstance = null;
        }
    }
}
