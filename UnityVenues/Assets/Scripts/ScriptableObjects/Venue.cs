using UnityEngine;

[CreateAssetMenu(fileName = "Venue", menuName = "Scriptable Objects/Venue")]
public class Venue: ScriptableObject
{
    public string id;

    public Texture2D floorPlan; // Assuming floorplans are stored as textures

    public Vector2 dimensions; // Dimensions of the background in world units
    public Vector3[] pointsOfInterest; // Array of points of interest in the venue

    public VenueBackground venueBackground;
    public VenueInteractable[] venueInteractables;
    public VenueSolidObject[] venueSolidObjects;
    public VenueTransferPoint[] venueTransferPoints;
    public VenueFacility[] venueFacilities;
    public VenueBookable[] venueBookables;
    public VenueOtherUser[] venueOtherUsers;
}
