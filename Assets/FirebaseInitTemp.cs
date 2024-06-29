using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class FirebaseInitTemp : MonoBehaviour
{
    public static FirebaseInitTemp Instance { get; private set; }

    public FirebaseAuth Auth { get; private set; }
    public FirebaseUser User { get; private set; }
    public DatabaseReference DatabaseReference { get; private set; }
    public bool IsInitialized { get; private set; }

    void Awake()
    {
        // Ensure that only one instance of FirebaseInit exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        // Initialize Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            if (task.IsCompleted)
            {
                if (task.Result == DependencyStatus.Available)
                {
                    FirebaseApp app = FirebaseApp.DefaultInstance;
                    Debug.Log("Firebase initialized successfully.");

                    // Initialize Firebase Auth
                    Auth = FirebaseAuth.DefaultInstance;
                    DatabaseReference = FirebaseDatabase.DefaultInstance.RootReference;
                    IsInitialized = true;
                    Debug.Log("Firebase Auth and Database initialized successfully.");
                }
                else
                {
                    Debug.LogError($"Could not resolve all Firebase dependencies: {task.Result}");
                }
            }
            else
            {
                Debug.LogError("Failed to check and fix Firebase dependencies.");
                Debug.LogError(task.Exception.ToString());
            }
        });
    }
}
