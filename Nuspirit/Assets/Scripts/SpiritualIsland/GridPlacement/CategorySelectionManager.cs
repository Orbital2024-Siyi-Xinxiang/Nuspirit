using UnityEngine;
using UnityEngine.UI;

public class CategorySelectionManager : MonoBehaviour
{
    public CategoryDatabaseSO categoryDatabase;
    public ObjectsDatabaseSO objectsDatabase;
    public Transform categoryButtonContainer;
    public Transform assetButtonContainer;
    public GameObject categoryButtonPrefab;
    public GameObject assetButtonPrefab;
    public ObjectPlacer objectPlacer;

    private string selectedCategory;

    void Start()
    {
        PopulateCategoryButtons();
    }

    void PopulateCategoryButtons()
    {
        foreach (string category in categoryDatabase.categories)
        {
            GameObject buttonObject = Instantiate(categoryButtonPrefab, categoryButtonContainer);
            Button button = buttonObject.GetComponent<Button>();
            button.onClick.AddListener(() => OnCategorySelected(category));
            Text buttonText = buttonObject.GetComponentInChildren<Text>();
            buttonText.text = category;
        }
    }

    void OnCategorySelected(string category)
    {
        selectedCategory = category;
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
                button.onClick.AddListener(() => OnAssetSelected(objectData.prefab));
                Text buttonText = buttonObject.GetComponentInChildren<Text>();
                buttonText.text = objectData.prefab.name;
            }
        }
    }

    void OnAssetSelected(GameObject assetPrefab)
    {
        objectPlacer.SetObjectToPlace(assetPrefab);
    }
}
