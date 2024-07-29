using UnityEngine;
using Firebase;

public class FirebaseInitializer : MonoBehaviour
{
    public static event System.Action FirebaseInitialized;

    public void Initialize()
    {
        // Check if Firebase is already initialized in Unity
        if (FirebaseApp.DefaultInstance != null)
        {
            // Firebase is already initialized
            FirebaseInitialized?.Invoke();
        }
        else
        {
            // Listen for Firebase initialization
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                if (task.Result == Firebase.DependencyStatus.Available)
                {
                    FirebaseInitialized?.Invoke();
                }
                else
                {
                    Debug.LogError("Could not resolve all Firebase dependencies: " + task.Result);
                }
            });
        }
    }
}
