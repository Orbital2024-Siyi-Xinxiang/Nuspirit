//using Firebase.Firestore;
//using Firebase.Extensions;
//using UnityEngine;

//public class UserLocationManager : MonoBehaviour
//{
//    private FirebaseFirestore db;

//    void Start()
//    {
//        // Initialize Firestore
//        db = FirebaseFirestore.DefaultInstance;

//        // Subscribe to Firestore updates
//        ListenToUserLocations();
//    }

//    private void ListenToUserLocations()
//    {
//        db.Collection("user_locations").Listen(snapshot =>
//        {
//            foreach (var document in snapshot.Documents)
//            {
//                var userId = document.Id;
//                var position = document.Get("position").ConvertTo<Vector3>();
//                UpdateUserPosition(userId, position);
//            }
//        });
//    }

//    private void UpdateUserPosition(string userId, Vector3 position)
//    {
//        // Update the user's position in the scene
//        // For example, find the user GameObject and update its position
//        var userObject = GameObject.Find(userId);
//        if (userObject != null)
//        {
//            userObject.transform.position = position;
//        }
//        else
//        {
//            // Instantiate a new user object if not found
//            GameObject newUser = Instantiate(userPrefab, position, Quaternion.identity);
//            newUser.name = userId;
//        }
//    }

//    public void SetUserLocation(string userId, Vector3 position)
//    {
//        DocumentReference docRef = db.Collection("user_locations").Document(userId);
//        docRef.SetAsync(new { position = position }).ContinueWithOnMainThread(task =>
//        {
//            if (task.IsCompleted)
//            {
//                Debug.Log("User location updated");
//            }
//            else
//            {
//                Debug.LogError("Failed to update user location: " + task.Exception);
//            }
//        });
//    }

//    public GameObject userPrefab; // Prefab to represent users in the scene
//}
