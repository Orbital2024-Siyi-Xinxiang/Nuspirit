using UnityEngine;

[CreateAssetMenu(fileName = "VenueOtherUser", menuName = "Scriptable Objects/VenueOtherUser")]
public class VenueOtherUser : ScriptableObject
{
    public string userId;
    public Vector2 position;
}