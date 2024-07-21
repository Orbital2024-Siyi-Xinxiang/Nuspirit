using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine;

public class NativeAPI
{
    [DllImport("__Internal")]
    public static extern void sendMessageToMobileApp(string message);
}

public class SwiftBridging : MonoBehaviour
{
    public int id;

    void Start()
    {
        id = 0;
    }

    public void trigger(string message)
    {
        
        NativeAPI.sendMessageToMobileApp(message);
    }
}