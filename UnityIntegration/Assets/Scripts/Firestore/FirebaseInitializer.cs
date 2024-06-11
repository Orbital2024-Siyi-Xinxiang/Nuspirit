//using Firebase;
//using Firebase.Firestore;
//using UnityEngine;

//public class FirebaseInitializer : MonoBehaviour
//{
//    void Start()
//    {
//        // Make sure this GameObject persists across scene loads
//        DontDestroyOnLoad(this.gameObject);

//        // Initialize Firebase
//        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
//        {
//            FirebaseApp app = FirebaseApp.DefaultInstance;
//            FirestoreExample();
//        });
//    }

//    void FirestoreExample()
//    {
//        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
//        // Your Firestore operations here
//    }


//}
