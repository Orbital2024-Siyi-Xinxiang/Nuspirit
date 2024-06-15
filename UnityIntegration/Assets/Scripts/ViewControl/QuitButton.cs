using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    // Reference to the button
    public Button button;

    void Start()
    {
        if (button != null)
        {
            // Add a listener to the button to call the QuitApplication method when clicked
            button.onClick.AddListener(QuitApplication);
        }
        else
        {
            Debug.LogError("Button reference is not set in the Inspector.");
        }
    }

    void QuitApplication()
    {
        Debug.Log("Quitting application...");
        Application.Unload();
        //Application.Quit();
    }

        // If running in the editor, stop playing
//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.isPlaying = false;
//#endif
}
