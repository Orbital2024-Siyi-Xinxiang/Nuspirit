using UnityEngine;

public class RemovingState : MonoBehaviour, IBuildingState
{
    private GridData gridData;

    void Start()
    {
        //gridData = FindObjectOfType<GridData>();
    }

    public void OnEnterState()
    {
        // Implement logic for entering the removing state
    }

    public void OnUpdate()
    {
        // Implement logic for updating the removing state
    }

    public void OnExitState()
    {
        // Implement logic for exiting the removing state
    }
}
