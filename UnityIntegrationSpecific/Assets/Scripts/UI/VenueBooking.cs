using UnityEngine;
using TMPro;

public class VenueBooking : MonoBehaviour
{
    public GameObject BasicInfo;
    public GameObject VenueOpenPanel;
    public GameObject UserBookingPanel;
    public GameObject HistoricalBookingInfo;
    public VenueBookable bookableData;

    public VenueManager venueManager;

    private static double width = 55.89012;
    private static double AddHieght = 11.22769;
    private static double height = 10.6666;
    private static double initX = -168.4268;
    private static double initY = 76.55177;
    private string venueName = "";

    void OnEnable()
    {
        if (venueManager != null)
        {
            venueName = venueManager.venue.name;
        }
        else
        {
            Debug.LogError("Invalid Venue Name");
        }

        AssignBasicInfo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void AssignBasicInfo()
    {
        if (BasicInfo != null)
        {
            // Find the child GameObjects and assign their TextMeshPro components
            Transform venueNameTransform = BasicInfo.transform.Find("VenueName");
            Transform bookableNameTransform = BasicInfo.transform.Find("BookableName");
            Transform venueCapacityTransform = BasicInfo.transform.Find("VenueCapacity");

            if (venueNameTransform != null)
            {
                TextMeshProUGUI venueNameText = venueNameTransform.GetComponent<TextMeshProUGUI>();
                if (venueNameText != null)
                {
                    venueNameText.text = venueName;
                }
            }

            if (bookableNameTransform != null)
            {
                TextMeshProUGUI bookableNameText = bookableNameTransform.GetComponent<TextMeshProUGUI>();
                if (bookableNameText != null)
                {
                    bookableNameText.text = bookableData.name;
                }
            }

            if (venueCapacityTransform != null)
            {
                TextMeshProUGUI venueCapacityText = venueCapacityTransform.GetComponent<TextMeshProUGUI>();
                if (venueCapacityText != null)
                {
                    venueCapacityText.text = bookableData.capacity.ToString();
                }
            }
        }
        else
        {
            Debug.LogError("BasicInfo GameObject is not assigned");
        }
    }
}
