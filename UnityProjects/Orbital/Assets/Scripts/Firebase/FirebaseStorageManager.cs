using Firebase.Storage;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class FirebaseStorageManager : MonoBehaviour

{
    public async Task<Texture2D> LoadImageAsync(string imageUrl)
    {

        //print("start loading image async from firebase storage");
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;
        StorageReference storageRef = storage.GetReferenceFromUrl(imageUrl);
        var task = storageRef.GetDownloadUrlAsync();
        await task;
        //print("got task fetched for " + imageUrl);
        if (task.IsFaulted || task.IsCanceled)
        {
            Debug.LogError("Error fetching the download URL.");
            return null;
        }

        string downloadUrl = task.Result.ToString();
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(downloadUrl);
        var asyncOperation = www.SendWebRequest();
        while (!asyncOperation.isDone)
        {
            await Task.Yield();
        }

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error downloading the image.");
            return null;
        }
        //print("suceessfully downloaded image texture!");

        return ((DownloadHandlerTexture)www.downloadHandler).texture;
    }
}
