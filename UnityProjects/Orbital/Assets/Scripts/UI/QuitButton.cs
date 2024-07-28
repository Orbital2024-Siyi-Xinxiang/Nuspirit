using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    // Button reference to attach in the Inspector
    public Button backButton;
    public UrlSchemeHandler UrlSchemeHandler;
    public GameStateManager gameStateManager;
    public Button viewAllBookings;

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



        if (viewAllBookings != null)
        {
            Debug.LogWarning("view all user bookings!");
            viewAllBookings.onClick.AddListener(NavigateToMyBookings);
        }
    }

    // Function to navigate back to the native iOS app
    void NavigateBackToNativeApp()
    {
        // Construct the URL scheme to navigate back

        string url = $"swiftUIApp://{UrlSchemeHandler.userId}/MainMapView/unsubscribe/{gameStateManager.venueId}";
        // Open the URL using Application.OpenURL
        Application.OpenURL(url);
    }



    void NavigateToMyBookings()
    {
        string url = $"swiftUIApp://{UrlSchemeHandler.userId}/MyBookingsView/na/na";
        // Open the URL using Application.OpenURL
        Application.OpenURL(url);
    }
}
