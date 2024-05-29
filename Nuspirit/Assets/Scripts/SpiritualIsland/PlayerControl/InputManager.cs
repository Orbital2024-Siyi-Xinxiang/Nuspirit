using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void OnTouchDelegate(Vector2 position);
    public static event OnTouchDelegate OnTouch;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                OnTouch?.Invoke(touch.position);
            }
        }
    }
}
