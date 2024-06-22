using UnityEngine;

public class Interactable : MonoBehaviour
{
    public VenueInteractable interactableData;

    void Start()
    {
        interactableData = ScriptableObject.CreateInstance<VenueInteractable>();
    }

    public void Initialize(VenueInteractable interactableData)
    {
        this.interactableData = interactableData;
    }

    void Update()
    {
        // Interactable-specific update logic can be added here
    }
}
