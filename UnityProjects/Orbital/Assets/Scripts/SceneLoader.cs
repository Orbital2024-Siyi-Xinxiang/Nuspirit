using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;
    private string userId;

    public void SetUserId(string userId)
    {
        this.userId = userId;
    }

    public void SetUserScene(string scene)
    {
        if (sceneToLoad != scene)
        {
            sceneToLoad = scene;
            SceneManager.LoadScene(scene);
        }
    }

    private void Start()
    {
        sceneToLoad = "NoEntry";
        //LoadInitialScene(); // Load the initial scene based on your logic
    }

    public void LoadInitialScene()
    {
        if (SceneManager.GetActiveScene().name != "NoEntry")
        {
            SceneManager.LoadScene("NoEntry");
        }
    }

    public void Initialize(string userId, string scene, string venueId, string info)
    {
        Debug.Log($"Initializing Scene Loader with userID: {userId}, scene: {scene}, venueId: {venueId}");
        if (scene != "NoEntry")
        {
            sceneToLoad = scene;
            SceneManager.LoadScene(scene);
        }

        if (scene == "SpecificVenue")
        {

        }
    }
}
