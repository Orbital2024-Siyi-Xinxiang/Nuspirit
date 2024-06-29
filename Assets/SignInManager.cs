// using UnityEngine;
// using UnityEngine.UI;
// using Firebase.Auth;
// using Firebase.Database;
// using UnityEngine.SceneManagement;
// using System.Threading.Tasks;

// public class SignInManager : MonoBehaviour
// {
//     public InputField emailInputField;
//     public InputField passwordInputField;
//     public Button signInButton;
//     public Text feedbackText;

//     private FirebaseAuth auth;

//     void Start()
//     {
//         auth = FirebaseAuth.DefaultInstance;
//         signInButton.onClick.AddListener(SignIn);
//     }

//     async void SignIn()
//     {
//         string email = emailInputField.text;
//         string password = passwordInputField.text;

//         if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
//         {
//             feedbackText.text = "Email and Password cannot be empty.";
//             return;
//         }

//         try
//         {
//             var signInTask = await auth.SignInWithEmailAndPasswordAsync(email, password);

//             if (signInTask == null)
//             {
//                 feedbackText.text = "Sign-in task is null.";
//                 return;
//             }

//             if (signInTask.User != null)
//             {
//                 FirebaseUser newUser = signInTask.User;
//                 feedbackText.text = "Sign-in successful!";
//                 Debug.Log($"User signed in successfully: {newUser.Email}");
//                 SceneManager.LoadScene("AreaManagerScene"); // Transition to the area manager scene
//             }
//             else
//             {
//                 feedbackText.text = "Sign-in failed: No user.";
//                 Debug.LogError("Sign-in failed: No user.");
//             }
//         }
//         catch (System.Exception e)
//         {
//             feedbackText.text = $"Sign-in error: {e.Message}";
//             Debug.LogError($"Sign-in error: {e.Message}");
//         }
//     }
// }
