using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CategorySelectionManager : MonoBehaviour
{
    // selectiom databases
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
        foreach (var categoryItem in categoryDatabase.categories)
        {
            string category = categoryItem.category;
            GameObject prefab = categoryItem.prefab;

            GameObject buttonObject = Instantiate(categoryButtonPrefab, categoryButtonContainer);
            Button button = buttonObject.GetComponent<Button>();
            button.onClick.AddListener(() => OnCategorySelected(category));
            TextMeshProUGUI buttonText = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = category;
        }
    }

    public  void OnCategorySelected(string category)
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
                TextMeshProUGUI buttonText = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = objectData.prefab.name;
            }
        }
    }

    void OnAssetSelected(GameObject assetPrefab)
    {
        objectPlacer.SetObjectToPlace(assetPrefab);
    }
}
