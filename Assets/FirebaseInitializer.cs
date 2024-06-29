using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class FirebaseInit : MonoBehaviour
{
    public static FirebaseInit Instance { get; private set; }

    public FirebaseAuth Auth { get; private set; }
    public FirebaseUser User { get; private set; }
    public DatabaseReference DatabaseReference { get; private set; }
    public bool IsInitialized { get; private set; } = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeFirebase();
    }

    private void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                if (task.Result == DependencyStatus.Available)
                {
                    FirebaseApp app = FirebaseApp.DefaultInstance;
                    Auth = FirebaseAuth.DefaultInstance;
                    DatabaseReference = FirebaseDatabase.DefaultInstance.RootReference;
                    IsInitialized = true;
                    Debug.Log("Firebase initialized successfully.");
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
