using UnityEngine;
using System.Collections;
using TMPro;
// this class is a ui manager for handling all the UI HUD in the game. ALl UI commands are issued 
// through the static methods of this class

public class UIManager : MonoBehaviour
{
    // Add your variables and references here
    static UIManager current;
    public TextMeshProUGUI goToFurnitureMarketText;
    public TextMeshProUGUI constructionText;
    public TextMeshProUGUI rankingText;
    public TextMeshProUGUI balanceText;

    public static UIManager Instance
    {
        get
        {
            if (!current)
            {
                current = FindObjectOfType<UIManager>();
            }
            return current;
        }
    }

    private void Start()
    {
        // Add your initialization code here
    }

    private void Update()
    {
        // Add your update code here
    }

    // Add your UI-related methods here
}