using UnityEngine;
using System.Collections;

public class SolidObject : MonoBehaviour
{
    public VenueSolidObject solidObjectData;

    void Start()
    {
        solidObjectData = ScriptableObject.CreateInstance<VenueSolidObject>();
    }

    public void Initialize(VenueSolidObject solidObjectData)
    {
        this.solidObjectData = solidObjectData;
    }

    void Update()
    {
        // SolidObject-specific update logic can be added here
    }
}
