using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AssetBundleLoader : MonoBehaviour
{
    IEnumerator Start()
    {
        string url = "http://yourserver.com/AssetBundles/yourbundle";
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
            GameObject prefab = bundle.LoadAsset<GameObject>("YourPrefabName");
            Instantiate(prefab);
        }
    }
}
