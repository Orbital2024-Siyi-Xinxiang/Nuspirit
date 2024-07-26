using UnityEngine;
using System.Collections;

public class VenuePreview : MonoBehaviour
{
    public VenueManager venueManager;
    public Texture2D mapTexture;
	private string venueId;
	private string userId;
	private PlayerPosition playerPosition;
	public GameObject otherUserPrefab;

    // Use this for initialization
    public void Initialize(string venueId)
    {
		this.venueId = venueId;
		AssignPreviewPanel();
    }

	private void AssignPreviewPanel()
	{

	}

	// Update is called once per frame
	void Update()
	{
			
	}
}

