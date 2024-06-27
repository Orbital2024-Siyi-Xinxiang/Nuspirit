using UnityEngine;
using UnityEngine.UI;

public class VenueBookingPanel : MonoBehaviour
{
    public static VenueBookingPanel Instance { get; private set; } // Singleton pattern

    private GameObject panel;
    private Button closeButton;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    void Start()
    {
        // Assuming the script is attached to the panel
        panel = gameObject;

        // Find the CloseButton and assign the onClick event to a method
        closeButton = panel.transform.Find("CloseButton").GetComponent<Button>();
        closeButton.onClick.AddListener(HidePanel);

        HidePanel(); // Ensure the panel is hidden at the start
    }

    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }
}
