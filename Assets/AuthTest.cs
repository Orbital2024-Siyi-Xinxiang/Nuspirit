



// using UnityEngine;
// using Firebase.Auth;
// using Firebase.Database;
// using System.Collections;
// using System.Threading.Tasks;

// public class AuthTest : MonoBehaviour
// {
//     private FirebaseAuth auth;
//     private DatabaseReference reference;

//     void Start()
//     {
//         StartCoroutine(InitializeAndSignUp());
//     }

//     private IEnumerator InitializeAndSignUp()
//     {
//         // Wait until FirebaseConfig is initialized
//         while (FirebaseConfig.Instance == null || !FirebaseConfig.Instance.IsInitialized)
//         {
//             yield return null;
//         }

//         // Initialize Firebase Auth and Database references
//         auth = FirebaseAuth.DefaultInstance;
//         reference = FirebaseConfig.Instance.RootReference;

//         // Sign up the user and initialize their data
//         SignUpAndInitializeUser("houxinxiang379@gmail.com", "userwithauth", "User With Auth", "avatar3new", true, null, false, null, true, "08:00 AM", "05:00 PM", true, new UserLocationData(34.0521f, -118.2505f));
//     }

//     private void SignUpAndInitializeUser(string email, string password, string displayName, string avatarDesign, bool? isOutdoor, bool? hasAircon, bool? hasPrinter, bool? hasCharger, bool? hasMeetingRooms, string openingTime, string closingTime, bool? hasFoodCourtsAround, UserLocationData location)
//     {
//         auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith((Task<AuthResult> task) =>
//         {
//             if (task.IsCanceled)
//             {
//                 Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
//                 return;
//             }
//             if (task.IsFaulted)
//             {
//                 Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
//                 return;
//             }

//             // Firebase user has been created.
//             FirebaseUser newUser = task.Result.User;

//             Debug.LogFormat("Firebase user created successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);

//             // Update the user's display name
//             UserProfile profile = new UserProfile { DisplayName = displayName };
//             newUser.UpdateUserProfileAsync(profile).ContinueWith(profileTask =>
//             {
//                 if (profileTask.IsCanceled)
//                 {
//                     Debug.LogError("UpdateUserProfileAsync was canceled.");
//                     return;
//                 }
//                 if (profileTask.IsFaulted)
//                 {
//                     Debug.LogError("UpdateUserProfileAsync encountered an error: " + profileTask.Exception);
//                     return;
//                 }

//                 Debug.Log("User profile updated with display name.");

//                 // Initialize additional user data
//                 UserData userData = new UserData(newUser.UserId, email, avatarDesign, isOutdoor, hasAircon, hasPrinter, hasCharger, hasMeetingRooms, openingTime, closingTime, hasFoodCourtsAround)
//                 {
//                     location = location
//                 };

//                 // Serialize the user data to JSON and write it to the database
//                 string userJson = JsonUtility.ToJson(userData);
//                 reference.Child("users").Child(newUser.UserId).SetRawJsonValueAsync(userJson).ContinueWith(dbTask =>
//                 {
//                     if (dbTask.IsCanceled)
//                     {
//                         Debug.LogError("SetRawJsonValueAsync was canceled.");
//                         return;
//                     }
//                     if (dbTask.IsFaulted)
//                     {
//                         Debug.LogError("SetRawJsonValueAsync encountered an error: " + dbTask.Exception);
//                         return;
//                     }

//                     Debug.Log("User data initialized in the database.");
//                 });
//             });
//         });
//     }

//     private void SignInWithEmailAndPassword(string email, string password)
//     {
//         auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith((Task<AuthResult> task) =>
//         {
//             if (task.IsCanceled)
//             {
//                 Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
//                 return;
//             }
//             if (task.IsFaulted)
//             {
//                 Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
//                 return;
//             }

//             FirebaseUser newUser = task.Result.User;
//             Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
//         });
//     }
// }
