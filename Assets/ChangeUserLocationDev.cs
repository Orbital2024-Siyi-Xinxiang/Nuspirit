using UnityEngine;
using Firebase.Database;

public class ChangeUserLocationDev : MonoBehaviour
{
    public string userId; // User ID to be set from the Inspector
    public float latitude; // Latitude to be set from the Inspector
    public float longitude; // Longitude to be set from the Inspector

    private DatabaseReference reference;

    void Start()
    {
        InitializeFirebase();
    }

    private void InitializeFirebase()
    {
        // Assuming FirebaseInitTemp is already initialized
        reference = FirebaseInitTemp.Instance.DatabaseReference;

        if (reference == null)
        {
            Debug.LogError("Failed to get Firebase reference from FirebaseInitTemp.");
        }
        else
        {
            Debug.Log("Firebase reference obtained successfully.");
        }
    }

    // Method to update the user's location
    public void UpdateUserLocation()
    {
        if (reference != null)
        {
            UserLocationData newLocation = new UserLocationData(latitude, longitude);
            string locationJson = JsonUtility.ToJson(newLocation);
            reference.Child("users").Child(userId).Child("location").SetRawJsonValueAsync(locationJson).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log($"User location for {userId} updated successfully.");
                }
                else
                {
                    Debug.LogError($"Failed to update user location for {userId}: {task.Exception}");
                }
            });
        }
        else
        {
            Debug.LogError("Database reference is not initialized.");
        }
    }
}
