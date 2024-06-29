using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;

public class UserCreaterTemp : MonoBehaviour
{
    private FirebaseAuth auth;
    private FirebaseUser user;
    private DatabaseReference databaseReference;

    // Hardcoded user data
    private List<(string email, string password)> fakeUsers = new List<(string email, string password)>()
    {
        ("testuser1@example.com", "password1"),
        ("testuser2@example.com", "password2"),
        ("testuser3@example.com", "password3")
    };

    void Start()
    {
        StartCoroutine(WaitForFirebaseAndDataInitialization());
    }

    private IEnumerator WaitForFirebaseAndDataInitialization()
    {
        // Wait until FirebaseInitTemp is initialized
        while (FirebaseInitTemp.Instance == null || !FirebaseInitTemp.Instance.IsInitialized)
        {
            Debug.Log("Waiting for FirebaseInitTemp to be initialized...");
            yield return null;
        }

        // Wait until DataInitialiserTemp is finished
        while (DataInitialiserTemp.Instance == null || !DataInitialiserTemp.Instance.IsInitialized)
        {
            Debug.Log("Waiting for DataInitialiserTemp to finish initialization...");
            yield return null;
        }

        Debug.Log("FirebaseInitTemp and DataInitialiserTemp are initialized.");
        // Proceed with Firebase Auth initialization
        InitializeFirebase();
    }

    void InitializeFirebase()
    {
        auth = FirebaseInitTemp.Instance.Auth;
        databaseReference = FirebaseInitTemp.Instance.DatabaseReference;

        // Sign up fake users for testing and create default user data
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
        // Create default user data for the new user
        UserData newUserData = new UserData(
            newUser.UserId, 
            newUser.Email, 
            "", // Passwords should not be stored in the database
            avatarDesign: "defaultAvatar",
            isOutdoor: false,
            hasAircon: false,
            hasPrinter: false,
            hasCharger: false,
            hasMeetingRooms: false,
            openingTime: "08:00 AM",
            closingTime: "05:00 PM",
            hasFoodCourtsAround: false
        );

        string userJson = JsonUtility.ToJson(newUserData);

        // Save user data in the database
        databaseReference.Child("users").Child(newUser.UserId).SetRawJsonValueAsync(userJson).ContinueWithOnMainThread(task => {
            if (task.IsCompleted)
            {
                Debug.Log($"User data for {newUser.UserId} initialized successfully in the database.");
            }
            else
            {
                Debug.LogError($"Failed to initialize user data for {newUser.UserId}: {task.Exception}");
            }
        });
    }
}
