using UnityEngine;

[CreateAssetMenu(fileName = "VenueBackground", menuName = "Scriptable Objects/VenueBackground", order = 1)]
public class VenueBackground : ScriptableObject
{
    public string id;

    public Texture2D backgroud;
    public Vector2 dimensions; // Dimensions of the floorplan in world units
    public Vector3[] pointsOfInterest; // Array of points of interest in the venue

}
