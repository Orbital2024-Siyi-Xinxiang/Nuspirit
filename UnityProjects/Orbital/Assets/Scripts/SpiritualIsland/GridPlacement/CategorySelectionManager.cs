using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CategorySelectionManager : MonoBehaviour
{
    public CategoryDatabaseSO categoryDatabase;
    public Transform categoryButtonContainer;
    public GameObject categoryButtonPrefab;
    public GameObject assetSelectionUI;
    public AssetSelectionManager assetSelectionManager;

    void Start()
    {
        assetSelectionUI.SetActive(false);
        PopulateCategoryButtons();
    }

    void PopulateCategoryButtons()
    {
        //print(
        foreach (var categoryItem in categoryDatabase.categories)
        {
            string category = categoryItem.category;
            GameObject prefab = categoryItem.prefab;

            GameObject buttonObject = Instantiate(categoryButtonPrefab, categoryButtonContainer);
            Button button = buttonObject.GetComponent<Button>();
            TextMeshProUGUI buttonText = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = category;
            // Add LayoutElement and set preferred size
            LayoutElement layoutElement = buttonObject.AddComponent<LayoutElement>();
            layoutElement.preferredWidth = 80;
            layoutElement.preferredHeight = 50;

            button.onClick.AddListener(() => OnCategorySelected(category));
        }

        HorizontalLayoutGroup horizontalLayoutGroup = categoryButtonContainer.GetComponent<HorizontalLayoutGroup>();
        horizontalLayoutGroup.childControlWidth = true;
        horizontalLayoutGroup.childControlHeight = true;
        horizontalLayoutGroup.childScaleWidth = true;
        horizontalLayoutGroup.childScaleHeight = true;
    }

    public void OnCategorySelected(string category)
    {
        //print("hey!");
        assetSelectionUI.SetActive(true);
        assetSelectionManager.onCategorySelected(category);
    }
}
