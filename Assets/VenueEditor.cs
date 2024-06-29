using System;
using UnityEngine;
using Firebase.Database;

public class VenueEditor : MonoBehaviour
{
    public string locationName;
    public bool isOutdoor;
    public bool hasAircon;
    public bool hasPrinter;
    public bool hasCharger;
    public bool hasMeetingRooms;
    public string openingTime;
    public string closingTime;
    public bool hasFoodCourtsAround;
    public float latitude;
    public float longitude;

    private DatabaseReference reference;

    void Start()
    {
        StartCoroutine(WaitForFirebaseInitialization());
    }

    private System.Collections.IEnumerator WaitForFirebaseInitialization()
    {
        while (!FirebaseConfig.Instance.IsInitialized)
        {
            yield return null;
        }

        reference = FirebaseConfig.Instance.RootReference;
        Debug.Log("VenueEditor: Firebase is initialized.");
    }

    public void SaveOrUpdateVenue()
    {
        Debug.Log("SaveOrUpdateVenue is called");
        if (!FirebaseConfig.Instance.IsInitialized)
        {
            Debug.LogError("Firebase is not initialized. Cannot save or update venue.");
            return;
        }

        FindVenueByName(locationName, (existingVenue) =>
        {
            if (existingVenue != null)
            {
                UpdateVenue(existingVenue);
            }
            else
            {
                CreateNewVenue();
            }
        });
    }

    private void FindVenueByName(string name, Action<VenuesData> callback)
    {
        reference.Child("venues").OrderByChild("name").EqualTo(name).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    foreach (DataSnapshot child in snapshot.Children)
                    {
                        VenuesData venue = JsonUtility.FromJson<VenuesData>(child.GetRawJsonValue());
                        callback(venue);
                        return;
                    }
                }
                callback(null);
            }
            else
            {
                Debug.LogError("Error finding venue: " + task.Exception);
                callback(null);
            }
        });
    }

    private void UpdateVenue(VenuesData venue)
    {
        venue.isOutdoor = isOutdoor;
        venue.hasAircon = hasAircon;
        venue.hasPrinter = hasPrinter;
        venue.hasCharger = hasCharger;
        venue.hasMeetingRooms = hasMeetingRooms;
        venue.openingTime = openingTime;
        venue.closingTime = closingTime;
        venue.hasFoodCourtsAround = hasFoodCourtsAround;
        venue.location = new LocationData(latitude, longitude);

        string venueJson = JsonUtility.ToJson(venue);
        reference.Child("venues").Child(locationName).SetRawJsonValueAsync(venueJson).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Venue updated successfully.");
            }
            else
            {
                Debug.LogError("Failed to update venue: " + task.Exception);
            }
        });
    }

    private void CreateNewVenue()
    {
        LocationData locationData = new LocationData(latitude, longitude);

        VenuesData newVenue = new VenuesData(
            locationName,
            locationData,
            isOutdoor,
            hasAircon,
            hasPrinter,
            hasCharger,
            hasMeetingRooms,
            openingTime,
            closingTime,
            hasFoodCourtsAround
        );

        string venueJson = JsonUtility.ToJson(newVenue);
        reference.Child("venues").Child(locationName).SetRawJsonValueAsync(venueJson).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("New venue created successfully.");
            }
            else
            {
                Debug.LogError("Failed to create new venue: " + task.Exception);
            }
        });
    }
}
