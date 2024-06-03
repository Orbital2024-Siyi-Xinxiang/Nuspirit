using UnityEngine;

public interface IBuildingState
{
    void OnEnterState();
    void OnUpdate();
    void OnExitState();
}
