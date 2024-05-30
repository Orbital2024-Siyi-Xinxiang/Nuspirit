//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FirestoreImageLoader : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}







//using Firebase.Firestore;
//using Firebase.Extensions;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;
//using System.Collections;

//public class FirestoreImageLoader : MonoBehaviour
//{
//    FirebaseFirestore db;

//    void Start()
//    {
//        db = FirebaseFirestore.DefaultInstance;
//        LoadImageData();
//    }

//    void LoadImageData()
//    {
//        db.Collection("imageCollection").GetSnapshotAsync().ContinueWithOnMainThread(task =>
//        {
//            if (task.IsCompleted)
//            {
//                QuerySnapshot snapshot = task.Result;
//                foreach (DocumentSnapshot doc in snapshot.Documents)
//                {
//                    string imageUrl = doc.GetString("imageUrl");
//                    string imageName = doc.GetString("imageName");
//                    int imageNumber = doc.GetInt32("imageNumber");
//                    StartCoroutine(DownloadImage(imageUrl, imageName, imageNumber));
//                }
//            }
//            else
//            {
//                Debug.LogError("Failed to fetch document: " + task.Exception);
//            }
//        });
//    }

//    IEnumerator DownloadImage(string url, string name, int number)
//    {
//        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
//        yield return request.SendWebRequest();

//        if (request.result != UnityWebRequest.Result.Success)
//        {
//            Debug.LogError("Error downloading image: " + request.error);
//        }
//        else
//        {
//            Texture2D texture = DownloadHandlerTexture.GetContent(request);
//            CreateGameObject(texture, name, number);
//        }
//    }

//    void CreateGameObject(Texture2D texture, string name, int number)
//    {
//        GameObject newObject = new GameObject(name);
//        SpriteRenderer renderer = newObject.AddComponent<SpriteRenderer>();
//        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
//        renderer.sprite = sprite;

//        // Optionally, set other properties like position based on the number or other data
//        newObject.transform.position = new Vector3(number, 0, 0); // Example positioning

//        SaveAsPrefab(newObject, $"Assets/Prefabs/{name}.prefab");
//    }

//    void SaveAsPrefab(GameObject instance, string path)
//    {
//#if UNITY_EDITOR
//        UnityEditor.PrefabUtility.SaveAsPrefabAsset(instance, path);
//#endif
//    }
//}
