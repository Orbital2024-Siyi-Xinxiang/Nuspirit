using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AppInitializationManager : MonoBehaviour
{
    [Tooltip("Enter the name of the scene to load after initialization")]
    public string nextSceneName;  // Public property to set the scene name from the Inspector

    void Start()
    {
        StartCoroutine(InitializeAndLoadNextScene());
    }

    private IEnumerator InitializeAndLoadNextScene()
    {
        // Ensure FirebaseConfig is initialized
        while (FirebaseConfig.Instance == null || !FirebaseConfig.Instance.IsInitialized)
        {
            yield return null;
        }

        // Load the next scene once Firebase is initialized
        SceneManager.LoadScene(nextSceneName);
    }
}
