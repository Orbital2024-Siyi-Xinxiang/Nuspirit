using UnityEngine;
using System.Collections.Generic;

public class Bookable : MonoBehaviour
{
    public VenueBookable bookableData;

    public List<int> available;

    public List<int> slotBookable;

    public List<int> booked;

    void Start()
    {
        bookableData = ScriptableObject.CreateInstance<VenueBookable>();
    }

    public void Initialize(VenueBookable bookableData)
    {
        this.bookableData = bookableData;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
