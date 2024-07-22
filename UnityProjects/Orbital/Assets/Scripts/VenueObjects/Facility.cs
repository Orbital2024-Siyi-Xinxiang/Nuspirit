using UnityEngine;
using System.Collections;

public class Facility : MonoBehaviour
{
	public VenueFacility facilityData;

    void Start()
    {
        facilityData = ScriptableObject.CreateInstance<VenueFacility>();
    }


    public void Initialize(VenueFacility facilityData)
	{
		this.facilityData = facilityData;
	}

	// Update is called once per frame
	void Update()
	{
			
	}
}

