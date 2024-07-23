using UnityEngine;
using UnityEngine.UI;

public class ConfirmAction : MonoBehaviour
{
    private string systemMessage;
    private int level;

    public GameObject yesButton;
    public GameObject cancelButton;
    public Toggle neverShowAgain;


    public void Initialize(string message, int level)
    {
        AssignIconImage(level);
        // TODO: assign system message
        // TODO: add button listener
    }

    private void AssignIconImage(int level)
    {
        if (level == 0)
        {
            // red warning
        }

        else if (level == 1)
        {
            // yellow warning
        }
        else if (level == 2)
        {
            // special warning
        }
        else
        {
            // no icon
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
