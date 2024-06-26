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
                ShowBookVenueView();
            }
        }
        else
        {
            // For other platforms, use mouse input
            ShowBookVenueView();
        }
    }

    void ShowBookVenueView()
    {
        if (VenuePanel.Instance != null)
        {
            VenuePanel.Instance.ShowPanel();
        }
        else
        {
            Debug.LogError("VenuePanel instance not found");
        }
    }
}
