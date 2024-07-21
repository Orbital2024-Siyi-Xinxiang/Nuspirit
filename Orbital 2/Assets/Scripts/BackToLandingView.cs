using UnityEngine;
using UnityEngine.UI;

public class BackToLandingView : MonoBehaviour
{
    // Button reference to attach in the Inspector
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the backButton is assigned in the Inspector
        if (backButton != null)
        {
            // Add a listener for the button click event
            backButton.onClick.AddListener(NavigateBackToNativeApp);
        }
    }

    // Function to navigate back to the native iOS app
    void NavigateBackToNativeApp()
    {
        // Construct the URL scheme to navigate back
        string url = "unityApp://";

        // Open the URL using Application.OpenURL
        Application.OpenURL(url);
    }
}