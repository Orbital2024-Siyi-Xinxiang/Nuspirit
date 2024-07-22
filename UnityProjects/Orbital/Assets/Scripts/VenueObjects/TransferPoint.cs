using UnityEngine;

public class TransferPoint: MonoBehaviour
{
    public VenueTransferPoint transferPointData;

    void Start()
    {
        transferPointData = ScriptableObject.CreateInstance<VenueTransferPoint>();
    }

    public void Initialize(VenueTransferPoint data)
    {
        this.transferPointData = data;
    }

    void Update()
    {
        // Interactable-specific update logic can be added here
    }
}
