using UnityEngine;

public class PlacementState : MonoBehaviour, IBuildingState
{
    private ObjectPlacer objectPlacer;

    void Start()
    {
        objectPlacer = FindObjectOfType<ObjectPlacer>();
    }

    public void OnEnterState()
    {
        // Implement logic for entering the placement state
        // Example: Enable the object placer
        objectPlacer.enabled = true;
    }

    public void OnUpdate()
    {
        // Implement logic for updating the placement state
    }

    public void OnExitState()
    {
        // Implement logic for exiting the placement state
        // Example: Disable the object placer
        objectPlacer.enabled = false;
    }
}
