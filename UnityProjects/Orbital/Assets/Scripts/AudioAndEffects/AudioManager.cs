using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	public Toggle musicToggle;
	public Toggle soundEffectsToggle;
	public Slider musicVolumeSlider;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject); // Optional: Make it persistent
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

	void Start()
	{
		InitializeSettings();
	}

	void Update()
	{
		// Optional: Add any real-time updates if needed
	}

	void InitializeSettings()
	{
		bool musicEnabled = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
		bool soundEffectsEnabled = PlayerPrefs.GetInt("SoundEffectsEnabled", 1) == 1;
		// Continue with your existing initialization code...
	}

    public void UpdateSettings()
    {
        
    }

    // Add other AudioManager methods here...
}