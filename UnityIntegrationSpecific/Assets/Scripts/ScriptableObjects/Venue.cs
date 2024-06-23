using UnityEngine;

// every scene transfer accompanied by change of venue data
[CreateAssetMenu(fileName = "Venue", menuName = "Scriptable Objects/Venue")]
public class Venue: ScriptableObject
{
    public string id;

    public VenueBackground venueBackground;
    public VenueSolidLayer venueSolidLayer;
    public VenueInteractable[] venueInteractables;
    public VenueSolidObject[] venueSolidObjects;
    public VenueTransferPoint[] venueTransferPoints;
    public VenueFacility[] venueFacilities;
    public VenueBookable[] venueBookables;
}
