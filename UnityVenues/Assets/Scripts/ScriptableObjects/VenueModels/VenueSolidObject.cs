using UnityEngine;

[CreateAssetMenu(fileName = "VenueSolidObject", menuName = "Scriptable Objects/VenueSolidObject")]
public class VenueSolidObject : ScriptableObject
{
    public string id;
    public string objectName;
    public Vector2 position;
}