using UnityEngine;
using TMPro;
using System;
using Firebase.Firestore;
using System.Collections.Generic;
using System.Linq;
using Firebase.Extensions;
using System.Threading.Tasks;
using UnityEngine.UI;
using System.Collections;
using static UnityEngine.EventSystems.EventTrigger;

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

    // TODO: delete this. instead of assigning from the scene, get the two dropdowns from prefab "bookingSelectionPrefab"
    public TMP_Dropdown chooseDayOptions;
    public TMP_Dropdown chooseTimeOptions;

    //TODO: assign in unity editor
    public VenueManager venueManager;
    public GameStateManager gameStateManager;
    public Button createBookingButton;
    public Button removeBookingButton;
    public Button clearAllBookingsButton;
    public GameObject bookingSelectionPrefab;
    public ConfirmAction confirmActionPanel;
    public GameObject warningPanel;
    public UrlSchemeHandler urlSchemeHandler;
    public GameObject dateTitles;
    public GameObject highlightCurrentDate;

   
    // size data for booked and unbooked layouts
    private static float width;
    private static float addHeight;
    private static float height;
    private static float initX;
    private static float initY;

    
    // size data for user booking layout  
    private static float bookingSelectionHeight;
    private static float bookingSelectionWidth;
    private static float singleSlotSelectionHeight;
    private static float singleSlotSelectionWidth;
    private static float initBookingX;
    private static float initBookingY;



    private string venueName;
    private string userId;
    private Dictionary<string, int> dayDict;
    private Dictionary<string, string> dateDict;  // eg.: 20240724: monday,..
    private Dictionary<string, List<int>> availableDict;
    private Dictionary<string, List<int>> selectedBookings;
    private List<string> selectedDays = new List<string>(); // this list is for 
    private List<int> selectionNums; // for example, selected two days, one day one slots and another day two slots, then it's [1,2]

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
        AssignSizeData();
        AssignDayDict();
        AssighDateDict();
        availableDict = new Dictionary<string, List<int>>();
        selectionNums = new List<int>();
        selectedBookings = new Dictionary<string, List<int>>();
        selectedDays = new List<string>();

        ResetButtonPositions();
    }

    private void ResetButtonPositions()
    {
        createBookingButton.transform.position = new Vector2(createBookingButton.transform.localPosition.x, initBookingY);
        removeBookingButton.transform.position = new Vector2(removeBookingButton.transform.localPosition.x, initBookingY);
    }
    
    public async void InitializeData(VenueBookable data)
    {
        db = FirebaseFirestore.DefaultInstance;

        bookableData = data;
        userId = urlSchemeHandler.userId;

        // make them async
        StartCoroutine(UpdateVenueOpenPanel());
        StartCoroutine(UpdateUserBookingPanel());
        StartCoroutine(UpdateHistoryBookingInfo());
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
            //Debug.Log("start assigning basic info for venue bookable");
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
                    venueCapacityText.text = "Capacity: " + bookableData.capacity.ToString();
                }
            }
            else
            {
                Debug.LogError("bookableName not found");
            }


            // TODO: assign open info and slots as well

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

        AssignDateInfo();

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

    private Task RefreshUserBookingPanel()
    {
        // TODO: initialize layouts
        DocumentReference docRef = db.Collection("users").Document(userId);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DocumentSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    foreach (Transform child in UserBookingPanel.transform)
                    {
                        if (child.gameObject.name == "BookingSelection" || child.gameObject.name == "BookingSelection(Clone)")
                            Destroy(child.gameObject);
                    }

                    Dictionary<string, object> documentFields = snapshot.ToDictionary();
                    foreach (KeyValuePair<string, object> dateField in documentFields)
                    {
                        Dictionary<string, int> value = (Dictionary<string, int>)dateField.Value;

                        if (value != null)
                        {
                            if (value["bookable_id"].ToString() == bookableData.id)
                            {
                                if (dateField.Key.Length == 12)
                                {
                                    string dateString = dateField.Key.Substring(0, 9);
                                }
                                else
                                {
                                    Debug.LogError($"{dateField.Key} doesn't fit requirement for proper booking slot YYYYMMDDHHMM");
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("cannot convert users_bookings fields correctly to dictionary");
                        }
                    }

                }
                else
                {
                    Debug.LogError("Failed to get document: " + task.Exception);
                }
            }
        });


        // add listeners to three buttons for managing booking selections
        createBookingButton.onClick.AddListener(CreateBooking);
        removeBookingButton.onClick.AddListener(RemoveBooking);
        clearAllBookingsButton.onClick.AddListener(ClearAllBookings);
        // Clear existing options
        chooseDayOptions.ClearOptions();

        // Get the days that have at least one available slot
        List<string> availableDays = availableDict.Keys.Where(day => availableDict[day].Count > 0).ToList();

        // Populate the chooseDayOptions dropdown
        chooseDayOptions.AddOptions(availableDays);

        // Add listener to update time options when a day is selected
        chooseDayOptions.onValueChanged.AddListener(delegate { UpdateTimeOptions(chooseDayOptions.options[chooseDayOptions.value].text); });

        // Initialize the time options for the first available day
        if (availableDays.Count > 0)
        {
            UpdateTimeOptions(availableDays[0]);
        }

        return Task.CompletedTask;
    }

    public void CreateBooking()
    {
        if (selectionNums.Sum() >= 5)
        {
            ShowWarning("cannot book more than 5 slots");
            return;
        }

        string initialDay = availableDict.Keys.FirstOrDefault(day => availableDict[day].Count > 0);
        if (initialDay == null)
        {
            ShowWarning("No available slots");
            return;
        }

        int initialSlot = availableDict[initialDay].First();
        GameObject bookingSelection = Instantiate(bookingSelectionPrefab, UserBookingPanel.transform);

        TMP_Dropdown dayDropdown = bookingSelection.transform.Find("ChooseDay").GetComponent<TMP_Dropdown>();
        TMP_Dropdown timeDropdown = bookingSelection.transform.Find("ChooseTime").GetComponent<TMP_Dropdown>();

        dayDropdown.ClearOptions();
        dayDropdown.AddOptions(new List<string> { initialDay });
        timeDropdown.ClearOptions();
        timeDropdown.AddOptions(new List<string> { $"{initialSlot / 100:00}:{initialSlot % 100:00} - {initialSlot / 100 + 1:00}:{initialSlot % 100:00}" });

        Transform chooseTimeTransform = bookingSelection.transform.Find("ChooseTime");
        Transform addBtn = chooseTimeTransform.GetChild(0);
        Transform removeBtn = chooseTimeTransform.GetChild(1);
        addBtn.gameObject.SetActive(true);
        removeBtn.gameObject.SetActive(false);

        if (!selectedBookings.ContainsKey(initialDay))
        {
            selectedBookings.Add(initialDay, new List<int>());
        }

        selectedBookings[initialDay].Add(initialSlot);

        selectedSlots.Add(initialSlot);
        selectedDays.Add(initialDay);
        selectionNums.Add(1);

        UpdatePanelLayout();
        SaveBookingToFirebase(initialDay, initialSlot);
    }

    public void RemoveBooking()
    {
        if (selectionNums.Count == 0)
        {
            ShowWarning("No user booking found!");
            return;
        }

        if (UserBookingPanel.transform.childCount > 0)
        {
            GameObject lastBookingSelection = UserBookingPanel.transform.GetChild(UserBookingPanel.transform.childCount - 1).gameObject;
            TMP_Dropdown dayDropdown = lastBookingSelection.transform.Find("ChooseDay").GetComponent<TMP_Dropdown>();
            TMP_Dropdown timeDropdown = lastBookingSelection.transform.Find("ChooseTime").GetComponent<TMP_Dropdown>();

            string day = dayDropdown.options[dayDropdown.value].text;
            int slot = int.Parse(timeDropdown.options[timeDropdown.value].text.Split(':')[0]) * 100;

            selectedSlots.Remove(slot);
            selectedDays.Remove(day);
            selectionNums.RemoveAt(selectionNums.Count - 1);
            selectedBookings[day].Remove(slot);
            if (selectedBookings[day].Count == 0)
            {
                selectedBookings.Remove(day);
            }

            Destroy(lastBookingSelection);
            UpdatePanelLayout();
            RemoveBookingFromFirebase(day, slot);
        }
    }

    public void ClearAllBookings()
    {
        if (selectionNums.Count == 0)
        {
            ShowWarning("No user booking found!");
            return;
        }

        selectedDays.Clear();
        selectionNums.Clear();
        selectedBookings.Clear();

        foreach (Transform child in UserBookingPanel.transform)
        {
            Destroy(child.gameObject);
        }

        UpdatePanelLayout();
        ClearAllBookingsFromFirebase();
    }

    private void UpdatePanelLayout()
    {
        float newPosY = initY - (selectionNums.Count * (singleSlotSelectionHeight + addHeight));
        createBookingButton.transform.localPosition = new Vector2(createBookingButton.transform.localPosition.x, newPosY);
        removeBookingButton.transform.localPosition = new Vector2(removeBookingButton.transform.localPosition.x, newPosY);
        RectTransform panelRect = UserBookingPanel.GetComponent<RectTransform>();
        panelRect.sizeDelta = new Vector2(panelRect.sizeDelta.x, -newPosY + singleSlotSelectionHeight);

        foreach (Transform child in UserBookingPanel.transform)
        {
            child.localPosition = new Vector2(child.localPosition.x, child.localPosition.y - singleSlotSelectionHeight - addHeight);
        }
    }

    private void UpdateTimeOptions(string day)
    {
        // Clear existing options
        chooseTimeOptions.ClearOptions();

        if (availableDict.ContainsKey(day))
        {
            // Get available slots for the selected day
            List<int> availableSlots = availableDict[day];

            // Convert slots to strings and add to dropdown options
            List<string> timeOptions = availableSlots.Select(slot => $"{slot / 100:00}:{slot % 100:00} - {slot / 100 + 1:00}:{slot % 100:00} ").ToList();
            chooseTimeOptions.AddOptions(timeOptions);

            // Add listener for selecting a time slot
            chooseTimeOptions.onValueChanged.AddListener(delegate { SelectTimeSlot(day, availableSlots[chooseTimeOptions.value]); });
        }
    }

    private void SelectTimeSlot(string day, int startTime)
    {
        // TODO: implement add and delete booking details logic 
        if (selectedSlots.Count < 5 && !selectedSlots.Contains(startTime))
        {
            selectedSlots.Add(startTime);
            Debug.Log($"Selected {day} {startTime / 100:00}:{startTime % 100:00}");

            SaveBookingToFirebase(day, startTime);
        }
        else if (selectedSlots.Contains(startTime))
        {
            selectedSlots.Remove(startTime);
            Debug.Log($"Deselected {day} {startTime / 100:00}:{startTime % 100:00}");
        }
        else
        {
            Debug.LogWarning("You can only select up to 5 slots.");
        }

        // Optionally, update UI or provide feedback to the user here
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
    private void InstantiateBooked(string day, int start, string bookerId)
    {
        //print($"instantiating booked {day} {start}, {userId}");
        int index = (start - 600) / 100;
        int div = index / 3;
        float distanceH = index * height + div * addHeight;

        Vector2 position = new Vector2(initX + dayDict[day] * width, initY - distanceH);
        GameObject rect = Instantiate(booked, position, Quaternion.identity);

        rect.transform.SetParent(VenueOpenPanel.transform, false);

        // TODO: Add button click listener to show bookerPanel
        Transform bookerPanel = rect.transform.GetChild(0);

        //rect.GetComponent<Button>().onClick.AddListener(() => bookerPanel.SetActive(true));

        Booker booker = rect.GetComponent<Booker>();
        if (booker != null)
        {
            booker.id = bookerId;
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
    private void AssignDateDict()
    {
        dateDict = new Dictionary<string, string>();
        foreach (KeyValuePair<string, int> dayPair in dayDict)
        {
            string day = dayPair.Key;
            int value = dayPair.Value;


            //// Your code here
            //Debug.Log("Day: " + day + ", Value: " + value);
        }
    }

    // Method to show the warning message
    private void ShowWarning(string message)
    {
        // Find the first child and get its TMP_Text component
        TMP_Text warningMessage = warningPanel.transform.GetChild(0).GetComponent<TMP_Text>();

        if (warningMessage != null)
        {
            // Set the warning message text
            warningMessage.text = message;

            // Activate the warning panel
            warningPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("Warning message TMP_Text component not found in the first child of warningPanel.");
        }
    }

    private void AssignSizeData()
    {
        // initialize size data for booked and unbooked layouts
        width = 55.89012f;
        addHeight = 11.22769f - 10.6666f;
        height = 10.6666f;
        initX = -168.4268f;
        initY = 76.55177f;

        // initialize size data for user booking
        bookingSelectionHeight = 73.4867f;
        bookingSelectionWidth = 419.831f;
        singleSlotSelectionHeight = 36.743f;
        initBookingX = 8f;
        initBookingY = 25.328f;
    }

    private void SaveBookingToFirebase(string day, int startTime)
    {

        Dictionary<string, object> bookingData = new Dictionary<string, object>
        {
            { "userId", userId },
            { "slots", selectedSlots },
            { "bookable_id", bookableData.id },
            { "venue_id", gameStateManager.venueId },
            { "unity_venue_id", venueManager.venue.id }
        };

        db.Collection("users_bookings").Document(userId)
            .SetAsync(bookingData).ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted && !task.IsFaulted)
                {
                    Debug.Log("Booking successfully saved.");
                    LoadVenueOpenPanel();
                }
                else
                {
                    Debug.LogError("Failed to save booking: " + task.Exception);
                }
            });
    }

    private void RemoveBookingFromFirebase(string day, int startTime)
    {
        db.Collection("users_bookings").Document(userId)
            .UpdateAsync(new Dictionary<string, object> { { "slots", FieldValue.ArrayRemove(startTime) } })
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted && !task.IsFaulted)
                {
                    Debug.Log("Booking successfully removed.");
                    LoadVenueOpenPanel();
                }
                else
                {
                    Debug.LogError("Failed to remove booking: " + task.Exception);
                }
            });
    }

    private void ClearAllBookingsFromFirebase()
    {
        db.Collection("users_bookings").Document(userId)
            .DeleteAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted && !task.IsFaulted)
                {
                    Debug.Log("All bookings successfully removed.");
                    LoadVenueOpenPanel();
                }
                else
                {
                    Debug.LogError("Failed to remove all bookings: " + task.Exception);
                }
            });
    }

    private void AssignDateInfo()
    {
        foreach (Transform child in dateTitles.transform)
        {
            string day = child.gameObject.name;
            DateTime dateTime = SystemTime
            .AddDate(SystemTime.dayDict[day] - SystemTime.dayDict[SystemTime.GetDayOfWeek(SystemTime.Now())]);
            child.gameObject.GetComponent<TMP_Text>().text = dateTime.Month + "/" + dateTime.Date;
        }

        // highligh the current date

        int dayNum = SystemTime.dayDict[SystemTime.GetDayOfWeek(SystemTime.Now())];
        float posx = width * dayNum - 130.8f;
        float posy = -42.4264f;
        highlightCurrentDate.transform.position = new Vector2(posx, posy);
    }

    private string CalculateDate(string day)
    {
        DateTime dateTime = SystemTime
            .AddDate(SystemTime.dayDict[day] - SystemTime.dayDict[SystemTime.GetDayOfWeek(SystemTime.Now())]);
        return SystemTime.GetYear(dateTime) + SystemTime.GetMonth(dateTime) + SystemTime.GetDate(dateTime);
    }

    private string CalculateDay(string date) // pass date in YYYYMMDD form
    {
        return dateDict[date];
    }


    // update every 3 seconds
    IEnumerator UpdateVenueOpenPanel()
    {
        while (true)
        {
            // Call your async method
            yield return LoadVenueOpenPanel();
            // Wait for 3 seconds before calling it again
            yield return new WaitForSeconds(3f);
        }
    }
    IEnumerator UpdateUserBookingPanel()
    {
        while (true)
        {
            // Your code to update user booking panel
            yield return RefreshUserBookingPanel();
            // Wait for 3 seconds before calling it again
            yield return new WaitForSeconds(3f);
        }
    }
    IEnumerator UpdateHistoryBookingInfo()
    {
        while (true)
        {
            // Your code to update history booking info
            yield return LoadHistoricalBookingInfo();
            // Wait for 3 seconds before calling it again
            yield return new WaitForSeconds(3f);
        }
    }
}
