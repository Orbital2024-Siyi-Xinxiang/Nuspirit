using UnityEngine;
using TMPro;
using Firebase.Firestore;
using System.Collections.Generic;
using System.Linq;
using Firebase.Extensions;
using System.Threading.Tasks;
using UnityEngine.UI;

public class VenueBooking : MonoBehaviour
{
    private FirebaseFirestore db;

    public GameObject BasicInfo;
    public GameObject VenueOpenPanel;
    public GameObject UserBookingPanel;
    public GameObject HistoricalBookingInfo;

    public VenueBookable bookableData;

    public GameObject booked;
    public GameObject unBooked;
    public GameObject bookerPanel;
    public GameObject chooseDayOptions;
    public GameObject chooseTimeOptions;


    public VenueManager venueManager;

    private static float width;
    private static float addHeight;
    private static float height;
    private static float initX;
    private static float initY;

    private string venueName;
    private Dictionary<string, int> dayDict;
    private Dictionary<string, List<int>> availableDict;


    // Singleton instance
    public static VenueBooking Instance;

    void Start()
    {
        // Ensure there is only one instance of VenueBooking
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple instances of VenueBooking found!");
            Destroy(gameObject); // Destroy the duplicate instance
        }
    }


    void OnEnable()
    {
        width = 55.89012f;
        addHeight = 11.22769f - 10.6666f;
        height = 10.6666f;
        initX = -168.4268f;
        initY = 76.55177f;

        AssignDayDict();
        availableDict = new Dictionary<string, List<int>>();

    }

    public async void InitializeData(VenueBookable data)
    {
        db = FirebaseFirestore.DefaultInstance;
        bookableData = data;
        // make them async
        await AssignBasicInfo();
        await LoadVenueOpenPanel();
        await RefreshUserBookingPanel();
        await LoadHistoricalBookingInfo();
    }

    private Task AssignBasicInfo()
    {

        
        if (BasicInfo != null)
        {
            // Find the child GameObjects and assign their TextMeshPro components


            Debug.Log("start assigning basic info for venue bookable");
            Transform venueNameTransform = BasicInfo.transform.Find("VenueName");
            Transform bookableNameTransform = BasicInfo.transform.Find("BookableName");
            Transform venueCapacityTransform = BasicInfo.transform.Find("VenueCapacity");

            if (venueManager != null)
            {
                venueName = venueManager.venue.name;
            }
            else
            {
                venueName = "";
                Debug.LogError("Invalid Venue Name");
            }

            if (venueNameTransform != null)
            {
                TextMeshProUGUI venueNameText = venueNameTransform.GetComponent<TextMeshProUGUI>();
                if (venueNameText != null)
                {
                    venueNameText.text = venueName;
                }
            }
            else
            {
                Debug.LogError("venueName not found");
            }

            if (bookableNameTransform != null)
            {
                TextMeshProUGUI bookableNameText = bookableNameTransform.GetComponent<TextMeshProUGUI>();

                if (bookableNameText != null)
                {

                    bookableNameText.text = bookableData.bookableName;
                }
            }
            else
            {
                Debug.LogError("bookableName not found");
            }

            if (venueCapacityTransform != null)
            {
                TextMeshProUGUI venueCapacityText = venueCapacityTransform.GetComponent<TextMeshProUGUI>();
                if (venueCapacityText != null)
                {
                    venueCapacityText.text = bookableData.capacity.ToString();
                }
            }
            else
            {
                Debug.LogError("bookableName not found");
            }
        }
        else
        {
            Debug.LogError("BasicInfo GameObject is not assigned");
        }

        return Task.CompletedTask;
    }

    private Task LoadVenueOpenPanel()
    {
        // Clear any existing children in VenueOpenPanel to prevent duplicates
        foreach (Transform child in VenueOpenPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Iterate through the booked slots
        foreach (var dayEntry in bookableData.booked)
        {
            string day = dayEntry.Key;
            Dictionary<int, string> bookedSlots = dayEntry.Value;

            // sort the pairs of bookedSlots in ascending order 
            List<int> sortedKeys = bookedSlots.Keys.ToList();
            sortedKeys.Sort(); // This uses QuickSort internally for performance

            for (int i = 0; i < sortedKeys.Count; i += 2)
            {
                int startTime = sortedKeys[i];
                int endTime = sortedKeys[i + 1];

                if (bookedSlots[startTime] != bookedSlots[endTime])
                {
                    Debug.LogError($"Error with booked data, inconsistency of booker, expecting {startTime}({bookedSlots[startTime]}) = {endTime}({bookedSlots[endTime]}), ");
                    break;
                }

                string bookerId = bookedSlots[startTime];
                for (int time = startTime; time < endTime; time += 100)
                {

                    InstantiateBooked(day, time, bookedSlots[startTime]);
                }
            }

            
        }

        // Iterate through the available slots
        foreach (var dayEntry in bookableData.available)
        {
            string day = dayEntry.Key;
            List<int> availableSlots = dayEntry.Value;

            List<int> list = new List<int>();

            for (int i = 0; i < availableSlots.Count; i += 2)
            {
                int startTime = availableSlots[i];
                int endTime = availableSlots[i + 1];

                for (int time = startTime; time < endTime; time += 100)
                {
                    // Check if this slot is booked
                    InstantiateUnBooked(day, time);
                    list.Add(time);
                }
            }

            availableDict.Add(day, list);
        }

        return Task.CompletedTask;
    }

    // TODO: refresh the booking panel when clicked 
    private Task RefreshUserBookingPanel()
    {
        // Set selected booking data to Monday as default
        // For each day assign the available slots to the dropdown menu

        Dictionary<string, List<int>> slots = bookableData.available;

            return Task.CompletedTask;
    }

    private Task LoadHistoricalBookingInfo()
    {
        // Implement historical booking info logic here
        return Task.CompletedTask;
    }

    private void InstantiateUnBooked(string day, int start)
    {
        int index = (start - 600) / 100;
        int div = index / 3;
        float distanceH = index * height + div * addHeight;

        Vector2 position = new Vector2(initX + dayDict[day] * width, initY - distanceH);
        GameObject rect = Instantiate(unBooked, position, Quaternion.identity);

        rect.transform.SetParent(VenueOpenPanel.transform, false);
        // Set additional properties for the unbooked window if needed
    }

    private void InstantiateBooked(string day, int start, string userId)
    {
        int index = (start - 600) / 100;
        int div = index / 3;
        float distanceH = index * height + div * addHeight;

        Vector2 position = new Vector2(initX + dayDict[day] * width, initY - distanceH);
        GameObject rect = Instantiate(booked, position, Quaternion.identity);

        rect.transform.SetParent(VenueOpenPanel.transform, false);

        // Add button click listener to show bookerPanel
        rect.GetComponent<Button>().onClick.AddListener(() => bookerPanel.SetActive(true));

        Booker booker = rect.GetComponent<Booker>();
        if (booker != null)
        {
            booker.id = userId;
            // Retrieve user information directly from Firebase
            RetrieveUserInfo(booker);
        }
    }

    private void RetrieveUserInfo(Booker booker)
    {
        db.Collection("users").Document(booker.id).GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted && !task.IsFaulted)
            {
                DocumentSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    Dictionary<string, object> userData = snapshot.ToDictionary();
                    // Assuming Booker has fields to display user info
                    booker.name = userData["name"].ToString();
                    booker.email = userData["email"].ToString();
                    booker.major = userData["major"].ToString();
                    booker.Initialize();
                    // Assign other fields as necessary
                }
                else
                {
                    Debug.LogError("User data not found");
                }
            }
            else
            {
                Debug.LogError("Failed to retrieve user data: " + task.Exception);
            }
        });
    }

    private void AssignDayDict()
    {
        dayDict = new Dictionary<string, int>();
        dayDict.Add("mon", 1);
        dayDict.Add("tue", 2);
        dayDict.Add("wed", 3);
        dayDict.Add("thu", 4);
        dayDict.Add("fri", 5);
        dayDict.Add("sat", 6);
        dayDict.Add("sun", 0);
    }
}
