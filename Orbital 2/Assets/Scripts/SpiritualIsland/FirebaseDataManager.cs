using Firebase.Firestore;
using Firebase.Extensions;
using Firebase.Storage;
using UnityEngine;
using System;
using System.Threading.Tasks;
using static ObjectsDatabaseSO;
using System.Collections.Generic;

public class FirebaseDataManager : MonoBehaviour
{

    // TODO: firebase data unity correction and data structure error handling
    public FirebaseFirestore db;
    public FirebaseStorage storage;
    public string userId;
    public ObjectsDatabaseSO objectDatabase;
    public ObjectPlacer objectPlacer;

    async void Initialize(string uid)
    {
        userId = uid;
        await FetchUserAssets();
    }

    async Task FetchUserAssets()
    {
        // Fetch assets from 'users_assets' collection
        CollectionReference userAssetsRef = db.Collection("users_assets").Document(userId).Collection("assets");

        var snapshot = await userAssetsRef.GetSnapshotAsync();

        foreach (var document in snapshot.Documents)
        {
            string category = document.GetValue<String>("category");
            
            
            string assetId = document.GetValue<String>("id");

            // Fetch detailed asset data from 'assets' collection
            DocumentReference assetRef = db.Collection("assets").Document(assetId);
            DocumentSnapshot assetSnapshot = await assetRef.GetSnapshotAsync();

            if (assetSnapshot.Exists)
            {
                string name = assetSnapshot.GetValue<String>("name");
                List<int> sizeList = assetSnapshot.GetValue<List<int>>("size");
                int[] size = { Convert.ToInt32(sizeList[0]), Convert.ToInt32(sizeList[1]) };

                // Fetch asset image from Firebase Storage
                await FetchAssetImage(assetId);

                // Create ObjectData and add to ObjectsDatabaseSO
                ObjectData data = new ObjectData
                {
                    id = assetId,
                    category = category,
                    name = name,
                    prefab = null, // You'll load the prefab later
                    availableQuantity = 1, // Example, modify as per your logic
                    size = new Vector2Int(size[0], size[1])
                };

                // Add to ObjectDatabaseSO
                objectDatabase.objects.Add(data);
            }
            else
            {
                Debug.LogWarning($"Asset with id {assetId} does not exist.");
            }
        }

        // Notify that data has been fetched and processed
        Debug.Log("User assets fetched and processed.");
    }

    async Task FetchAssetImage(string assetId)
    {
        // Fetch image from Firebase Storage
        StorageReference imageRef = storage.GetReference("asset_images").Child(assetId);
        var task = imageRef.GetBytesAsync(long.MaxValue); // Max size
        await task.ContinueWithOnMainThread((Task<byte[]> downloadTask) =>
        {
            if (!downloadTask.IsFaulted && !downloadTask.IsCanceled)
            {
                byte[] result = downloadTask.Result;
                // Handle the downloaded image data
                // For example, load it into a texture or sprite
                // Example: Texture2D texture = new Texture2D(1, 1);
                // texture.LoadImage(result);
                // Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                // Assign sprite to your ObjectData or elsewhere in your logic

                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(result);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

                // TODO: assign the sprite to the asset buttons
                // TODO: assign 
            }
            else
            {
                Debug.LogError($"Failed to fetch image for asset {assetId}: {downloadTask.Exception}");
            }
        });
    }
}