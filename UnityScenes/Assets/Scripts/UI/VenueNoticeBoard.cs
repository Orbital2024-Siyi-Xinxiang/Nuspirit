using UnityEngine;
using UnityEngine.UI;

public class VenueNoticeBoard : MonoBehaviour
{ 
    // Reference to the child GameObject
    public GameObject childObject;
    public DataUpdater dataUpdater;
    public CommunityChat communityChat;
    public Friends friendList;
    public Announcement systemAnnouncement;


    void OnEnable()
    {
        // Get the Button component attached to this GameObject
        Button button = GetComponent<Button>();

        if (button != null && childObject != null)
        {
            // Add a listener to call ToggleChild when the button is clicked
            button.onClick.AddListener(ToggleChild);
        }
        else
        {
            Debug.LogError("Button or Child Object is not assigned.");
        }
    }

    // Method to toggle the child's visibility
    void ToggleChild()
    {
        if (childObject != null)
        {
            // Toggle the active state of the child GameObject
            childObject.SetActive(!childObject.activeSelf);
        }
    }
}