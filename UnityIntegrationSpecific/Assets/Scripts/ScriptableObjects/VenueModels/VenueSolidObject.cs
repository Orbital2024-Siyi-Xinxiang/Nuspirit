using UnityEngine;

[CreateAssetMenu(fileName = "VenueSolidObject", menuName = "Scriptable Objects/VenueSolidObject")]
public class VenueSolidObject : ScriptableObject
{
    public string id;

    public string category;
    public Vector2 position;
    public Vector2 size;
    public Sprite sprite;
    public SolidObject solidObject;
}