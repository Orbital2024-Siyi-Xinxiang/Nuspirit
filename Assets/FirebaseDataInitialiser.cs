using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Auth;
using System.Threading.Tasks;

public class FirebaseDataInitializer : MonoBehaviour
{
    public static FirebaseDataInitializer Instance { get; private set; }
    private DatabaseReference reference;
    private List<UserData> usersData;
    private List<VenuesData> venuesData;
    private List<AreaData> areasData;
    public bool IsInitialized { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {

        Debug.Log("Starting Firebase initialization...");
        StartCoroutine(WaitForFirebaseInitialization());
    }

    private IEnumerator WaitForFirebaseInitialization()
    {
        while (!FirebaseConfig.Instance.IsInitialized)
        {
            yield return null;
        }

        Debug.Log("Firebase initialized.");
        reference = FirebaseConfig.Instance.RootReference;
        ClearDatabase(); // Clear the database before initializing
    }

    void ClearDatabase()
    {
        reference.SetValueAsync(null).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Database cleared successfully.");
                InitializeDatabaseStructure();
            }
            else
            {
                Debug.LogError("Failed to clear the database: " + task.Exception);
            }
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    void InitializeDatabaseStructure()
    {
        // Initialize users data with initial locations
        usersData = new List<UserData>
        {
            new UserData("user123new", "user1@example.com", "password1", "avatar1", true, true, false, true, true, "08:00 AM", "05:00 PM", true)
            {
                location = new UserLocationData(34.0521f, -118.2505f)
            },
            new UserData("user456", "user2@example.com", "password2", "avatar2", false, false, true, false, true, "09:00 AM", "06:00 PM", false)
            {
                location = new UserLocationData(37.7745f, -122.4205f)
            },
            new UserData("user789", "user3@example.com", "password3", "avatar3", true, false, false, true, false, "07:00 AM", "04:00 PM", true)
            {
                location = new UserLocationData(40.7128f, -74.0060f)
            }
        };


        // Initialize venues data
        venuesData = new List<VenuesData>
        {
            new VenuesData("Venue6", new LocationData(34.0522f, -118.2437f), true, false, true, true, false, "07:00 AM", "09:00 PM", true),
            new VenuesData("Venue7", new LocationData(37.7749f, -122.4194f), false, true, false, true, true, "08:00 AM", "08:00 PM", false),
            new VenuesData("Venue8", new LocationData(40.7128f, -74.0060f), false, true, true, false, false, "09:00 AM", "10:00 PM", true)
        };

        // Initialize area data with irregular shapes
        areasData = new List<AreaData>
        {
            new AreaData("SceneName1", new List<LocationData>
            {
                new LocationData(34.0520f, -118.2500f),
                new LocationData(34.0530f, -118.2550f),
                new LocationData(34.0550f, -118.2500f),
                new LocationData(34.0530f, -118.2450f),
                new LocationData(34.0520f, -118.2450f)
            }),
            new AreaData("SceneName2", new List<LocationData>
            {
                new LocationData(37.7740f, -122.4200f),
                new LocationData(37.7750f, -122.4250f),
                new LocationData(37.7760f, -122.4200f),
                new LocationData(37.7750f, -122.4150f),
                new LocationData(37.7740f, -122.4150f)
            }),
            new AreaData("SceneName3", new List<LocationData>
            {
                new LocationData(40.7120f, -74.0100f),
                new LocationData(40.7130f, -74.0150f),
                new LocationData(40.7150f, -74.0100f),
                new LocationData(40.7130f, -74.0050f),
                new LocationData(40.7120f, -74.0050f)
            })
        };

        // Initialize arts data
        ArtsData artsData = new ArtsData
        {
            defaultMaps = "map1",
            outdoorBackground = "background1",
            outdoorBuildings = "building1",
            indoorFurniture = "furniture1",
            indoorWalls = "wall1",
            indoorFloors = "floor1",
            avatar = "avatar1"
        };

        SoundsData soundsData = new SoundsData
        {
            undecided = "sound1"
        };

        // Serialize the users data to JSON and write it to the database
        foreach (var user in usersData)
        {
            string userJson = JsonUtility.ToJson(user);
            reference.Child("users").Child(user.ID).SetRawJsonValueAsync(userJson).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log($"User data for {user.ID} initialized successfully.");
                }
                else
                {
                    Debug.LogError($"Failed to initialize user data for {user.ID}: " + task.Exception);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        // Serialize the venues data to JSON and write it to the database
        foreach (var venue in venuesData)
        {
            string venueJson = JsonUtility.ToJson(venue);
            reference.Child("venues").Push().SetRawJsonValueAsync(venueJson).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log($"Venue data initialized successfully.");
                }
                else
                {
                    Debug.LogError($"Failed to initialize venue data: " + task.Exception);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        // Serialize the areas data to JSON and write it to the database
        foreach (var area in areasData)
        {
            string areaJson = JsonUtility.ToJson(area);
            reference.Child("areas").Push().SetRawJsonValueAsync(areaJson).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log($"Area data initialized successfully.");
                }
                else
                {
                    Debug.LogError($"Failed to initialize area data: " + task.Exception);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        // Serialize the artsData object to JSON and write it to the database
        string artsJson = JsonUtility.ToJson(artsData);
        reference.Child("arts").SetRawJsonValueAsync(artsJson).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Arts data initialized successfully.");
            }
            else
            {
                Debug.LogError("Failed to initialize arts data: " + task.Exception);
            }
        }, TaskScheduler.FromCurrentSynchronizationContext());

        // Serialize the soundsData object to JSON and write it to the database
        string soundsJson = JsonUtility.ToJson(soundsData);
        reference.Child("sounds").SetRawJsonValueAsync(soundsJson).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Sounds data initialized successfully.");
            }
            else
            {
                Debug.LogError("Failed to initialize sounds data: " + task.Exception);
            }
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
}
