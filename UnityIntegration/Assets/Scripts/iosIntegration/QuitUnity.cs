
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitUnity : MonoBehaviour
{
    public void OnButtonPressed()
    {
        Application.Unload();
        // Application.Quit();  //using this will quit the application entirely
    }
}