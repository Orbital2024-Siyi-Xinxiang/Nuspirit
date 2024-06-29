using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class FirebaseConfig : MonoBehaviour
{
    public static FirebaseConfig Instance { get; private set; }
    public string DatabaseUrl { get; private set; }
    public FirebaseApp App { get; private set; }
    public DatabaseReference RootReference { get; private set; }
    public bool IsInitialized { get; private set; }

    [SerializeField] private string databaseUrl;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            InitializeFirebase();
        }
    }

    private void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                App = FirebaseApp.DefaultInstance;
                DatabaseUrl = databaseUrl;
                RootReference = FirebaseDatabase.GetInstance(App, DatabaseUrl).RootReference;
                IsInitialized = true;
                Debug.Log("Firebase is ready to use.");
            }
            else
            {
                Debug.LogError($"Could not resolve all Firebase dependencies: {task.Result}");
                IsInitialized = false;
            }
        });
    }
}
