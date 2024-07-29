using Firebase.Firestore;
using Firebase.Storage;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FirebaseDataManager : MonoBehaviour
{
    // TODO: retrieve data from firestore users_assets collection, use userId as document id, and all fields are the same as scriptable object.
    // TODO: every asset has id from 0. has sprite texture downloaded from firebase storage asset_images folder(with name.png same as id.)
    // TODO: handle as long as name same, no matter png or jpg is taken as the texture of that asset.
    // download image using provided firebase storage function and store into database

    public FirebaseStorageManager storage;
    public string userId;
    public UrlSchemeHandler urlHandler;
    public ObjectsDatabase objectsDatabase;
    public CategoriesDatabase categoriesDatabase;

    private FirebaseFirestore db;

    private void OnEnable()
    {
        urlHandler = UrlSchemeHandler.Instance;
        userId = urlHandler.userId;
        db = FirebaseFirestore.DefaultInstance;
        RetrieveDataFromFirestore();
    }

    private async void RetrieveDataFromFirestore()
    {
        DocumentReference docRef = db.Collection("users_assets").Document(userId);
        DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

        if (snapshot.Exists)
        {
            
            Dictionary<string, object> userData = snapshot.ToDictionary();

            foreach (var kvp in userData)
            {
                string assetId = kvp.Key;
                Dictionary<string, object> assetData = kvp.Value as Dictionary<string, object>;

                if (assetData != null)
                {
                    string category = assetData["category"].ToString();
                    int availableQuantity = int.Parse(assetData["availableQuantity"].ToString());

                    GameObject prefab = await LoadPrefabFromAssetId(assetId);
                    if (prefab != null)
                    {
                        ObjectsDatabase.ObjectData objectData = new ObjectsDatabase.ObjectData
                        {
                            category = category,
                            prefab = prefab,
                            availableQuantity = availableQuantity
                        };
                        // TODO: populate categoriesDatabase and objectsDatabase
                        // Add the object data to the database (you may need to extend the ScriptableObject to handle this)
                    }
                }
            }
        }
        else
        {
            Debug.LogError("No document found for user: " + userId);
        }
    }

    private async Task<GameObject> LoadPrefabFromAssetId(string assetId)
    {
        string[] formats = { "png", "jpg" };
        Texture2D texture = null;

        foreach (string format in formats)
        {
            string imageUrl = $"asset_images/{assetId}.{format}";
            texture = await storage.LoadImageAsync(imageUrl);

            if (texture != null)
            {
                break;
            }
        }

        if (texture != null)
        {
            // Create a prefab from the texture
            GameObject prefab = new GameObject(assetId);
            SpriteRenderer renderer = prefab.AddComponent<SpriteRenderer>();
            renderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            return prefab;
        }
        else
        {
            Debug.LogError($"Failed to load image for asset ID: {assetId}");
            return null;
        }
    }
}
