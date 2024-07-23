using UnityEngine;
using UnityEngine.UI;

public class HighlightOutline : MonoBehaviour
{
    public Image outlineImage;
    //TODO: assign outline image

    void Awake()
    {
        outlineImage = GetComponent<Image>();
        outlineImage.enabled = false;
    }

    public void EnableOutline()
    {
        outlineImage.enabled = true;
    }

    public void DisableOutline()
    {
        outlineImage.enabled = false;
    }
}
