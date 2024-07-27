using UnityEngine;
using UnityEngine.Networking;

public class UrlSchemeHandler : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public string userId;

    void Start()
    {
        userId = "0";

        // Check if launched from a URL
        if (Application.absoluteURL.StartsWith("unityApp://"))
        {
            // Extract parameters from URL
            string url = Application.absoluteURL.Substring("unityApp://".Length);
            string[] parts = url.Split('/');

            if (parts.Length == 3)
            {
                userId = parts[0];
                string scene = parts[1];
                string venueId = parts[2];

                // Initialize the scene loader with the parsed parameters
                sceneLoader.Initialize(userId, scene, venueId, "");
            }
            else
            {
                Debug.LogError("Invalid URL format");
            }
        }
    }

    public void NavigateBackToNativeApp(string userId = "na",
        string viewName = "LandingView", string action = "na", string trailingInfo = "na")
    {
        // Encode URL components
        string encodedUserId = UnityWebRequest.EscapeURL(userId);
        string encodedViewName = UnityWebRequest.EscapeURL(viewName);
        string encodedAction = UnityWebRequest.EscapeURL(action);
        string encodedTrailingInfo = UnityWebRequest.EscapeURL(trailingInfo);

        // Construct the URL scheme to navigate back
        string url = $"swiftUIApp://{encodedUserId}/{encodedViewName}/{encodedAction}/{encodedTrailingInfo}";

        // Open the URL using Application.OpenURL
        Application.OpenURL(url);
    }

}
