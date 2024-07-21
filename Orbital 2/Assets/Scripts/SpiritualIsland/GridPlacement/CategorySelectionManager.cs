using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.PlayerSettings.WSA;
using System.Numerics;

public class CategorySelectionManager : MonoBehaviour
{
    public string[] categories;
    public Transform categoryButtonContainer;
    public GameObject categoryButtonPrefab;
    public GameObject assetSelectionUI;
    public AssetSelectionManager assetSelectionManager;

    void Start()
    {
        assetSelectionUI.SetActive(false);
        PopulateCategoryButtons();
        categories = new string[] { "Island", "Housing", "Furniture", "Plant", "Animal", "Avatar" };
    }

    void PopulateCategoryButtons()
    {
        //print(
        foreach (string category in categories)
        {
            
            GameObject buttonObject = Instantiate(categoryButtonPrefab, categoryButtonContainer);
            Button button = buttonObject.GetComponent<Button>();

            Image image = buttonObject.GetComponent<Image>();
            TextMeshProUGUI buttonText = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = category;
            button.name = category;

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

        assetSelectionManager.OnCategorySelected(category);
    }

    public void OnAssetSelected(GameObject prefab, string category)
    {
        // TODO: destroy all other prefabs -> set the prefab selected covering the button (same size as the button)
    }
}
