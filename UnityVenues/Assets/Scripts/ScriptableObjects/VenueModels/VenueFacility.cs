using UnityEngine;

[CreateAssetMenu(fileName = "VenueFacility", menuName = "Scriptable Objects/VenueFacility")]
public class VenueFacility : ScriptableObject
{
    public string id;
    public string category;
    public Vector2 position;
    public Vector2 size;
    public GameObject facility;
}