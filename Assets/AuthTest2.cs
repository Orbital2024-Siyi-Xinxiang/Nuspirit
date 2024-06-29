using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;

public class FirebaseAuthManager : MonoBehaviour
{
    private FirebaseAuth auth;
    private FirebaseUser user;

    // Hardcoded user data
    private List<(string email, string password)> fakeUsers = new List<(string email, string password)>()
    {
        ("testuser1@example.com", "password1"),
        ("testuser2@example.com", "password2"),
        ("testuser3@example.com", "password3")
    };

    void Start()
    {
        StartCoroutine(WaitForFirebaseConfigInitialization());
    }

    private IEnumerator WaitForFirebaseConfigInitialization()
    {
        // Wait until FirebaseConfig is initialized
        while (FirebaseConfig.Instance == null || !FirebaseConfig.Instance.IsInitialized)
        {
            Debug.Log("Waiting for FirebaseConfig to be initialized...");
            yield return null;
        }

        // Proceed with Firebase Auth initialization
        InitializeFirebase();
    }

    void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;

        // Create fake users for testing
        foreach (var fakeUser in fakeUsers)
        {
            CreateUser(fakeUser.email, fakeUser.password);
        }
    }

    public void CreateUser(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            AuthResult authResult = task.Result;
            user = authResult.User;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})", user.DisplayName, user.UserId);
            OnUserCreated(user);
        });
    }

    void OnUserCreated(FirebaseUser newUser)
    {
        // Additional logic when user is created, e.g., navigate to another scene or update UI
        Debug.Log("User created with UID: " + newUser.UserId);
        // For example, load another scene
        // SceneManager.LoadScene("NextSceneName");
    }

    public void SignInUser(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            AuthResult authResult = task.Result;
            user = authResult.User;
            Debug.LogFormat("User signed in successfully: {0} ({1})", user.DisplayName, user.UserId);
            OnUserSignedIn(user);
        });
    }

    void OnUserSignedIn(FirebaseUser signedInUser)
    {
        // Additional logic when user is signed in, e.g., navigate to another scene or update UI
        Debug.Log("User signed in with UID: " + signedInUser.UserId);
        // For example, load another scene
        // SceneManager.LoadScene("MainScene");
    }
}
