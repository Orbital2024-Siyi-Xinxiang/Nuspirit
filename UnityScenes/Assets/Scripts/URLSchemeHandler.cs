using UnityEngine;
using UnityEngine.Networking;

public class UrlSchemeHandler : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public string userId;

    public static UrlSchemeHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        sceneLoader = SceneLoader.Instance;
        userId = "0";

        // Subscribe to the deepLinkActivated event
        Application.deepLinkActivated += OnDeepLinkActivated;

        //test 
        //sceneLoader.Initialize(userId, "SpecificVenue", "54619721", "na");
        // Check if the app was launched with a deep link
        if (!string.IsNullOrEmpty(Application.absoluteURL))
        {
            ProcessDeepLink(Application.absoluteURL);
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from the deepLinkActivated event to avoid memory leaks
        Application.deepLinkActivated -= OnDeepLinkActivated;
    }

    void OnDeepLinkActivated(string url)
    {
        // Process the deep link when the event is triggered
        ProcessDeepLink(url);
    }

    private void ProcessDeepLink(string url)
    {
        if (!string.IsNullOrEmpty(url))
        {
            Debug.Log("Received deep link: " + url);
            // Extract parameters from URL
            string[] parts = url.Substring("unityApp://".Length).Split('/');

            if (parts.Length == 3)
            {
                userId = parts[0];
                string scene = parts[1];
                string venueId = parts[2];

                // Initialize the scene loader with the parsed parameters
                sceneLoader.Initialize(userId, scene, venueId, "na");
            }
            else if (parts.Length == 4)
            {
                userId = parts[0];
                string scene = parts[1];
                string venueId = parts[2];
                string info = parts[3];

                // Initialize the scene loader with the parsed parameters
                sceneLoader.Initialize(userId, scene, venueId, info);
            }
            else
            {
                Debug.LogError("Invalid URL format");
            }
        }
    }

    public void NavigateBackToNativeApp(string userId = "na", string viewName = "LandingView", string action = "na", string trailingInfo = "na")
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
