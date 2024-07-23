using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    // Button reference to attach in the Inspector
    public Button backButton;
    public UrlSchemeHandler UrlSchemeHandler;
    public VenueManager venueManager;


    // Start is called before the first frame update
    void Start()
    {
        // Ensure the backButton is assigned in the Inspector
        if (backButton != null)
        {
            // Add a listener for the button click event
            Debug.LogWarning("button clicked!");
            backButton.onClick.AddListener(NavigateBackToNativeApp);
        }
    }

    // Function to navigate back to the native iOS app
    void NavigateBackToNativeApp()
    {
        // Construct the URL scheme to navigate back

        string url = $"swiftUIApp://na/MainMapView/unsubscribe/{venueManager.venue.id}";
        // Open the URL using Application.OpenURL
        Application.OpenURL(url);
    }
}
