using UnityEngine;

[CreateAssetMenu(fileName = "Venue", menuName = "Scriptable Objects/Venue")]
public class Venue: ScriptableObject
{
    public string id;
    public Texture2D floorPlan; // Assuming floorplans are stored as textures

    public VenueBackground venueBackground;
    public VenueInteractable[] venueInteractables;
    public VenueSolidObject[] venueSolidObjects;
    public VenueTransferPoint[] venueTransferPoints;
    public VenueFacility[] venueFacilities;
    public VenueBookable[] venueBookables;
    public VenueOtherUser[] venueOtherUsers;
}
