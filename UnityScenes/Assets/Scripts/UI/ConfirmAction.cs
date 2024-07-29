using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;
using System.Collections.Generic;

public class ConfirmAction : MonoBehaviour
{
    private string systemMessage;
    private string userId;
    private int level;
    private string action;

    // TODO: assign buttons
    public Button yesButton;
    public Button cancelButton;
    public Toggle neverShowAgain;
    public UrlSchemeHandler urlSchemeHandler;

    private FirebaseFirestore db;

    void Start()
    {
        urlSchemeHandler = UrlSchemeHandler.Instance;
        db = FirebaseFirestore.DefaultInstance;
    }

    public void Initialize(string action, int level)
    {
        urlSchemeHandler = UrlSchemeHandler.Instance;
        this.action = action;
        this.level = level;
        this.userId = urlSchemeHandler.userId;
        AssignIconImage();
        AssignSystemMessage();

        // Check if "Never Show Again" is already set for this action
        CheckNeverShowAgain();

        // Add button listeners
        yesButton.onClick.AddListener(() => ImplementAction());
        cancelButton.onClick.AddListener(() => CancelAction());
    }

    private void AssignSystemMessage()
    {
        systemMessage = "Are you sure you want to " + action + "?";
        Transform child = transform.GetChild(3);
        if (child != null)
        {
            TMP_Text textComponent = child.GetComponent<TMP_Text>();
            if (textComponent != null)
            {
                textComponent.text = systemMessage;
            }
        }
    }

    private void AssignIconImage()
    {
        Image icon = transform.GetChild(4).GetComponent<Image>();
        if (icon != null)
        {
            if (level == 0)
            {
                // Set red warning icon
            }
            else if (level == 1)
            {
                // Set yellow warning icon
            }
            else if (level == 2)
            {
                // Set special warning icon
            }
            else
            {
                // No icon
            }
        }
    }

    private void ImplementAction()
    {
        // Implement the action here

        // Save "Never Show Again" setting if the toggle is checked
        if (neverShowAgain.isOn)
        {
            NeverShow();
        }
    }

    private void CancelAction()
    {
        // Cancel the action here
    }

    private void NeverShow()
    {
        DocumentReference docRef = db.Collection("users_settings").Document(userId);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted && task.Result.Exists)
            {
                Dictionary<string, object> updates = new Dictionary<string, object>
                {
                    { "confirm_clear_bookings", false }
                };

                docRef.UpdateAsync(updates).ContinueWithOnMainThread(updateTask =>
                {
                    if (updateTask.IsCompleted)
                    {
                        Debug.Log("Never Show Again setting updated successfully.");
                    }
                    else
                    {
                        Debug.LogError("Failed to update Never Show Again setting: " + updateTask.Exception);
                    }
                });
            }
            else
            {
                Debug.LogError("User settings document not found: " + task.Exception);
            }
        });
    }

    private void CheckNeverShowAgain()
    {
        DocumentReference docRef = db.Collection("users_settings").Document(userId);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted && task.Result.Exists)
            {
                bool neverShow = task.Result.GetValue<bool>("confirm_clear_bookings");
                if (!neverShow)
                {
                    // Automatically perform the action without showing the confirmation dialog
                    ImplementAction();
                }
            }
            else
            {
                Debug.LogWarning("User settings document not found or another error occurred: " + task.Exception);
            }
        });
    }
}
