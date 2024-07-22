using UnityEngine;
using UnityEngine.UI;

public class HighlightOutline : MonoBehaviour
{
    private Image outlineImage;

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
