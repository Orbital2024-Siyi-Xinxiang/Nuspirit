using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;

public class SignUpManager : MonoBehaviour
{
    private FirebaseAuth auth;
    private DatabaseReference reference;

    [SerializeField] private InputField emailInputField;
    [SerializeField] private InputField passwordInputField;
    [SerializeField] private Button signUpButton;

    void Start()
    {
        // Ensure Firebase is initialized
        if (FirebaseInit.Instance == null)
        {
            Debug.LogError("FirebaseInit instance not found.");
            return;
        }

        auth = FirebaseInit.Instance.Auth;
        reference = FirebaseInit.Instance.DatabaseReference;

        // Add listener to the sign-up button
        signUpButton.onClick.AddListener(() => CreateUser(emailInputField.text, passwordInputField.text));
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
            FirebaseUser newUser = task.Result.User;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
            OnUserCreated(newUser, password);
        });
    }

    void OnUserCreated(FirebaseUser newUser, string password)
    {
        // Initialize user data in the database
        UserData userData = new UserData(
            newUser.UserId, 
            newUser.Email, 
            password,
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
        string userJson = JsonUtility.ToJson(userData);
        reference.Child("users").Child(newUser.UserId).SetRawJsonValueAsync(userJson).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log($"User data for {newUser.UserId} initialized successfully.");
            }
            else
            {
                Debug.LogError($"Failed to initialize user data for {newUser.UserId}: " + task.Exception);
            }
        })
        
        
        
        ;
    }
}



