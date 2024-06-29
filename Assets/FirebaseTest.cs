using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class FirebaseTest : MonoBehaviour
{
    private DatabaseReference reference;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                FirebaseApp app = FirebaseApp.DefaultInstance;
                reference = FirebaseDatabase.DefaultInstance.RootReference;
                TestWriteData();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + task.Exception);
            }
        });
    }

    void TestWriteData()
    {
        string testData = "Hello, Firebase!";
        reference.Child("test").SetValueAsync(testData).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Data written successfully!");
                TestReadData();
            }
            else
            {
                Debug.LogError("Failed to write data: " + task.Exception);
            }
        });
    }

    void TestReadData()
    {
        reference.Child("test").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Debug.Log("Data read successfully: " + snapshot.Value.ToString());
            }
            else
            {
                Debug.LogError("Failed to read data: " + task.Exception);
            }
        });
    }
}
