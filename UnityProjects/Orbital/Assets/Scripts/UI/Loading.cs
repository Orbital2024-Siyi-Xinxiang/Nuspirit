//using UnityEngine;
//using System.Collections;

//public class Loading : MonoBehaviour
//{
//	// Use this for initialization
//	public GameObject LoadingMask;

//	void Start()
//	{
//		LoadingMask = transform.GetChild(0).gameObject;
//		LoadingMask.SetActive(false);
//	}

//	// Update is called once per frame
//	void StartLoading()
//	{
//		if (LoadingMask != null)
//		{
//            LoadingMask.SetActive(true);
//        }
//		else
//		{
//			Debug.LogError("missing loading mask");
//		}
//	}

//	void EndLoading()
//	{
//        if (LoadingMask != null)
//        {
//            LoadingMask.SetActive(false);
//        }
//        else
//        {
//            Debug.LogError("missing loading mask");
//        }
//    }

//}

using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour
{
    // Use this for initialization
    public GameObject LoadingMask;

    void Start()
    {
        // Initially disable the LoadingMask
        LoadingMask = transform.GetChild(0).gameObject;
        StartLoading();
    }

    // Method to start the loading process
    public void StartLoading()
    {
        if (LoadingMask != null)
        {
            LoadingMask.SetActive(true);
            // Start coroutine to end loading after 3 seconds
            StartCoroutine(EndLoadingAfterDelay(3.0f));
        }
        else
        {
            Debug.LogError("Missing loading mask");
        }
    }

    // Coroutine to wait for a certain delay before ending loading
    private IEnumerator EndLoadingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        EndLoading();
    }

    // Method to end the loading process
    void EndLoading()
    {
        if (LoadingMask != null)
        {
            LoadingMask.SetActive(false);
        }
        else
        {
            Debug.LogError("Missing loading mask");
        }
    }
}


