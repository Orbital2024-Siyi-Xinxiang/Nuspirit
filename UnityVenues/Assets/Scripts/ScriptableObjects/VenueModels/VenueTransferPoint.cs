using UnityEngine;

[CreateAssetMenu(fileName = "VenueTransferPoint", menuName = "Scriptable Objects/VenueTransferPoint")]
public class VenueTransferPoint : ScriptableObject
{
    public string id;
    public string transferPointName;
    public Vector2 position;
    public string targetVenueId;
}