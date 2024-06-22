using UnityEngine;
using Unity.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "VenueTransferPoint", menuName = "Scriptable Objects/VenueTransferPoint")]
public class VenueTransferPoint : ScriptableObject
{
    public string id;
    public Vector2 position;
    public List<string> to;
}