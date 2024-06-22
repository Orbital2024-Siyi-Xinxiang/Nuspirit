using UnityEngine;
using System.Collections;

public class TransferPoint : MonoBehaviour
{
    public VenueTransferPoint transferPointData;

    void Start()
    {
        transferPointData = ScriptableObject.CreateInstance<VenueTransferPoint>();
    }

    public void Initialize(VenueTransferPoint transferPointData)
    {
        this.transferPointData = transferPointData;
    }

    void Update()
    {
        // TransferPoint-specific update logic can be added here
    }
}
