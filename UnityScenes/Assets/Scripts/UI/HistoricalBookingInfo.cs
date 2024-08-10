using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class HistoricalBookingInfo : MonoBehaviour
{
	// Use this for initialization
	public Button searchButton;
	public GameObject warningPanel;

	void Start()
	{
        searchButton.onClick.AddListener(() => ShowWarning("No historical info found!")) ;
	}

    private void ShowWarning(string message)
    {
        // Find the first child and get its TMP_Text component
        TMP_Text warningMessage = warningPanel.transform.GetChild(0).GetComponent<TMP_Text>();

        if (warningMessage != null)
        {
            // Set the warning message text
            warningMessage.text = message;

            // Activate the warning panel
            warningPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("Warning message TMP_Text component not found in the first child of warningPanel.");
        }
    }
    // Update is called once per frame
    void Update()
	{
			
	}
}

