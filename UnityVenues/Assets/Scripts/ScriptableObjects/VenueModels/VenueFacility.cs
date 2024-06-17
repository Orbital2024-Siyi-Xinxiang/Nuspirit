using UnityEngine;

[CreateAssetMenu(fileName = "VenueFacility", menuName = "Scriptable Objects/VenueFacility")]
public class VenueFacility : ScriptableObject
{
    public string id;
    public string facilityName;
    public Vector2 position;
}