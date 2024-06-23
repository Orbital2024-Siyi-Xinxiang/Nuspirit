using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileSet", menuName = "Scriptable Objects/TileSet")]
public class TileSet : ScriptableObject
{
    public TileBase[] tiles;
}
