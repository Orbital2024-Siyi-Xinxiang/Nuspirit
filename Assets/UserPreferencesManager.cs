using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class UserPreferencesManager : MonoBehaviour
{
    public Dropdown outdoorIndoorDropdown;
    public Dropdown hasAirconDropdown;
    public Dropdown hasPrinterDropdown;
    public Dropdown hasChargerDropdown;
    public Dropdown hasMeetingRoomsDropdown;
    public InputField openingTimeInput;
    public InputField closingTimeInput;
    public Dropdown hasFoodCourtsAroundDropdown;
    public Button savePreferencesButton;
    public Text feedbackText;
    public AreaManager areaManager; // Reference to AreaManager

    private DatabaseReference reference;
    private string userId;

    void Start()
    {
        reference = FirebaseConfig.Instance.RootReference;
        var currentUser = FirebaseAuth.DefaultInstance.CurrentUser;
        if (currentUser != null)
        {
            userId = currentUser.UserId;
            savePreferencesButton.onClick.AddListener(SavePreferences);
        }
        else
        {
            feedbackText.text = "Error: No user is currently logged in.";
        }
    }

    async void SavePreferences()
    {
        var userPreferences = new Dictionary<string, object>
        {
            { "isOutdoor", GetDropdownBoolValue(outdoorIndoorDropdown) },
            { "hasAircon", GetDropdownBoolValue(hasAirconDropdown) },
            { "hasPrinter", GetDropdownBoolValue(hasPrinterDropdown) },
            { "hasCharger", GetDropdownBoolValue(hasChargerDropdown) },
            { "hasMeetingRooms", GetDropdownBoolValue(hasMeetingRoomsDropdown) },
            { "openingTime", openingTimeInput.text },
            { "closingTime", closingTimeInput.text },
            { "hasFoodCourtsAround", GetDropdownBoolValue(hasFoodCourtsAroundDropdown) },
            { "PreferenceInitialized", true }
        };

        var task = reference.Child("users").Child(userId).UpdateChildrenAsync(userPreferences);

        try
        {
            await task;
            feedbackText.text = "Preferences saved successfully!";
            // Get user location and load respective scene
            StartCoroutine(GetUserLocationAndLoadScene());
        }
        catch (System.Exception e)
        {
            feedbackText.text = "Error saving preferences: " + e.Message;
        }
    }

    private bool? GetDropdownBoolValue(Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                return true;
            case 1:
                return false;
            case 2:
                return null; // "Doesn't Matter" case
            default:
                return null;
        }
    }

    private IEnumerator GetUserLocationAndLoadScene()
    {
        if (!Input.location.isEnabledByUser)
        {
            feedbackText.text = "Location services are not enabled by the user.";
            yield break;
        }

        Input.location.Start();

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            feedbackText.text = "Unable to determine device location.";
            yield break;
        }
        else
        {
            LocationData userLocation = new LocationData(Input.location.lastData.latitude, Input.location.lastData.longitude);
            string sceneName = areaManager.GetSceneNameForLocation(userLocation);
            if (!string.IsNullOrEmpty(sceneName))
            {
                SceneManager.LoadScene(sceneName); // Load the scene based on the user's location
            }
            else
            {
                feedbackText.text = "No area found for current location.";
            }
        }

        Input.location.Stop();
    }
}
