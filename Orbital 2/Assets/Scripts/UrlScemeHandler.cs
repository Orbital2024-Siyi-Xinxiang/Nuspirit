using UnityEngine;








// this class is deprecated
public class UrlSchemeHandler : MonoBehaviour
{
    void Start()
    {
        // Check if launched from a URL
        if (Application.absoluteURL.StartsWith("unityApp://"))
        {
            // Extract parameters from URL
            string[] parts = Application.absoluteURL.Split('?');
            if (parts.Length > 1)
            {
                string[] parameters = parts[1].Split('&');
                foreach (string parameter in parameters)
                {
                    string[] keyValue = parameter.Split('=');
                    if (keyValue.Length == 2)
                    {
                        string key = keyValue[0];
                        string value = keyValue[1];
                        // Perform actions based on key-value pairs
                        Debug.Log($"Key: {key}, Value: {value}");
                    }
                }
            }
        }
    }
}