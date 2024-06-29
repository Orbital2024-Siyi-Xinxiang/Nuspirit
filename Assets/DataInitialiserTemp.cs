using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using System.Threading.Tasks;

public class DataInitialiserTemp : MonoBehaviour
{
    public static DataInitialiserTemp Instance { get; private set; }
    private DatabaseReference reference;
    private List<VenuesData> venuesData;
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
        while (FirebaseInitTemp.Instance == null || !FirebaseInitTemp.Instance.IsInitialized)
        {
            Debug.Log("Waiting for FirebaseInitTemp to be initialized...");
            yield return null;
        }

        Debug.Log("Firebase initialized.");
        reference = FirebaseInitTemp.Instance.DatabaseReference;
        ClearDatabase();
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
        UserData placeholderUserData = new UserData(
            id: "", 
            email: "", 
            password: "",
            avatarDesign: "",
            isOutdoor: false,
            hasAircon: false,
            hasPrinter: false,
            hasCharger: false,
            hasMeetingRooms: false,
            openingTime: "",
            closingTime: "",
            hasFoodCourtsAround: false
        );
        
        string placeholderUserJson = JsonUtility.ToJson(placeholderUserData);
        reference.Child("users").Child("placeholder").SetRawJsonValueAsync(placeholderUserJson).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Placeholder user data initialized successfully.");
                InitializeVenuesData();
            }
            else
            {
                Debug.LogError("Failed to initialize placeholder user data: " + task.Exception);
            }
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    void InitializeVenuesData()
    {
        venuesData = new List<VenuesData>
        {
            new VenuesData("Venue1", new LocationData(34.0522f, -118.2437f), true, false, true, true, false, "07:00", "21:00", true),
            new VenuesData("Venue2", new LocationData(37.7749f, -122.4194f), false, true, false, true, true, "08:00", "20:00", false),
            new VenuesData("Venue3", new LocationData(40.7128f, -74.0060f), false, true, true, false, false, "09:00", "22:00", true),
            new VenuesData("Venue4", new LocationData(48.8566f, 2.3522f), true, true, false, true, true, "06:00", "23:00", true),
            new VenuesData("Venue5", new LocationData(51.5074f, -0.1278f), false, false, true, false, true, "07:00", "22:00", false)
        };

        foreach (var venue in venuesData)
        {
            VenuesData newVenue = new VenuesData(
                venue.name,
                venue.location,
                venue.isOutdoor,
                venue.hasAircon,
                venue.hasPrinter,
                venue.hasCharger,
                venue.hasMeetingRooms,
                venue.openingTime,
                venue.closingTime,
                venue.hasFoodCourtsAround
            );

            string venueJson = JsonUtility.ToJson(newVenue);
            Debug.Log("Venue JSON: " + venueJson);

            reference.Child("venues").Child(venue.name).SetRawJsonValueAsync(venueJson).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("Venue data initialized successfully.");
                }
                else
                {
                    Debug.LogError("Failed to initialize venue data: " + task.Exception);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        InitializeAreasData();
        InitializeArtsData();
        InitializeSoundsData();

        IsInitialized = true;
        Debug.Log("DataInitialiserTemp initialization completed.");
    }


    

    void InitializeAreasData()
    {
        // Existing area data initialization logic
        List<AreaData> areasData = new List<AreaData>
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

        foreach (var area in areasData)
        {
            string areaJson = JsonUtility.ToJson(area);
            reference.Child("areas").Push().SetRawJsonValueAsync(areaJson).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("Area data initialized successfully.");
                }
                else
                {
                    Debug.LogError("Failed to initialize area data: " + task.Exception);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }

    void InitializeArtsData()
    {
        // Existing arts data initialization logic
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
    }

    void InitializeSoundsData()
    {
        // Existing sounds data initialization logic
        SoundsData soundsData = new SoundsData
        {
            undecided = "sound1"
        };

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
