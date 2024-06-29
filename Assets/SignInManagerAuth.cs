using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase.Extensions;

public class SignInManager : MonoBehaviour
{
    private FirebaseAuth auth;
    private FirebaseUser user;
    public bool signedIn { get; private set; } = false;

    [SerializeField] private InputField emailInputField;
    [SerializeField] private InputField passwordInputField;
    [SerializeField] private Button signInButton;
    [SerializeField] private Text errorText;

    void Start()
    {
        StartCoroutine(WaitForFirebaseInitialization());
    }

    private IEnumerator WaitForFirebaseInitialization()
    {
        while (!FirebaseInit.Instance.IsInitialized)
        {
            Debug.Log("Waiting for Firebase to initialize...");
            yield return null;
        }

        auth = FirebaseInit.Instance.Auth;
        if (auth == null)
        {
            Debug.LogError("FirebaseAuth not initialized.");
            yield break;
        }

        signInButton.onClick.AddListener(() => SignInUser(emailInputField.text, passwordInputField.text));
    }

    public void SignInUser(string email, string password)
    {
        if (auth == null)
        {
            Debug.LogError("Cannot sign in because FirebaseAuth is null.");
            return;
        }

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                if (errorText != null)
                {
                    errorText.text = "Sign-in was canceled. Please try again.";
                }
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                if (errorText != null)
                {
                    errorText.text = "Invalid email or password. Please try again.";
                }
                return;
            }

            user = task.Result.User;
            signedIn = true;
            Debug.LogFormat("User signed in successfully: {0} ({1})", user.DisplayName, user.UserId);
            OnUserSignedIn(user);
        });
    }

    void OnUserSignedIn(FirebaseUser signedInUser)
    {
        Debug.Log("User signed in with UID: " + signedInUser.UserId);
        SceneTransferManager sceneTransferManager = Object.FindFirstObjectByType<SceneTransferManager>();
        if (sceneTransferManager != null)
        {
            sceneTransferManager.TransferToScene();
        }



        
    }
}
