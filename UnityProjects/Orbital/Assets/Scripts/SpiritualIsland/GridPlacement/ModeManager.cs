using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModeManager : MonoBehaviour
{
    public Button goToFurnitureMarket;

    // Start is called before the first frame update

    // TODO: change mode. two modes: placement explore

    public TMP_Dropdown changeMode;

    public GameObject player;

    void Start()
    {
        if (goToFurnitureMarket != null)
        {
            goToFurnitureMarket.onClick.AddListener(NavigateToFurnitureMarket);
        }

        
    }

    void NavigateToFurnitureMarket()
    {
        string userId = "12345"; // Replace with actual user ID if needed
        string view = "FurnitureMarketView";
        string action = "navigate";
        string otherInfo = "additionalInfo";
        string url = $"unityApp://{userId}/{view}/{action}/{otherInfo}";
        Application.OpenURL(url);
    }
}
