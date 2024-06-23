using UnityEngine;
using Firebase;
using Firebase.Extensions;
using Firebase.Firestore;
using Firebase.Storage;

public class FirebaseInitializer : MonoBehaviour
{
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            if (task.Result != DependencyStatus.Available)
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + task.Result);
            }
            else
            {
                // Firebase is ready to use
                InitializeFirebaseComponents();
            }
        });
    }

    void InitializeFirebaseComponents()
    {
        FirebaseStorage firebaseStorage= FirebaseStorage.DefaultInstance;
        FirebaseFirestore firebaseFirestore = FirebaseFirestore.DefaultInstance;
    }
}

