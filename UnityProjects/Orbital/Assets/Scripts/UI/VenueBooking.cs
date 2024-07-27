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
        //TODO: only for debugging delete this
        print(SystemTime.GetDayOfWeek(SystemTime.Now()));
        print(SystemTime.GetMonth(SystemTime.Now()));
        print(SystemTime.GetYear(SystemTime.Now()));
        print(SystemTime.GetDate(SystemTime.Now()));
        print(SystemTime.GetHour(SystemTime.Now()));
        print(SystemTime.GetMinute(SystemTime.Now()));
        print(SystemTime.GetHHMM(SystemTime.Now()));
        print(SystemTime.GetYYYYMMDD(SystemTime.Now()));

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

        // for debug testing
        Debug.Log($"CalculateDate('mon'): 20240729  {CalculateDate("mon")}");
        Debug.Log($"CalculateDate('sat'): 20240727 {CalculateDate("sat")}");
        Debug.Log($"CalculateDate('monday'): {CalculateDate("monday")}");
        Debug.Log($"CalculateDate('monday'): {CalculateDate("monday")}");
        Debug.Log($"CalculateDate('monday'): {CalculateDate("monday")}");
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

    // TODO handle maximum booking num
    public void CreateBooking()
    {
        if (CalculateSum(selectedBookings) >= 5)
        {
            ShowWarning("Cannot book more than 5 slots!");
            return;
        }

        int flag = 0;

        foreach (string availableDay in availableDict.Keys.ToList())
        {
            if (!selectedDays.Contains(availableDay))
            {
                CreateBooking(availableDay);
                flag = 1;
                break;
            }
        }
        if (flag == 0)
        {
            ShowWarning("No other available day!");
        }
    }

    public void CreateBooking(string day)
    {
        if (CalculateSum(selectedBookings) >= 5)
        {
            ShowWarning("cannot book more than 5 slots");
            return;
        }

        if (!selectedDays.Contains(day))
        {
            selectedDays.Add(day);
        }
        else
        {
            Debug.LogError($"day {day} already exists!!!");
        }

        if (!availableDict.ContainsKey(day))
        {
            Debug.LogError("no available key found!!!");
        } else
        {
            if (availableDict[day].Count == 0)
            {
                Debug.LogError($"no available slot for day {day}");
            }
            else
            {
                int initialSlot = availableDict[day].First();
                SelectTimeSlot(day, initialSlot);
            }

        }
  
    }

    public void RemoveBooking(string day)
    {
        if (CalculateSum(selectedBookings) == 0)
        {
            ShowWarning("No user booking found!");
            return;
        }
        if (!selectedDays.Contains(day))
        {
            Debug.LogWarning($"Trying to remove a non-existent day {day}");
            return;
        }
        else
        {
            selectedDays.Remove(day);
        }
        if (!selectedBookings.ContainsKey(day))
        {
            Debug.LogError($"Trying to remove a non-existent day for selectedBookings {day}");
            return;
        }
        foreach (int slot in selectedBookings[day])
        {
            RemoveTimeSlot(day, slot);
        }
    }

    public void ClearAllBookings()
    {
        if (CalculateSum(selectedBookings) == 0)
        {
            ShowWarning("No user booking found!");
            return;
        }
        selectedDays.Clear();
        foreach (KeyValuePair<string, List<int>> bookingPair in selectedBookings)
        {
            RemoveBooking(bookingPair.Key);
        }
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
                List<string> availableDays = availableDict.Keys.Where(day => availableDict[day].Count > 0 && day != dayString).ToList();
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

                if (slots.Count == 1)
                {
                    Transform chooseTimeTransform = chooseTimeOptions.transform;
                    Transform addBtn = chooseTimeTransform.GetChild(0);
                    Transform removeBtn = chooseTimeTransform.GetChild(1);
                    addBtn.gameObject.SetActive(true);
                    removeBtn.gameObject.SetActive(false);
                    addBtn.gameObject.GetComponent<Button>().onClick.AddListener(delegate { SelectTimeSlot(dayString); });
                }
                else
                {
                    for (int indexer = 1; indexer < slots.Count; indexer++)
                    {

                        // Instantiate chooseTimeOptions
                        GameObject newSlot =
                            Instantiate(singleSlotSelectionPrefab,
                            (newSelection.transform.GetChild(1).gameObject.transform.position +
                            new Vector3(0, singleSlotSelectionHeight, 0)),
                            Quaternion.identity);
                        TMP_Dropdown newTimeOption = newSlot.GetComponent<TMP_Dropdown>();
                        tempPosYChange += singleSlotSelectionHeight;
                        int newSelectedSlot = slots[indexer];
                        UpdateTimeOptions(newTimeOption, previous, newSelectedSlot);

                        if (indexer == slots.Count - 1)
                        {
                            Transform chooseTimeTransform = newTimeOption.transform;
                            Transform addBtn = chooseTimeTransform.GetChild(0);
                            Transform removeBtn = chooseTimeTransform.GetChild(1);
                            addBtn.gameObject.SetActive(true);
                            removeBtn.gameObject.SetActive(true);
                            addBtn.gameObject.GetComponent<Button>().onClick.AddListener(delegate { SelectTimeSlot(dayString); });
                            removeBtn.gameObject.GetComponent<Button>().onClick.AddListener(delegate { RemoveTimeSlot(dayString, newSelectedSlot); });
                        }

                    }
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
        // Clear existing option;
        chooseTimeOptions.ClearOptions();
        int previous = selectedSlot;
        

        if (availableDict.ContainsKey(day))
        {
            // Get available slots for the selected day
            List<int> availableSlots = availableDict[day];
            // Convert slots to strings and add to dropdown options
            List<string> timeOptions = availableSlots.Select(slot => $"{slot / 100:00}:{slot % 100:00} - {slot / 100 + 1:00}:{slot % 100:00} ").ToList();
            chooseTimeOptions.AddOptions(timeOptions);


        }
        // add selected slot to options

        TMP_Dropdown.OptionData newOption = new TMP_Dropdown.OptionData($"{selectedSlot / 100:00}:{selectedSlot % 100:00} - {selectedSlot / 100 + 1:00}:{selectedSlot % 100:00} ");
        chooseTimeOptions.options.Insert(0, newOption);
        // Add listener for selecting a time slot
        chooseTimeOptions.onValueChanged.AddListener(delegate
        {
            if (chooseTimeOptions.value == 0)
            {
                Debug.LogWarning("change time option invalid");
            }
            else
            {
                List<int> availableSlots = availableDict.ContainsKey(day) ? availableDict[day] : new List<int>();
                SelectTimeSlot(day, availableSlots[chooseTimeOptions.value - 1]);
                RemoveTimeSlot(day, previous);
            }
        });

    }

    //TODO: handle maximum select time slot
    private void SelectTimeSlot(string day)
    {
        if (CalculateSum(selectedBookings)>= 5)
        {
            ShowWarning("Cannot book more than 5 slots");
        }
        if (!availableDict.ContainsKey(day))
        {
            ShowWarning($"no more available slot for day {day}!");
        }
        else if (!(availableDict[day].Count > 0))
        {
            availableDict.Remove(day);
        }
        else
        {
            int selectedSlot = availableDict[day].First();
            SelectTimeSlot(day, selectedSlot);
        }

    }

    private void SelectTimeSlot(string day, int startTime)
    {
        if (CalculateSum(selectedBookings) < 5)
        {
            // update selected bookings
            if (!selectedBookings.ContainsKey(day))
            {
                selectedBookings.Add(day, new List<int> { startTime });
            }
            else if (!selectedBookings[day].Contains(startTime))
            {
                selectedBookings[day].Add(startTime);
            }
            else
            {
                Debug.LogError($"already selected slot {startTime}");
            }
            

            // update availableDict
            if (!availableDict.ContainsKey(day))
            {
                Debug.LogError($"unavailable day {day}");
            }
            else if (!availableDict[day].Contains(startTime))
            {
                Debug.LogError($"unavailable slot {startTime}");
            }
            else
            {
                availableDict[day].Remove(startTime);
            }

            SaveBookingToDatabase(day, startTime);

        } else
        {
            ShowWarning("Cannot book more than 5 slots!");
        }

        UpdatePanelLayout();
    }
    private void RemoveTimeSlot(string day, int startTime)
    {
        // TODO: change availableDict and selectedBookings and selectedDays
        if (!selectedBookings.ContainsKey(day))
        {
            Debug.LogError("trying to remove a non-existent slot!");
            return;
        }
        else
        {
            if (selectedBookings[day].Count >= 1 && selectedBookings[day].Contains(startTime))
            {
                selectedBookings[day].Remove(startTime);
                RemoveBookingFromDatabase(day, startTime);
            }
            else
            {
                Debug.LogError("trying to delete a non-existing slot");
            }
        }

        if (!availableDict.ContainsKey(day))
        {
            availableDict.Add(day, new List<int> { startTime });
        }

        else if (availableDict[day].Contains(startTime))
        {
            Debug.LogError("already have slot in availableDict");
        }
        else
        {
            availableDict[day].Add(startTime);
        }

        UpdatePanelLayout();
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

    private void SaveBookingToDatabase(string day, int startTime)
    {
        string keyString = CalculateDate(day) + startTime.ToString();
        // Create a dictionary to represent the map field
        Dictionary<string, int> mapField = new Dictionary<string, int>
        {
            { "bookable_id", int.Parse(bookableData.id)},
            { "unity_venue_id", int.Parse(venueManager.venue.id) },
            { "venue_id", (gameStateManager.venueId) }
        };

        Dictionary<string, object> dataToSave = new Dictionary<string, object>
        {
            { keyString, mapField},
        };

        db.Collection("users_bookings").Document(userId)
            .SetAsync(dataToSave).ContinueWithOnMainThread(task =>
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

        // change bookableData.booked
        bookableData.available[day].Add(startTime);
        bookableData.available[day].Add(startTime + 100);

        bookableData.booked[day].Add(startTime, urlSchemeHandler.userId);
        bookableData.booked[day].Add(startTime + 100, urlSchemeHandler.userId);
        LoadVenueOpenPanel();
    }


    private void RemoveBookingFromDatabase(string day, int startTime)
    {
        // Create a dictionary to hold the update data
        Dictionary<string, object> updates = new Dictionary<string, object>
        {
            { CalculateDate(day) + startTime.ToString(), FieldValue.Delete }
        };

        db.Collection("users_bookings").Document(userId)
            .UpdateAsync(updates)
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

        // change bookableData.booked
        bookableData.booked[day].Remove(startTime);
        bookableData.booked[day].Remove(startTime + 100);

        bookableData.available[day].Remove(startTime);
        bookableData.available[day].Remove(startTime + 100);
        LoadVenueOpenPanel();
        // change bookableData.available
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
