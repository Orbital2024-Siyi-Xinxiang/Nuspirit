using UnityEngine;

[CreateAssetMenu(fileName = "VenueBackgroundDatabaseSP", menuName = "Scriptable Objects/VenueBackgroundDatabaseSP", order = 1)]
public class VenueBackgroundDatabaseSO : ScriptableObject
{
    public string id;
    public string venueName;
    public Texture2D floorPlan; // Assuming floorplans are stored as textures
    public Vector2 dimensions; // Dimensions of the floorplan in world units
    public Vector3[] pointsOfInterest; // Array of points of interest in the venue
}
