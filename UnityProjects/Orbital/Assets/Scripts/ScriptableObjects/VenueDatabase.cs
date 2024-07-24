using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VenueDatabase", menuName = "Scriptable Objects/VenueDatabase")]
public class VenueDatabase : ScriptableObject
{
    private List<Venue> venues = new List<Venue>();

    private void OnEnable()
    {    
        venues.Clear();
    } 
 
    public Venue GetVenue(string id)
    {
        Venue venue = venues.Find(venue => venue.id == id);
        if (venue != null)
        {
            Debug.Log($"Venue found: {venue.id}");
        }
        else
        {
            Debug.Log($"Venue with ID {id} not found");
        }
        return venue;
    }

    public void AddVenue(Venue venue)
    {
        if (!venues.Contains(venue))
        {
            venues.Add(venue);
            //Debug.Log($"Venue added: {venue.id}");
        }
        else
        {
            //Debug.Log($"Venue already exists: {venue.id}");
        }
    }

    public void RemoveVenue(Venue venue)
    {
        if (venues.Contains(venue))
        {
            venues.Remove(venue);
            Debug.Log($"Venue removed: {venue.id}");
        }
        else
        {
            Debug.Log($"Venue not found in the list: {venue.id}");
        }
    }
}
