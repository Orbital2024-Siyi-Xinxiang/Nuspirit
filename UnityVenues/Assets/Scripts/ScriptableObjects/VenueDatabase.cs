using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VenueDatabase", menuName = "Scriptable Objects/VenueDatabase")]
public class VenueDatabase : ScriptableObject
{
    public List<Venue> venues = new List<Venue>();

    public Venue GetVenue(string id)
    {
        return venues.Find(venue => venue.id == id);
    }

    public void AddVenue(Venue venue)
    {
        if (!venues.Contains(venue))
        {
            venues.Add(venue);
        }
    }

    public void RemoveVenue(Venue venue)
    {
        if (venues.Contains(venue))
        {
            venues.Remove(venue);
        }
    }


}