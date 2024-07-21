using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;

    public void SetUserScene(string scene)
    {
        sceneToLoad = scene;
        SceneManager.LoadScene(scene);
    }

    private void Start()
    {
        sceneToLoad = "NoEntry";
        // For current testing purposes, first comment this line to avoid blocking the initoal specific venue page.
        LoadInitialScene(); // Load the initial scene based on your logic
        // implementation logic here to show the non-entry screen here

    }


    public void LoadInitialScene()
    {
        // check if the current scene is 'NoEntry', if is, then do nothing
        // if not, load initial scene as NoEntry
        // Check if the current scene is already 'NoEntry'
        if (SceneManager.GetActiveScene().name != "NoEntry")
        {
            // Load the 'NoEntry' scene
            SceneManager.LoadScene("NoEntry");
        }
    }


    public void Initialize(string userId, string scene, string venueId)
    {
        Debug.Log($"Initializing Scene Loader with userID: {userId}, scene: {scene}, venueId: {venueId}");
        // Implement scene loading or other logic based on the parsed parameters
    }
}
