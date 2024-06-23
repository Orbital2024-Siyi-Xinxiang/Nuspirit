using UnityEngine;

[CreateAssetMenu(fileName = "VenueInteractable", menuName = "Scriptable Objects/VenueInteractable")]
public class VenueInteractable : ScriptableObject
{
    public string id;
    public string category; // e.g., "stairs", "chair"

    public Vector2 position;
    public Vector2 size;
    public Facility interactable;

}