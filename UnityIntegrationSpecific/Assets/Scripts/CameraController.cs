using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera mainCamera;
    public static float zoomSpeed = 0.1f;
    public static float minZoom = 5f;
    public static float maxZoom = 20f;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        HandlePinchZoom();
    }

    private void HandlePinchZoom()
    {
        // Check if there are two touches on the screen
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // Find the position in the previous frame of each touch
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
            Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame
            float prevTouchDeltaMag = (touch1PrevPos - touch2PrevPos).magnitude;
            float touchDeltaMag = (touch1.position - touch2.position).magnitude;

            // Find the difference in the distances between each frame
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // Change the field of view based on the change in distance between the touches
            mainCamera.orthographicSize += deltaMagnitudeDiff * zoomSpeed;

            // Clamp the orthographic size to make sure it stays within the min and max bounds
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, minZoom, maxZoom);
        }
    }
}
