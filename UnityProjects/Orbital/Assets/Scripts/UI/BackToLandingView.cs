using UnityEngine;
using UnityEngine.UI;

public class BackToLandingView : MonoBehaviour
{
    // Button reference to attach in the Inspector
    public Button backButton;
    public UrlSchemeHandler urlSchemeHandler;
    public GameStateManager gameStateManager;

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
        string url = $"swiftUIApp://na/LandingView/na/na";
        // Open the URL using Application.OpenURL
        Application.OpenURL(url);
    }
}