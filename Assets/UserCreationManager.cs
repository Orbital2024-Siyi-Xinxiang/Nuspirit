/*

using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase.Database;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class UserCreationManager : MonoBehaviour
{
    public InputField usernameInputField;
    public InputField passwordInputField;
    public Button createAccountButton;
    public Text feedbackText;

    private FirebaseAuth auth;
    private DatabaseReference reference;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        createAccountButton.onClick.AddListener(CreateAccount);
    }

    async void CreateAccount()
    {
        string username = usernameInputField.text;
        string password = passwordInputField.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            feedbackText.text = "Username and Password cannot be empty.";
            return;
        }

        try
        {
            var createUserTask = await auth.CreateUserWithEmailAndPasswordAsync(username + "@example.com", password);
            FirebaseUser newUser = createUserTask.User;

            if (newUser != null)
            {
                // Create a new UserData object
                UserData userData = new UserData(newUser.UserId, newUser.Email, "default_avatar", null, null, null, null, null, "00:00", "00:00", null);
                var setUserTask = reference.Child("users").Child(newUser.UserId).SetRawJsonValueAsync(JsonUtility.ToJson(userData));

                await setUserTask;
                feedbackText.text = "Account created successfully!";
                SceneManager.LoadScene("UserPreferencesScene"); // Transition to the user preferences scene
            }
            else
            {
                feedbackText.text = "Error creating user: No user data returned.";
                Debug.LogError("Error creating user: No user data returned.");
            }
        }
        catch (System.Exception e)
        {
            feedbackText.text = "Error creating user: " + e.Message;
            Debug.LogError("Error creating user: " + e.Message);
        }
    }
}


*/