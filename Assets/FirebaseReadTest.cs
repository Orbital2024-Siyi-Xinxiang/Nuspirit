using UnityEngine;
using Firebase.Database;
using System.Collections;
using System.Threading.Tasks;

public class FirebaseReadTest : MonoBehaviour
{
    private DatabaseReference reference;

    void Start()
    {
        StartCoroutine(WaitForFirebaseInitialization());
    }

    private IEnumerator WaitForFirebaseInitialization()
    {
        while (!FirebaseConfig.Instance.IsInitialized)
        {
            yield return null;
        }

        reference = FirebaseConfig.Instance.RootReference.Child("testData");
        ReadTestData();
    }

    void ReadTestData()
    {
        reference.GetValueAsync().ContinueWith(task =>
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
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
}
