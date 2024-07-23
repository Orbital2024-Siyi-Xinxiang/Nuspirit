using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AssetBundleLoader : MonoBehaviour
{
    IEnumerator Start()
    {
        // TODO: replace the server url with actual url
        string url = "http://yourserver.com/AssetBundles/yourbundle";
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Failed to load AssetBundle: {request.error}");
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
            GameObject prefab = bundle.LoadAsset<GameObject>("YourPrefabName");
            if (prefab != null)
            {
                Instantiate(prefab);
            }
            else
            {
                Debug.LogError($"Failed to load prefab 'YourPrefabName' from AssetBundle");
            }
            bundle.Unload(true); // Unload the AssetBundle and its dependencies
        }
    }
}