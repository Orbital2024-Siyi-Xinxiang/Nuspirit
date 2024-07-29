using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "VenueBackground", menuName = "Scriptable Objects/VenueBackground", order = 1)]
public class VenueBackground : ScriptableObject
{
    public string id;
    public TileSet tileSet;
    public Vector2 dimension;

    public Tilemap background;
}


