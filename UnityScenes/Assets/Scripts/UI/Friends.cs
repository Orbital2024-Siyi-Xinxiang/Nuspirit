using UnityEngine;
using System.Collections;

public class Friends : MonoBehaviour
{
	// TODO: assign friend in venue prefab
	public GameObject friendInVenue;

	public UrlSchemeHandler urlSchemeHandler;
	public VenueManager venueManager;

	private string userId;
	private string venueId;

    public void Start()
    {
        urlSchemeHandler = UrlSchemeHandler.Instance;
    }
    // Use this for initialization
    void RefreshFriendsList()
	{
		userId = urlSchemeHandler.userId;
		venueId = venueManager.venue.id;
		InitializeFriendsInVenue();
	}


	private void InitializeFriendsInVenue()
	{
		// from venues_users
	}

	private void navigateBackToContact()
	{
		// TODO: when chat button is clicked, then navigate back to native nuspirit app to chat with the contact
		urlSchemeHandler.NavigateBackToNativeApp();
	}
	// Update is called once per frame
	void Update()
	{
			
	}
}

