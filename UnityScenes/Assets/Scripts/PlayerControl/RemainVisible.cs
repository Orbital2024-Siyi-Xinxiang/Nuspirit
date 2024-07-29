using UnityEngine;

public class JoystickVisibilityChecker : MonoBehaviour
{
    public Canvas joystickCanvas;

    void Start()
    {
        if (joystickCanvas == null)
        {
            joystickCanvas = GetComponent<Canvas>();
        }

        if (joystickCanvas != null)
        {
            joystickCanvas.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (joystickCanvas != null)
        {
            if (!joystickCanvas.gameObject.activeInHierarchy)
            {
                joystickCanvas.gameObject.SetActive(true);
            }
        }
    }
}
