using UnityEngine;

[CreateAssetMenu(fileName = "VenueSolidObject", menuName = "Scriptable Objects/VenueSolidObject")]
public class VenueSolidObject : ScriptableObject
{
    public string id;
    public Vector2 position;
    public Vector2 size;
    public GameObject solidObject;
}