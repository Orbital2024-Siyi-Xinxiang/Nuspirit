using UnityEngine;
using System.Collections;

public class Booker : MonoBehaviour
{
	public string id;
	public string email;
	public string major;
	public string yr;

	public GameObject chatButton;

	
	// Use this for initialization
	public void Initialize()
	{
		// TODO: handle set active and inactive clicking logic


        // TODO: get children bookerNaame 'text mesh pro' component and assign booker.name
        // TODO: get children major 'text mesh pro' component and assign booker.major
		// TODO: same for childre 'yr'

		// TODO: retrieve user's profile picture from firebase storage async


		// TODO: chat with that user when chatButton is clicked, navigate back to swift UI

    }

}

