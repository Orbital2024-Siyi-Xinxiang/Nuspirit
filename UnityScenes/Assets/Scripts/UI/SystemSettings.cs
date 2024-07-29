using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Messaging;


public class SystemSettings : MonoBehaviour
{
	public string userId;

	public ScrollRect general;
	public ScrollRect notifications;
	public ScrollRect appearance;
	public ScrollRect privacy;
	public ScrollRect studyTracking;
	public ScrollRect community;

	public AudioManager audioManager;

	void Start()
	{
		// Initialize settings or load saved settings
		LoadSettings();

		// Initialize Firebase if needed
	}

	void Update()
	{
		// Example: Update UI elements based on user input or other changes
	}

	void LoadSettings()
	{
		// Load settings from a file, database, or player prefs
	}

	void SaveSettings()
	{
		// Save current settings to a file, database, or player prefs
		// save settings to firebase users_settings collection
		// Example:
		FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
		db.Collection("users_settings")
				.Document(userId);
				//.SetAsync(new { general_settings = generalSettings });
	}

	public void OnAudioSettingsChanged()
	{
		// Adjust audio settings through AudioManager
		if (audioManager != null)
		{
			audioManager.UpdateSettings();
		}
	}

	public void OnGeneralSettingsChanged()
	{
		// Handle changes to general settings
		SaveSettings();
	}

	void OnMessageReceived(object sender, MessageReceivedEventArgs e)
	{
		// Handle incoming Firebase messages
	}
}
