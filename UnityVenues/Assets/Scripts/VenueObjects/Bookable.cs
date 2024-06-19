using UnityEngine;
using System.Collections.Generic;

public class Bookable : MonoBehaviour
{
    public VenueBookable bookableData;

    public List<int> available;

    public List<int> slotBookable;
    
    public List<int> booked;

    public void Initialize(VenueBookable bookableData)
    {
        this.bookableData = bookableData;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
