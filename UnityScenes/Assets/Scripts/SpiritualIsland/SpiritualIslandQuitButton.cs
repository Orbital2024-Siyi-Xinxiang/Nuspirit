using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SpiritualIslandQuitButton : MonoBehaviour
{
    public Button backToFurnitureMarket;
    public UrlSchemeHandler urlSchemeHandler;
    public Button backToMainMap;
    // Use this for initialization
    void Start()
	{
        urlSchemeHandler = UrlSchemeHandler.Instance;
        if (backToFurnitureMarket != null)
        {
            Debug.LogWarning("back to furniture market!!!");
            backToFurnitureMarket.onClick.AddListener(NavigateToFurnitureMarket);
        }

        if (backToMainMap != null)
        {
            Debug.LogWarning("back to furniture market!!!");
            backToMainMap.onClick.AddListener(NavigateToMainMap);
        }

    }

    void NavigateToFurnitureMarket()
    {
        string url = $"swiftUIApp://{urlSchemeHandler.userId}/FurnitureMarketView/na/na";
        // Open the URL using Application.OpenURL
        Application.OpenURL(url);
    }

    void NavigateToMainMap()
    {
        string url = $"swiftUIApp://{urlSchemeHandler.userId}/MainMapView/na/na";
        // Open the URL using Application.OpenURL
        Application.OpenURL(url);
    }
}

