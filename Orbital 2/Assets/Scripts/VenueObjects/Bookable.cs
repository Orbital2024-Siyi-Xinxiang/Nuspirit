using UnityEngine;

public class Bookable : MonoBehaviour
{
    public VenueBookable bookableData;
    private VenueBooking venueBooking;
    public static GameObject venueBookingPanel; // Reference to the booking panel GameObject

    void Start()
    {
        // Initialize static reference if not already set
        if (venueBookingPanel == null)
        {
            venueBookingPanel = GameObject.Find("bookVenuePanel"); // Replace with your actual GameObject name
            if (venueBookingPanel == null)
            {
                Debug.LogError("Failed to find bookVenuePanel GameObject in the scene!");
                return;
            }
        }

        // Ensure the panel is initially hidden
        if (venueBookingPanel.activeSelf)
        {
            venueBookingPanel.SetActive(false);
        }
    }

    private void Update()
    {
        // Check for touch input on iOS and Android
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Get the touch position
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            // Check if the touch hits the current object
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                OnMouseDown();
            }
        }
    }

    public void Initialize(VenueBookable bookableData)
    {
        this.bookableData = bookableData;
    }

    void OnMouseDown()
    {
        Debug.Log("bookable touched!!!");

        // Activate the booking panel using static reference
        if (venueBookingPanel != null)
        {
            venueBookingPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("venueBookingPanel is null!");
            return;
        }

        // Initialize VenueBooking instance if not already initialized
        if (venueBooking == null)
        {
            venueBooking = VenueBooking.Instance;
        }

        // Initialize data in venueBooking
        venueBooking.InitializeData(this.bookableData);

        // Additional logging
        Debug.Log($"Show book venue view and pass this bookable data with id {bookableData.id} into it");
    }

}
