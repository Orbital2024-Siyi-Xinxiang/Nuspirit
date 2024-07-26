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
using System.Reflection;

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

    //TODO: assign in unity editor
    public VenueManager venueManager;
    public GameStateManager gameStateManager;
    public Button createBookingButton;
    public Button removeBookingButton;
    public Button clearAllBookingsButton;
    public GameObject bookingSelectionPrefab;
    public GameObject singleSlotSelectionPrefab;
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

    // universal info needed for assignment
    private string venueName;
    private string userId;

    // utilities
    private Dictionary<string, int> dayDict;
    private Dictionary<string, string> dateDict;  // eg.: 20240724: monday,..

    // state variables needed to keep track of
    private Dictionary<string, List<int>> availableDict;
    private Dictionary<string, List<int>> selectedBookings;
    private List<string> selectedDays = new List<string>(); // this list is for 

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
        AssignDateDict();



        availableDict = new Dictionary<string, List<int>>();
    
        selectedBookings = new Dictionary<string, List<int>>();
        selectedDays = new List<string>();
    }

    private void ResetButtonPositions()
    {
        createBookingButton.transform.position = new Vector2(createBookingButton.transform.localPosition.x, initBookingY);
        removeBookingButton.transform.position = new Vector2(removeBookingButton.transform.localPosition.x, initBookingY);
        foreach (Transform child in UserBookingPanel.transform)
        {
            if (child.gameObject.name == "BookingSelection" || child.gameObject.name == "BookingSelection(Clone)")
                Destroy(child.gameObject);
        }
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

    // TODO refresh more frequently (refresh availableDict as well for later updating user booking panel)
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
        DocumentReference docRef = db.Collection("users_bookings").Document(userId);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DocumentSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    // reset selectedBookings according to firebase firestore data users_bookings
                    selectedBookings = new Dictionary<string, List<int>>();
                    selectedDays = new List<string>();
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
                                    string timeString = dateField.Key.Substring(9, 12);
                                    string dayString = CalculateDay(dateString);

                                    if (selectedBookings.ContainsKey(dayString))
                                    {
                                        selectedBookings[dayString].Add(int.Parse(timeString));
                                        if (!selectedDays.Contains(dayString))
                                        {
                                            selectedDays.Add(dayString);
                                        }
                                    } else
                                    {
                                        selectedBookings.Add(dayString, new List<int>{ int.Parse(timeString) });
                                    }
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
                    // finish assigning selectedBookings

                    UpdatePanelLayout();

                }
                else
                {
                    Debug.LogError("Failed to get document: " + task.Exception);
                }
            }
        });

        return Task.CompletedTask;
    }

    // TODO
    public void CreateBooking()
    {
        if (CalculateSum(selectedBookings) >= 5)
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

        UpdatePanelLayout();
        SaveBookingToFirebase(initialDay, initialSlot);
    }

    //TODO
    public void RemoveBooking(string day)
    {
        if (CalculateSum(selectedBookings) == 0)
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


    //TODO
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
        ResetButtonPositions();

        float tempPosYChange = 0f;

        foreach (string day in selectedDays)
        {
            
            string dayString = day;
       
            if (!selectedBookings.ContainsKey(dayString))
            {
                Debug.LogError("selected bookings day doesn't match selectedDays list");
            }

            List<int> slots = selectedBookings[day];

            if (slots.Count == 0)
            {
                Debug.LogError($"selectedBooking malformatted: day {day} has no slots");
            }
            else
            {
                
                GameObject newSelection =
                        Instantiate(bookingSelectionPrefab, new Vector3(0, tempPosYChange, 0), Quaternion.identity);
                tempPosYChange += bookingSelectionHeight;
                // set initial slot selection
                TMP_Dropdown chooseDayOptions = newSelection.transform.GetChild(0).gameObject.GetComponentInChildren<TMP_Dropdown>();
                TMP_Dropdown chooseTimeOptions = newSelection.transform.GetChild(1).gameObject.GetComponentInChildren<TMP_Dropdown>();
                chooseDayOptions.ClearOptions();
                // Get the days that have at least one available slot
                List<string> availableDays = availableDict.Keys.Where(day => availableDict[day].Count > 0).ToList();
                // Populate the chooseDayOptions dropdown
                chooseDayOptions.AddOptions(availableDays);
                TMP_Dropdown.OptionData newOption = new TMP_Dropdown.OptionData(dayString);
                chooseDayOptions.options.Insert(0, newOption);
                chooseDayOptions.value = 0;
                int selectedSlot = slots[0];
                // Add listener to update time options when a day is selected
                string previous = chooseDayOptions.options[chooseDayOptions.value].text;
                
                UpdateTimeOptions(chooseTimeOptions, previous, selectedSlot);

                chooseDayOptions.onValueChanged.AddListener(delegate
                    {
                        CreateBooking(chooseDayOptions.options[chooseDayOptions.value].text);
                        RemoveBooking(previous); });


                for (int indexer = 1; indexer < slots.Count; indexer++)
                {

                    // Instantiate chooseTimeOptions
                    GameObject newSlot=
                        Instantiate(singleSlotSelectionPrefab,
                        (newSelection.transform.GetChild(1).gameObject.transform.position +
                        new Vector3(0, singleSlotSelectionHeight, 0)),
                        Quaternion.identity);
                    TMP_Dropdown newTimeOption = newSlot.GetComponent<TMP_Dropdown>();
                    tempPosYChange += singleSlotSelectionHeight;
                    int newSelectedSlot = slots[indexer];
                    UpdateTimeOptions(newTimeOption, previous, newSelectedSlot);

                }
                
                float posYChange = bookingSelectionHeight + (slots.Count - 1) * singleSlotSelectionHeight;
                createBookingButton.transform.position += new Vector3(0, posYChange, 0);
                removeBookingButton.transform.position += new Vector3(0, posYChange, 0);

            }

        }

        // add listeners to three buttons for managing booking selections
        createBookingButton.onClick.AddListener(delegate { CreateBooking(); });
        removeBookingButton.onClick.AddListener(delegate { RemoveBooking(selectedDays[-1]); });
        clearAllBookingsButton.onClick.AddListener(ClearAllBookings);

        RectTransform panelRect = UserBookingPanel.GetComponent<RectTransform>();
        panelRect.sizeDelta = new Vector2(panelRect.sizeDelta.x,
            createBookingButton.transform.position.y + singleSlotSelectionHeight);
    }

    private void UpdateTimeOptions(TMP_Dropdown chooseTimeOptions, string day, int selectedSlot)
    {
        chooseTimeOptions.ClearOptions();
        int previous = 0;
        // Clear existing option;

        if (availableDict.ContainsKey(day))
        {
            // Get available slots for the selected day
            List<int> availableSlots = availableDict[day];

            // Convert slots to strings and add to dropdown options
            List<string> timeOptions = availableSlots.Select(slot => $"{slot / 100:00}:{slot % 100:00} - {slot / 100 + 1:00}:{slot % 100:00} ").ToList();
            chooseTimeOptions.AddOptions(timeOptions);

            // Add listener for selecting a time slot
            chooseTimeOptions.onValueChanged.AddListener(delegate
            { SelectTimeSlot(day, availableSlots[chooseTimeOptions.value]);
                RemoveTimeSlot(day, previous);
            });
        }
    }

    //TODO:after selecting a time slot
    private void SelectTimeSlot(string day, int startTime)
    {
        // TODO: implement add and delete booking details logic
        // TODO: change availableDict and selectedBookings and selectedDays
        if (selectedBookings[day].Count < 5 && !selectedSlots.Contains(startTime))
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

    private void RemoveTimeSlot(string day, int startTime)
    {
        // TODO: implement add and delete booking details logic
        // TODO: change availableDict and selectedBookings and selectedDays
        if (selectedBookings[day].Count >= 1 && selectedBookings[day].Contains(startTime))
        {

        }
        else 
        {

        }
    }

    //TODO: history booking (other users bookings) using venues_bookables collection in firebase for data
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
            string dateKey = CalculateDate(day);
            dateDict.Add(dateKey, day);
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

    //TODO: update venues_bookables database logic as well
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

    //TODO: update venues_bookables database logic bookableData as well
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

    //TODO: update venues_bookables database logic bookableData as well
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
    private int CalculateSum(Dictionary<string, List<int>> selectedBookings)
    {
        int res = 0;
        foreach(KeyValuePair<string, List<int>> pair in selectedBookings)
        {
            res += pair.Value.Count;
        }
        return res;
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
