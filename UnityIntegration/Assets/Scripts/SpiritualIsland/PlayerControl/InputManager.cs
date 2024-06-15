using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void TouchAction(Vector2 position, bool isDragging);
    public static event TouchAction OnTouch;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                OnTouch?.Invoke(touchPosition, true);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                OnTouch?.Invoke(touchPosition, false);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            OnTouch?.Invoke(mousePosition, true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            OnTouch?.Invoke(mousePosition, false);
        }
    }
}
