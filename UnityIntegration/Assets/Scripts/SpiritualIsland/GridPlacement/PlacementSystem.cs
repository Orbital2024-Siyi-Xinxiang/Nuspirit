using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    public ObjectPlacer objectPlacer;

    void Start()
    {
        objectPlacer.enabled = true;

        // hide the scroll view of asset selection when starting the placement system.
        HideAssetSelection();
    }

    void Update()
    {
        // Ensure the object placer updates each frame
    }

    void HideAssetSelection()
    {

    }
}
