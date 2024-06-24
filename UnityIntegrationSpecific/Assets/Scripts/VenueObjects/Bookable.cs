using UnityEngine;
using UnityEngine.UI;

public class Bookable : MonoBehaviour
{
    public VenueBookable bookableData;
    public GameObject bookVenueView;  // Assign the UI panel in the inspector
    public Button closeButton;  // Assign the close button in the inspector

    void Start()
    {
        // Hide the bookVenueView when the game starts
        bookVenueView.SetActive(false);

        // Ensure bookableData is initialized
        bookableData = ScriptableObject.CreateInstance<VenueBookable>();

        // Assign the CloseButton's onClick event to a method
        closeButton.onClick.AddListener(HideBookVenueView);
    }

    public void Initialize(VenueBookable bookableData)
    {
        this.bookableData = bookableData;
    }

    void Update()
    {
        // Any additional update logic
    }

    void OnMouseDown()
    {
        // Show the bookVenueView when the gameObject is clicked
        bookVenueView.SetActive(true);
    }

    void HideBookVenueView()
    {
        // Hide the bookVenueView
        bookVenueView.SetActive(false);
    }
}
