using Firebase.Firestore;
using Firebase.Storage;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;



public class DataUpdater : MonoBehaviour
{
    FirebaseFirestore db;

    // TODO: assign gameobjects from scene
    public VenueManager venueManager;


    private Venue venue;
    private VenueBookable[] venueBookables;

    private List<string> friendList;


    public UserManager userManager;




    public void StartUpdatingSystemAnnouncement()
    {
        // get current venue (only need to update data for current venue)
        db = FirebaseFirestore.DefaultInstance;
    }

    public void StartUpdatingFriendsList()
    {
        // get current venue (only need to update data for current venue)
        db = FirebaseFirestore.DefaultInstance;
    }

    public void StartUpdatingCommunityChat()
    {
        // get current venue (only need to update data for current venue)
        db = FirebaseFirestore.DefaultInstance;
    }

    public void StartUpdatingUsers()
    {
        // get current venue (only need to update data for current venue)
        db = FirebaseFirestore.DefaultInstance;
    }



    public void StartUpdatingBookables()
    {
        // get current venue (only need to update data for current venue)
        db = FirebaseFirestore.DefaultInstance;
        // Start coroutine to update bookable availability every 10 seconds
        StartCoroutine(UpdateBookableAvailabilityPeriodically());
    }

    private IEnumerator UpdateBookableAvailabilityPeriodically()
    {
        while (true)
        {
            //Debug.Log("updating information");
            UpdateBookableAvailability();
            yield return new WaitForSeconds(10);
        }
    }

    private async void UpdateBookableAvailability()
    {
        venue = venueManager.venue;
        venueBookables = venue.venueBookables;

        foreach (VenueBookable venueBookable in venueBookables)
        {
            if (venueBookable == null)
            {
                continue;
            }

            string id = venueBookable.id;

            //Debug.Log($"start updating bookable availability for id {id}");
            DocumentReference docRef = db.Collection("venues_bookables").Document(id);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            if (venueBookable.slots == null)
            {
                venueBookable.slots = new Dictionary<string, List<int>>();
            }
            if (venueBookable.available == null)
            {
                venueBookable.available = new Dictionary<string, List<int>>();
            }
            if (venueBookable.booked == null)
            {
                venueBookable.booked = new Dictionary<string, Dictionary<int, string>>();
            }

            Dictionary<string, object> data = snapshot.ToDictionary();

            //TODO: implement has change logic;
            bool hasChanges = false;


            // assign all data retrieved into scriptable objects

            // Update the slots
            if (data.ContainsKey("slots"))
            {
                var newSlots = ConvertToDictionary(data["slots"]);

                if (!AreDictionariesEqual(venueBookable.slots, newSlots))
                {
                    venueBookable.slots = newSlots;
                    hasChanges = true;
                }

                
            }

            // Update the available
            if (data.ContainsKey("available"))
            {
                var newAvailable = ConvertToDictionary(data["available"]);

                //Debug.Log("Converted Successfully!!!!!!!!");
                if (!AreDictionariesEqual(venueBookable.available, newAvailable))
                {
                    venueBookable.available = newAvailable;
                    hasChanges = true;
                }
            }

            //// Update the booked
            ///TODO: uncomment this after correction of logic
            if (data.ContainsKey("booked"))
            {
                var newBooked = ConvertToBookedDictionary(data["booked"]);


                if (!AreDictionariesEqual(venueBookable.booked, newBooked))
                {
                    venueBookable.booked = newBooked;
                    hasChanges = true;
                }
            }


            // Update Firebase if there are changes

            // TODO: after correction of updating logic, uncomment this
            //if (hasChanges)
            //{
            //    UpdateBookableInFirebase(venueBookable);
            //}
        }   
    }



    // TODO: this update back logic is not correct
    private async void UpdateBookableInFirebase(VenueBookable venueBookable)
    {
        DocumentReference docRef = db.Collection("venues_bookables").Document(venueBookable.id);
        Dictionary<string, object> data = new Dictionary<string, object>
        {
            { "slots", venueBookable.slots },
            { "available", venueBookable.available },
            { "booked", venueBookable.booked }
        };

        await docRef.SetAsync(data, SetOptions.MergeAll);
    }


    private bool AreDictionariesEqual(Dictionary<string, List<int>> dict1, Dictionary<string, List<int>> dict2)
    {
        if (dict1.Count != dict2.Count)
            return false;

        foreach (var pair in dict1)
        {
            if (!dict2.ContainsKey(pair.Key) || !AreListsEqual(pair.Value, dict2[pair.Key]))
                return false;
        }

        return true;
    }

    private bool AreDictionariesEqual(Dictionary<string, Dictionary<int, string>> dict1, Dictionary<string, Dictionary<int, string>> dict2)
    {
        if (dict1.Count != dict2.Count)
            return false;

        foreach (var pair in dict1)
        {
            if (!dict2.ContainsKey(pair.Key) || !AreDictionariesEqual(pair.Value, dict2[pair.Key]))
                return false;
        }

        return true;
    }

    private bool AreListsEqual(List<int> list1, List<int> list2)
    {
        if (list1.Count != list2.Count)
            return false;

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
                return false;
        }

        return true;
    }

    private bool AreDictionariesEqual(Dictionary<int, string> dict1, Dictionary<int, string> dict2)
    {
        if (dict1.Count != dict2.Count)
            return false;

        foreach (var pair in dict1)
        {
            if (!dict2.ContainsKey(pair.Key) || dict2[pair.Key] != pair.Value)
                return false;
        }

        return true;
    }

    private Dictionary<string, List<int>> ConvertToDictionary(object data)
    {
        Dictionary<string, object> dict = data as Dictionary<string, object>;
        Dictionary<string, List<int>> result = new Dictionary<string, List<int>>();

        foreach (KeyValuePair<string, object> entry in dict)
        {
            List<int> list = new List<int>();
            foreach (var item in (List<object>)entry.Value)
            {
                list.Add(int.Parse(item.ToString()));
            }
            result.Add(entry.Key, list);
        }

        return result;
    }


    private Dictionary<string, Dictionary<int, string>> ConvertToBookedDictionary(object data)
    {
        Dictionary<string, object> dict = (Dictionary<string, object>)data;
        Dictionary<string, Dictionary<int, string>> result = new Dictionary<string, Dictionary<int, string>>();


        foreach(KeyValuePair<string, object> entry in dict)
        {

            Dictionary<string, object> value = (Dictionary<string, object>)entry.Value;
            if (value == null) { Debug.LogError("null value exception"); }

            Dictionary<int, string> innerDict = new Dictionary<int, string>();

            foreach (KeyValuePair<string, object> innerEntry in value)
            {
                innerDict.Add(int.Parse(innerEntry.Key.ToString()), innerEntry.Value.ToString());
            }

            result.Add(entry.Key, innerDict);
        }

        return result;
    }



    private void updateUsers()
    {
        // TODO: update users in the venue periodically
        // TODO: user database in unity construction
    }
}
