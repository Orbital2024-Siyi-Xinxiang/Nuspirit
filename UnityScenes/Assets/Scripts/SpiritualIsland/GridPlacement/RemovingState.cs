using UnityEngine;
using UnityEngine.UI;

public class RemovingState : MonoBehaviour, IBuildingState
{
    public GridData gridData;
    public Button redoButton;
    public Button trash;
    GameObject objectToRemove;


    public void SetObjectToRemove(GameObject obj)
    {
        objectToRemove = obj;
    }

    void Start()
    {
        
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
