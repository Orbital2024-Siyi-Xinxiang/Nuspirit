using UnityEngine;

[CreateAssetMenu(fileName = "VenueInteractable", menuName = "Scriptable Objects/VenueInteractable")]
public class VenueInteractable : ScriptableObject
{
    public string id;
    public string interactableName;
    public Vector2 position;

    public string interactionType; // e.g., "stairs", "chair"
}