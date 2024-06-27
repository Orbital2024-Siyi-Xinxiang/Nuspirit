using UnityEngine;

public class Bookable : MonoBehaviour
{
    public VenueBookable bookableData;

    void Start()
    {
        // Ensure bookableData is initialized
        bookableData = ScriptableObject.CreateInstance<VenueBookable>();

    }

    public void Initialize(VenueBookable bookableData)
    {
        this.bookableData = bookableData;
    }

    void Update()
    {
        // Any additional update logic
    }

    void OnMouseDown()
    {
        Debug.Log("bookable touched!!!");
        // For iOS, use touch input instead of mouse input
        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                ShowBookVenueView(this.bookableData);
            }
        }
        else
        {
            // For other platforms, use mouse input
            ShowBookVenueView(this.bookableData);
        }
    }

    void ShowBookVenueView(VenueBookable data)
    {
        if (VenueBookingPanel.Instance != null)
        {
            VenueBookingPanel.Instance.ShowPanel();
            Transform scrollView = VenueBookingPanel.Instance.transform.Find("BookVenueScrollView");
            VenueBooking panel = scrollView.GetComponent<VenueBooking>();
            if (panel != null)
            {
                panel.bookableData = data;
            }
        }
        else
        {
            Debug.LogError("VenuePanel instance not found");
        }
    }
}
