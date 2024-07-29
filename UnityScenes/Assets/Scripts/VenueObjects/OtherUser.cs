using UnityEngine;
using System.Collections;

public class User : MonoBehaviour
{
	public VenueUser userData;

    // Use this for initialization

    public void Initialize(VenueUser data)
    {
		if (data != null)
		{
			userData = data;
		}
		else
		{
			Debug.LogError("user data cannot be null!");
		}
		
    }

    void OnEnable()
	{
		// when initiated as a user, start at the entrance and start moving about.


	}

	// Update is called once per frame
	void Update()
	{
			
	}
}

