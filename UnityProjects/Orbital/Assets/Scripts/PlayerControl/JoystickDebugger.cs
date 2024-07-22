using UnityEngine;

public class JoystickDebugger : MonoBehaviour
{
    public GameObject joystick;
    public GameObject handle;

    void Start()
    {
        if (joystick == null || handle == null)
        {
            Debug.LogError("Joystick or Handle is not assigned.");
        }
    }

    void Update()
    {
        if (joystick != null)
        {
            Debug.Log($"Joystick Active: {joystick.activeInHierarchy}");
            Debug.Log($"Joystick Position: {joystick.GetComponent<RectTransform>().anchoredPosition}");
        }

        if (handle != null)
        {
            Debug.Log($"Handle Active: {handle.activeInHierarchy}");
            Debug.Log($"Handle Position: {handle.GetComponent<RectTransform>().anchoredPosition}");
        }
    }
}
