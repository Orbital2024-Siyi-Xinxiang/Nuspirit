using Firebase;
using Firebase.Extensions;
using UnityEngine;

public class FirebaseInitializer : MonoBehaviour
{
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            Debug.Log("Firebase initialized.");
        });
    }
}
