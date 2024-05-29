using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    public ObjectPlacer objectPlacer;

    void Start()
    {
        objectPlacer.enabled = true;
    }

    void Update()
    {
        // Ensure the object placer updates each frame
    }
}
