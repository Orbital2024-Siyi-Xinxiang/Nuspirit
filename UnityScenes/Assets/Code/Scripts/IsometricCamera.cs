using UnityEngine;

public class IsometricCamera : MonoBehaviour
{
    public Transform target; // The target to follow
    public Vector3 offset; // The offset from the target

    void Start()
    {
        // Set the camera offset for isometric view
        offset = new Vector3(-10, 10, -10);
        transform.position = target.position + offset;
        transform.LookAt(target);
    }

    void LateUpdate()
    {
        // Update camera position
        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}
