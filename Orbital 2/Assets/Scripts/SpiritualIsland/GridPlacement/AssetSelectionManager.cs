using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static ObjectsDatabaseSO;

public class AssetSelectionManager : MonoBehaviour
{
    private string category;
    public CategorySelectionManager categorySelectionManager;
    public Transform assetButtonContainer;
    public ObjectsDatabaseSO objectsDatabase;
    public ObjectPlacer objectPlacer;
    public GameObject assetButtonPrefab;
    public GameObject assetSelectionUI;
    public Button selectedButton;

    public void OnCategorySelected(string category)
    {
        this.category = category;
        PopulateAssetButtons(category);
    }

    void PopulateAssetButtons(string category)
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

                button.onClick.AddListener(() => OnAssetSelected(objectData));

                TextMeshProUGUI buttonText = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = objectData.prefab.name;

                // Set the cell size of assetButtonContainer grid group layout to 100 * 100
                GridLayoutGroup gridLayoutGroup = assetButtonContainer.GetComponent<GridLayoutGroup>();
                gridLayoutGroup.cellSize = new Vector2(100, 100);
                gridLayoutGroup.spacing = new Vector2(20, 20);

                // this warning is using the user-designed highlight art instead.
                // Add highlight outline component or script to the button
                HighlightOutline outline = buttonObject.AddComponent<HighlightOutline>();
            }
        }
    }

    void OnAssetSelected(ObjectData objectData)
    {
        assetSelectionUI.SetActive(false); // Hide the UI after selecting an asset
        categorySelectionManager.OnAssetSelected(objectData.prefab, objectData.category);
    }

    void Update()
    {
    }
}
