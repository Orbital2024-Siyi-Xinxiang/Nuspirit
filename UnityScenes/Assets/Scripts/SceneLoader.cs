using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;
    public static SceneLoader Instance { get; private set; }
    string userId;
    string venueId;
    string info;

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
    private void Start()
    {
        
        sceneToLoad = "NoEntry";
        //LoadInitialScene(); // Load the initial scene based on your logic
    }


    public void Initialize(string userId, string scene, string venueId, string info)
    {
        this.userId = userId;
        this.venueId = venueId;
        this.info = info;
        Debug.Log($"Initializing Scene Loader with userID: {userId}, scene: {scene}, venueId: {venueId}");

        SceneManager.sceneLoaded += OnSceneLoaded;

        if (scene != SceneManager.GetActiveScene().name)
        {
            sceneToLoad = scene;
            SceneManager.LoadScene(scene);
     
        }

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SpecificVenue")
        {
            Debug.LogWarning("start specific venue");
            GameStateManager gameStateManager = FindFirstObjectByType<GameStateManager>();

            if (gameStateManager != null)
            {
                gameStateManager.SetVenueId(venueId);
                Debug.Log("GameStateManager found and venueId set!");
            }
            else
            {
                // Get the active scene
                Scene activeScene = SceneManager.GetActiveScene();

                // Get the root GameObjects in the scene
                GameObject[] rootGameObjects = activeScene.GetRootGameObjects();

                if (rootGameObjects.Length > 0 && activeScene.name == "SpecificVenue")
                {
                    // Get the first GameObject
                    GameObject firstGameObject = rootGameObjects[0];
                    gameStateManager = firstGameObject.GetComponent<GameStateManager>();
                    gameStateManager.SetVenueId(venueId);

                    // Print the name of the first GameObject
                    Debug.Log("The first GameObject in the scene is: " + firstGameObject.name);
                }
                Debug.Log("GameStateManager not found in scene ");
            }
        }

        // Unsubscribe to avoid repeated calls
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
