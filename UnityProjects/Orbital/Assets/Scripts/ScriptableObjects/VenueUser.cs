using UnityEngine;

// every scene transfer accompanied by change of venue data
[CreateAssetMenu(fileName = "VenueUser", menuName = "Scriptable Objects/VenueUser")]
public class VenueUser : ScriptableObject
{
    public string id; // user id
    public string status;
    public Sprite sprite;
    public Vector2 size;

    public GameObject user;
}

