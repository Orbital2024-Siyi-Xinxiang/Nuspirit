using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;

public class AreaManager : MonoBehaviour
{
    public List<AreaData> areaRanges = new List<AreaData>();
    private DatabaseReference databaseReference;
    private FirebaseAuth auth;
    private FirebaseUser currentUser;

    void Start()
    {
        // Initialize Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            if (task.Result == DependencyStatus.Available)
            {
                auth = FirebaseAuth.DefaultInstance;
                auth.StateChanged += AuthStateChanged;
                AuthStateChanged(this, null); // Manually call to initialize the current user
                if (currentUser != null)
                {
                    databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
                    StartCoroutine(InitializeDataAndLoadScene());
                }
                else
                {
                    Debug.LogError("No user is currently signed in.");
                }
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + task.Result);
            }
        });
    }

    void OnDestroy()
    {
        if (auth != null)
        {
            auth.StateChanged -= AuthStateChanged;
        }
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != currentUser)
        {
            bool signedIn = currentUser != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && currentUser != null)
            {
                Debug.Log("Signed out " + currentUser.UserId);
            }
            currentUser = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + currentUser.UserId);
                if (databaseReference != null)
                {
                    StartCoroutine(InitializeDataAndLoadScene());
                }
            }
        }
    }

    private IEnumerator InitializeDataAndLoadScene()
    {
        yield return StartCoroutine(GetAreaDataFromDatabase());
        yield return StartCoroutine(GetUserLocationAndLoadScene());
    }

    private IEnumerator GetAreaDataFromDatabase()
    {
        var areaDataTask = databaseReference.Child("areas").GetValueAsync();
        yield return new WaitUntil(() => areaDataTask.IsCompleted);

        if (areaDataTask.Exception != null)
        {
            Debug.LogError("Failed to retrieve area data: " + areaDataTask.Exception);
            yield break;
        }

        DataSnapshot areaSnapshot = areaDataTask.Result;
        if (areaSnapshot.Exists)
        {
            areaRanges.Clear();
            foreach (DataSnapshot area in areaSnapshot.Children)
            {
                string sceneName = area.Child("sceneName").Value.ToString();
                List<LocationData> vertices = new List<LocationData>();
                foreach (DataSnapshot vertex in area.Child("vertices").Children)
                {
                    float latitude = float.Parse(vertex.Child("latitude").Value.ToString());
                    float longitude = float.Parse(vertex.Child("longitude").Value.ToString());
                    vertices.Add(new LocationData(latitude, longitude));
                }
                areaRanges.Add(new AreaData(sceneName, vertices));
            }
            Debug.Log("Area data loaded successfully.");
        }
        else
        {
            Debug.LogError("No area data found in the database.");
        }
    }

    private IEnumerator GetUserLocationAndLoadScene()
    {
        if (currentUser == null)
        {
            Debug.LogError("No user is currently signed in.");
            yield break;
        }

        var locationDataTask = databaseReference.Child("users").Child(currentUser.UserId).Child("location").GetValueAsync();
        yield return new WaitUntil(() => locationDataTask.IsCompleted);

        if (locationDataTask.Exception != null)
        {
            Debug.LogError("Failed to retrieve location data: " + locationDataTask.Exception);
            yield break;
        }

        DataSnapshot locationSnapshot = locationDataTask.Result;
        if (locationSnapshot.Exists)
        {
            float latitude = float.Parse(locationSnapshot.Child("latitude").Value.ToString());
            float longitude = float.Parse(locationSnapshot.Child("longitude").Value.ToString());
            LocationData userLocation = new LocationData(latitude, longitude);

            string sceneName = GetSceneNameForLocation(userLocation);
            if (!string.IsNullOrEmpty(sceneName))
            {
                Debug.Log($"User is in {sceneName} area.");
                SceneManager.LoadScene(sceneName); // Load the scene based on the user's location
            }
            else
            {
                Debug.LogError("No area found for current location.");
            }
        }
        else
        {
            Debug.LogError("Location data not found in the database.");
        }
    }

    public string GetSceneNameForLocation(LocationData userLocation)
    {
        foreach (var area in areaRanges)
        {
            if (IsPointInPolygon(userLocation, area.vertices))
            {
                return area.sceneName;
            }
        }
        return null; // Return null or a default scene if the location doesn't match any area
    }

    private bool IsPointInPolygon(LocationData point, List<LocationData> polygon)
    {
        int polygonLength = polygon.Count, i = 0;
        bool inside = false;
        LocationData endPoint1, endPoint2;
        for (endPoint1 = polygon[polygonLength - 1]; i < polygonLength; endPoint1 = endPoint2)
        {
            endPoint2 = polygon[i++];
            if (((endPoint2.longitude <= point.longitude && point.longitude < endPoint1.longitude) || (endPoint1.longitude <= point.longitude && point.longitude < endPoint2.longitude)) &&
                (point.latitude < (endPoint1.latitude - endPoint2.latitude) * (point.longitude - endPoint2.longitude) / (endPoint1.longitude - endPoint2.longitude) + endPoint2.latitude))
                inside = !inside;
        }
        return inside;
    }
}
