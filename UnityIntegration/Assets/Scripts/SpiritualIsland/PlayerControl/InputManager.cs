using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void OnTouchDelegate(Vector2 position, bool isDragging);
    public static event OnTouchDelegate OnTouch;

    private bool isDragging;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isDragging = false;
                    OnTouch?.Invoke(touchPosition, isDragging);
                    break;
                case TouchPhase.Moved:
                    isDragging = true;
                    OnTouch?.Invoke(touchPosition, isDragging);
                    break;
                case TouchPhase.Ended:
                    isDragging = false;
                    OnTouch?.Invoke(touchPosition, isDragging);
                    break;
            }
        }
    }
}
