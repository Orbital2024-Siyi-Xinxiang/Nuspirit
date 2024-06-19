using UnityEngine;

[CreateAssetMenu(fileName = "VenueTransferPoint", menuName = "Scriptable Objects/VenueTransferPoint")]
public class VenueTransferPoint : ScriptableObject
{
    public string id;
    public Vector2 position;
    public string[] to;
}