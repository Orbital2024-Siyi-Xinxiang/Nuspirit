using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AssetSelectionManager : MonoBehaviour
{
    private string selectedCategory;
    public Transform assetButtonContainer;
    public ObjectsDatabase objectsDatabase;
    public ObjectPlacer objectPlacer;
    public GameObject assetButtonPrefab;
    public GameObject assetSelectionUI;

    public void onCategorySelected(string category)
    {
        this.populateAssetButtons(category);
    }

    void populateAssetButtons(string category)
    {
        foreach (Transform child in assetButtonContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var objectData in objectsDatabase.objects)
        {
            if (objectData.category == category)
            {
                GameObject buttonObject = Instantiate(assetButtonPrefab, assetButtonContainer);
                Button button = buttonObject.GetComponent<Button>();
                GameObject assetPreviewPrefab = objectData.prefab;

                button.onClick.AddListener(() => OnAssetSelected(assetPreviewPrefab));

                TextMeshProUGUI buttonText = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = objectData.prefab.name;

                // Set the cell size of assetButtonContainer grid group layout to 100 * 100
                GridLayoutGroup gridLayoutGroup = assetButtonContainer.GetComponent<GridLayoutGroup>();
                gridLayoutGroup.cellSize = new Vector2(100, 100);
                gridLayoutGroup.spacing = new Vector2(20, 20);
            }
        }
    }

    void OnAssetSelected(GameObject assetPreviewPrefab)
    {
        if (assetPreviewPrefab != null)
        {
            objectPlacer.SetObjectToPlace(assetPreviewPrefab);
        }

        assetSelectionUI.SetActive(false); // Hide the UI after selecting an asset
    }

    void Update()
    {
    }
}
