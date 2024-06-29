using Firebase.Database;
using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class DatabaseInitializer : MonoBehaviour
{
    private DatabaseReference databaseRef;

    void Start()
    {
        Debug.Log("Starting Database Initialization...");
        StartCoroutine(WaitForFirebaseConfigInitialization());
    }

    private IEnumerator WaitForFirebaseConfigInitialization()
    {
        while (FirebaseConfig.Instance == null || !FirebaseConfig.Instance.IsInitialized)
        {
            Debug.Log("Waiting for FirebaseConfig initialization...");
            yield return new WaitForSeconds(0.5f);
        }

        databaseRef = FirebaseConfig.Instance.RootReference;
        Debug.Log("Database reference obtained.");
        CheckAndInitializeDatabase();
    }

    private void CheckAndInitializeDatabase()
    {
        Debug.Log("Checking Database Initialization...");
        DatabaseReference initCheckRef = databaseRef.Child("initialized");
        Task<DataSnapshot> checkTask = initCheckRef.GetValueAsync();

        Task.WhenAny(checkTask, Task.Delay(10000)).ContinueWith(t =>
        {
            if (checkTask.IsCompleted)
            {
                Debug.Log("Check task completed.");
                if (checkTask.Result != null && checkTask.Result.Exists)
                {
                    Debug.Log("Database already initialized.");
                }
                else
                {
                    Debug.Log("Database not initialized, initializing now...");
                    InitializeDatabase();
                }
            }
            else
            {
                Debug.LogError("Failed to check database initialization: " + checkTask.Exception);
            }
        });
    }

    private void InitializeDatabase()
    {
        Debug.Log("Initializing Database...");
        var initialData = new
        {
            initialized = true,
            users = new { },
            assets = new
            {
                arts = new
                {
                    defaultMaps = "",
                    outdoorBackground = "",
                    outdoorBuildings = "",
                    indoorFurniture = "",
                    indoorWalls = "",
                    indoorFloors = "",
                    avatar = ""
                },
                sounds = new
                {
                    undecided = ""
                }
            }
        };

        Task setValueTask = databaseRef.SetValueAsync(initialData);

        Task.WhenAny(setValueTask, Task.Delay(10000)).ContinueWith(t =>
        {
            if (setValueTask.IsCompleted)
            {
                if (setValueTask.IsFaulted)
                {
                    Debug.LogError("Failed to initialize database: " + setValueTask.Exception);
                }
                else
                {
                    Debug.Log("Database initialized successfully.");
                }
            }
            else
            {
                Debug.LogError("Failed to initialize database within the timeout period.");
            }
        });
    }
}
