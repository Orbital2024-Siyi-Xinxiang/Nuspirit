using Firebase.Firestore;
using Firebase.Storage;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class FirebaseFirestoreManager : MonoBehaviour
{

    public FirebaseStorageManager firebaseStorageManager;

    public VenueManager venueManager;
    public VenueRenderer venueRenderer;
    public VenueDatabase venueDatabase;
    //public VenueRenderer venueRenderer;

    public const int default_bookable_id = 500;
    public const int default_facility_id = 1000;
    public const int default_interactable_id = 100;
    public const int default_solid_object_id = 1050;
    public const int default_transfer_point_id = 1500;
    public const int default_background_id = 0;
    public const int default_solid_layer_id = 50;

    public int venueLevels;
    public string venueName;
    public int venueId;
    public Dictionary<string, Texture2D> venueFacilitiesDict;
    public Dictionary<string, Texture2D> venueInteractablesDict;
    public Dictionary<string, Texture2D> venueSolidObjectsDict;

    // Use this for initialization
    public void InitializeDatabase(int Id)
    {
        // Debug.Log("start initializing database");

        venueId = Id;
        venueFacilitiesDict = new Dictionary<string, Texture2D>();
        venueInteractablesDict = new Dictionary<string, Texture2D>();
        venueSolidObjectsDict = new Dictionary<string, Texture2D>();
        //Debug.Log($"VenueID: {venueId}");

        StartCoroutine(LoadVenueDataAsync(venueId.ToString()));
    }

    private IEnumerator LoadVenueDataAsync(string venueId)
    {
        FirebaseFirestore firestore = FirebaseFirestore.DefaultInstance;
        

        // Fetch document from Firestore
        DocumentReference docRef = firestore.Collection("venues").Document(venueId);

        //Debug.Log("Start fetching snapshot");

        var task = docRef.GetSnapshotAsync();
        yield return new WaitUntil(() => task.IsCompleted);

        DocumentSnapshot snapshot = task.Result;


        //Debug.Log("snapshot fetched successfully!");

        if (snapshot.Exists)
        {
            // Fetch levels and venue name
            List<int> levels = snapshot.GetValue<List<int>>("levels");
            venueName = snapshot.GetValue<string>("name");
            venueLevels = levels.Count;

            print("database for " + venueName + $" has levels {venueLevels}");

            string startLevel = venueLevels > 0 ? levels[0].ToString() : "0";


            // Iterate through each level and load venue details
            foreach (int levelId in levels)
            {
                // Instantiate the Venue scriptable object and populate its fields
                Venue venue = ScriptableObject.CreateInstance<Venue>();

                venue.name = "venue " + levelId.ToString();

                venue.id = levelId.ToString();
                //Debug.Log("current venue" + venue.id);s
                // Add the venue to the database

                venueDatabase.AddVenue(venue);
                StartCoroutine(RunLoadVenueDetailsAsync(venue));
            }

            venueManager.Initialize(startLevel);
            venueRenderer.Initialize(startLevel);
        }
        else
        {
            Debug.LogError("Document does not exist!");
        }
    }

    private IEnumerator RunLoadVenueDetailsAsync(Venue venue)
    {
        //Debug.Log("start loading venue details");

        var task = LoadVenueDetailsAsync(venue);
        yield return new WaitUntil(() => task.IsCompleted);
    }

    private async Task<IEnumerator> LoadVenueDetailsAsync(Venue venue)
    {




        // Fetch document from Firestore
        FirebaseFirestore firestore = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = firestore.Collection("unity_venues").Document(venue.id);
        var task = docRef.GetSnapshotAsync();
        await task;

        DocumentSnapshot snapshot = task.Result;
        if (snapshot.Exists)
        {
            // Debug.Log("start loading venue detail for " + venue.id);
            string levelId = venue.id;
            //Debug.Log("start retrieving scriptable objects");

            // Retrieve the scriptable object IDs for this venue level
            int? backgroundId = snapshot.TryGetValue<int>("background", out int backgroundTemp) ? (int?)backgroundTemp : null;
            int? solidLayerId = snapshot.TryGetValue<int>("solid_layer", out int solidLayerTemp) ? (int?)solidLayerTemp : null;
            List<int> bookableIds = snapshot.TryGetValue<List<int>>("bookables", out List<int> bookableTemp) ? bookableTemp : new List<int>();
            List<int> facilityIds = snapshot.TryGetValue<List<int>>("facilities", out List<int> facilityTemp) ? facilityTemp : new List<int>();
            List<int> interactableIds = snapshot.TryGetValue<List<int>>("interactables", out List<int> interactableTemp) ? interactableTemp : new List<int>();
            List<int> solidObjectIds = snapshot.TryGetValue<List<int>>("solid_objects", out List<int> solidObjectTemp) ? solidObjectTemp : new List<int>();
            List<int> transferPointIds = snapshot.TryGetValue<List<int>>("transferPoints", out List<int> transferPointTemp) ? transferPointTemp : new List<int>();

            //print(backgroundId.HasValue ? backgroundId.ToString() : "No background ID");
            //print(solidLayerId.HasValue ? solidLayerId.ToString() : "No solid layer ID");
            //print("Bookable IDs: " + string.Join(", ", bookableIds));
            //print("Facility IDs: " + string.Join(", ", facilityIds));
            //print("Interactable IDs: " + string.Join(", ", interactableIds));
            //print("Solid Object IDs: " + string.Join(", ", solidObjectIds));
            //print("Transfer Point IDs: " + string.Join(", ", transferPointIds));


            // Start the background and bookables loading tasks
            var backgroundTask = LoadVenueBackgroundAsync(backgroundId.GetValueOrDefault(default_background_id), levelId);
            var solidLayerTask = LoadVenueSolidLayerAsync(solidLayerId.GetValueOrDefault(default_solid_layer_id), levelId);
            var bookablesTask = LoadVenueBookablesAsync(bookableIds, levelId);
            var facilitiesTask = LoadVenueFacilitiesAsync(facilityIds, levelId);
            var interactablesTask = LoadVenueInteractablesAsync(interactableIds, levelId);
            var solidObjectsTask = LoadVenueSolidObjectsAsync(solidObjectIds, levelId);
            var transferPointsTask = LoadVenueTransferPointsAsync(transferPointIds, levelId);

            // Process background independently
            _ = ProcessBackgroundAsync(backgroundTask, venueRenderer, venue, levelId);
            _ = ProcessSolidLayerAsync(solidLayerTask, venueRenderer, venue, levelId);
            // Process objects of functions independently
            _ = ProcessFacilitiesAsync(facilitiesTask, venueManager, venue, levelId);
            _ = ProcessTransferPointsAsync(transferPointsTask, venueManager, venue, levelId);
            _ = ProcessInteractablesAsync(interactablesTask, venueManager, venue, levelId);
            _ = ProcessSolidObjectsAsync(solidObjectsTask, venueManager, venue, levelId);
            _ = ProcessBookablesAsync(bookablesTask, venueManager, venue, levelId);




        }
        else
        {
            Debug.LogError("Document does not exist!");
        }

        return null;
    }


    // load models

    private async Task<VenueBackground> LoadVenueBackgroundAsync(int backgroundId, string levelId)
    {
        VenueBackground venueBackground = ScriptableObject.CreateInstance<VenueBackground>();
        venueBackground.id = backgroundId.ToString();
        // print("start loading background");
        string imageUrl = $"gs://orbital2024-9f1b1.appspot.com/venue_images/{backgroundId}.png";
        Texture2D texture = await firebaseStorageManager.LoadImageAsync(imageUrl);


        //Debug.Log($"loaded successfully background texture {backgroundId}");
        if (texture == null)
        {
            // Handle error: use default texture
            Debug.LogError($"Failed to load image with id: {backgroundId}. Using default texture.");
            texture = await firebaseStorageManager.LoadImageAsync($"gs://orbital2024-9f1b1.appspot.com/venue_images/{default_background_id}.png");

        }

        venueBackground.dimension = new Vector2(texture.width, texture.height);
        TileBase[] tiles = TileUtility.ConvertTextureToTiles(texture);

        //print($"converted background {backgroundId} tiles successfully");

        TileSet tileSet = ScriptableObject.CreateInstance<TileSet>();
        tileSet.tiles = tiles;
        venueBackground.tileSet = tileSet;

        // start rendering background;
        //print("venueBackground created successfully");


        return venueBackground;

    }

    private async Task<VenueSolidLayer> LoadVenueSolidLayerAsync(int solidLayerId, string levelId)
    {
        VenueSolidLayer venueSolidLayer = ScriptableObject.CreateInstance<VenueSolidLayer>();
        venueSolidLayer.id = solidLayerId.ToString();
        // print("start loading solid layer");
        string imageUrl = $"gs://orbital2024-9f1b1.appspot.com/venue_images/{solidLayerId}.png";
        Texture2D texture = await firebaseStorageManager.LoadImageAsync(imageUrl);


        //Debug.Log($"loaded successfully solidLayer texture {solidLayerId}");

        if (texture == null)
        {
            // Handle error: use default texture
            Debug.LogError($"Failed to load image with id: {solidLayerId}. Using default texture.");
            texture = await firebaseStorageManager.LoadImageAsync($"gs://orbital2024-9f1b1.appspot.com/venue_images/{default_solid_layer_id}.png");

        }

        venueSolidLayer.dimension = new Vector2(texture.width, texture.height);
        TileBase[] tiles = TileUtility.ConvertTextureToTiles(texture);
        TileSet tileSet = ScriptableObject.CreateInstance<TileSet>();
        tileSet.tiles = tiles;
        venueSolidLayer.tileSet = tileSet;

        return venueSolidLayer;
    }

    private async Task<VenueBookable[]> LoadVenueBookablesAsync(List<int> ids, string levelId)
    {
        FirebaseFirestore firestore = FirebaseFirestore.DefaultInstance;
        List<VenueBookable> venueBookables = new List<VenueBookable>();

        foreach (int id in ids)
        {
            try
            {
                DocumentReference docRef = firestore.Collection("venues_bookables").Document(id.ToString());
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    VenueBookable venueBookable = ScriptableObject.CreateInstance<VenueBookable>();
                    venueBookables.Add(venueBookable);
                    //venueBookable = snapshot.ConvertTo<VenueBookable>();

                    // Retrieve fields, using default values if they are missing
                    venueBookable.id = id.ToString();
                    venueBookable.bookableName = snapshot.ContainsField("name") ? snapshot.GetValue<string>("name") : "study_room";
                    // Parse color from HTML string
                    string colorString = snapshot.ContainsField("color") ? snapshot.GetValue<string>("color") : "white";
                    if (ColorUtility.TryParseHtmlString(colorString, out Color color))
                    {
                        venueBookable.color = color;
                    }
                    else
                    {
                        Debug.LogError($"Failed to parse color '{colorString}' for bookable {id}");
                        // TODO: try using rgb instead of string parsing

                    }
                    List<float> sizeList = snapshot.ContainsField("size") ? snapshot.GetValue<List<float>>("size") : new List<float> { 1f, 1f };

                    if (sizeList != null && sizeList.Count == 2)
                    {
                        venueBookable.size = new Vector2(sizeList[0], sizeList[1]);
                    }
                    else
                    {
                        Debug.LogError($"Invalid size data for venue {id}. Expected 2 elements, got {sizeList?.Count}");
                    }

                    venueBookable.capacity = snapshot.ContainsField("capacity") ? (snapshot.GetValue<int?>("capacity") ?? 10) : 10;
                    // Convert position list to Vector2
                    List<float> positionList = snapshot.ContainsField("position") ? snapshot.GetValue<List<float>>("position") : new List<float> { 1f, 1f };
                    if (positionList != null && positionList.Count == 2)
                    {
                        venueBookable.position = new Vector2(positionList[0], positionList[1]);
                    }
                    else
                    {
                        Debug.LogError($"Invalid position data for venue {id}. Expected 2 elements, got {positionList?.Count}");
                    }

                    // Assuming 'bookable' is a prefab or GameObject to be assigned later
                    venueBookable.bookable = null;
                }
                else
                {
                    Debug.LogError($"Document with id {id} does not exist in Firestore.");
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Error loading venue bookable with id {id}: {ex.Message}");
            }
        }

        
        return venueBookables.ToArray();
    }

    private async Task<VenueFacility[]> LoadVenueFacilitiesAsync(List<int> ids, string levelId)
    {
        FirebaseFirestore firestore = FirebaseFirestore.DefaultInstance;
        List<VenueFacility> venueFacilities = new List<VenueFacility>();

        foreach (int id in ids)
        {
            try
            {
                DocumentReference docRef = firestore.Collection("venues_facilities").Document(id.ToString());
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    VenueFacility venueFacility = ScriptableObject.CreateInstance<VenueFacility>();
                    venueFacilities.Add(venueFacility);
                    //venueBookable = snapshot.ConvertTo<VenueBookable>();

                    // Retrieve fields, using default values if they are missing
                    venueFacility.id = id.ToString();
                    venueFacility.category = snapshot.ContainsField("category") ? snapshot.GetValue<string>("category") : "water_dispenser";
                    venueFacility.name = "facility " + venueFacility.id + " " + venueFacility.category;


                    List<float> sizeList = snapshot.ContainsField("size") ? snapshot.GetValue<List<float>>("size") : new List<float> { 1f, 1f };

                    if (sizeList != null && sizeList.Count == 2)
                    {
                        venueFacility.size = new Vector2(sizeList[0], sizeList[1]);
                    }
                    else
                    {
                        Debug.LogError($"Invalid size data for venue {id}. Expected 2 elements, got {sizeList?.Count}");
                    }

               
                    // assign position
                    List<float> positionList = snapshot.ContainsField("position") ? snapshot.GetValue<List<float>>("position") : new List<float> { 1f, 1f };
                    if (positionList != null && positionList.Count == 2)
                    {
                        venueFacility.position = new Vector2(positionList[0], positionList[1]);
                    }
                    else
                    {
                        Debug.LogError($"Invalid position data for venue {id}. Expected 2 elements, got {positionList?.Count}");
                    }
                    Texture2D venueTexture;

                    if (venueFacilitiesDict.TryGetValue(venueFacility.id, out venueTexture))
                    {
                        if (venueTexture != null)
                        {
                            Sprite sprite = SpriteUtility.ConvertToSprite(venueTexture);
                            venueFacility.sprite = sprite;
                        }
                        else
                        {
                            venueFacilitiesDict.Remove(venueFacility.id);
                        }
                    }
                    else
                    {
                        int imageId = snapshot.ContainsField("image") ? snapshot.GetValue<int>("image") : default_facility_id;
                        string imageUrl = $"gs://orbital2024-9f1b1.appspot.com/venue_images/{imageId}.png";
                        Texture2D texture = await firebaseStorageManager.LoadImageAsync(imageUrl);

                        if (texture == null)
                        {
                            // Handle error: use default texture
                            Debug.LogError($"Failed to load image with id: {imageId}. Using default texture.");
                            texture = await firebaseStorageManager.LoadImageAsync($"gs://orbital2024-9f1b1.appspot.com/venue_images/{default_facility_id}.png");

                        }

                        Sprite sprite = SpriteUtility.ConvertToSprite(venueTexture);
                        venueFacility.sprite = sprite;
                    }

                    // Assuming 'bookable' is a prefab or GameObject to be assigned later
                    venueFacility.facility = null;
                }
                else
                {
                    Debug.LogError($"Document with id {id} does not exist in Firestore.");
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Error loading venue bookable with id {id}: {ex.Message}");
            }
        }

        return venueFacilities.ToArray();
    }

    private async Task<VenueInteractable[]> LoadVenueInteractablesAsync(List<int> ids, string levelId)
    {
        FirebaseFirestore firestore = FirebaseFirestore.DefaultInstance;
        List<VenueInteractable> venueInteractables = new List<VenueInteractable>();

        foreach (int id in ids)
        {
            try
            {
                DocumentReference docRef = firestore.Collection("venues_interactables").Document(id.ToString());
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    VenueInteractable venueInteractable = ScriptableObject.CreateInstance<VenueInteractable>();
                    venueInteractables.Add(venueInteractable);

                    venueInteractable.id = id.ToString();
                    venueInteractable.category = snapshot.ContainsField("category") ? snapshot.GetValue<string>("category") : "default_category";
                    venueInteractable.name = "interactable " + venueInteractable.id + " " + venueInteractable.category;

                    List<float> sizeList = snapshot.ContainsField("size") ? snapshot.GetValue<List<float>>("size") : new List<float> { 1f, 1f };

                    if (sizeList != null && sizeList.Count == 2)
                    {
                        venueInteractable.size = new Vector2(sizeList[0], sizeList[1]);
                    }
                    else
                    {
                        Debug.LogError($"Invalid size data for interactable {id}. Expected 2 elements, got {sizeList?.Count}");
                    }

                    List<float> positionList = snapshot.ContainsField("position") ? snapshot.GetValue<List<float>>("position") : new List<float> { 1f, 1f };

                    if (positionList != null && positionList.Count == 2)
                    {
                        venueInteractable.position = new Vector2(positionList[0], positionList[1]);
                    }
                    else
                    {
                        Debug.LogError($"Invalid position data for interactable {id}. Expected 2 elements, got {positionList?.Count}");
                    }

                    Texture2D venueTexture;

                    if (venueInteractablesDict.TryGetValue(venueInteractable.id, out venueTexture))
                    {
                        if (venueTexture != null)
                        {
                            Sprite sprite = SpriteUtility.ConvertToSprite(venueTexture);
                            venueInteractable.sprite = sprite;
                        }
                        else
                        {
                            venueInteractablesDict.Remove(venueInteractable.id);
                        }
                    }
                    else
                    {
                        int imageId = snapshot.ContainsField("image") ? snapshot.GetValue<int>("image") : default_interactable_id;
                        string imageUrl = $"gs://orbital2024-9f1b1.appspot.com/venue_images/{imageId}.png";
                        Texture2D texture = await firebaseStorageManager.LoadImageAsync(imageUrl);

                        if (texture == null)
                        {
                            Debug.LogError($"Failed to load image with id: {imageId}. Using default texture.");
                            texture = await firebaseStorageManager.LoadImageAsync($"gs://orbital2024-9f1b1.appspot.com/venue_images/{default_interactable_id}.png");
                        }

                        Sprite sprite = SpriteUtility.ConvertToSprite(venueTexture);
                        venueInteractable.sprite = sprite;
                    }

                    venueInteractable.interactable = null;
                }
                else
                {
                    Debug.LogError($"Document with id {id} does not exist in Firestore.");
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Error loading venue interactable with id {id}: {ex.Message}");
            }
        }

        return venueInteractables.ToArray();
    }

    private async Task<VenueSolidObject[]> LoadVenueSolidObjectsAsync(List<int> ids, string levelId)
    {
        FirebaseFirestore firestore = FirebaseFirestore.DefaultInstance;
        List<VenueSolidObject> venueSolidObjects = new List<VenueSolidObject>();

        foreach (int id in ids)
        {
            try
            {
                DocumentReference docRef = firestore.Collection("venues_solid_objects").Document(id.ToString());
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    VenueSolidObject venueSolidObject = ScriptableObject.CreateInstance<VenueSolidObject>();
                    venueSolidObjects.Add(venueSolidObject);

                    venueSolidObject.id = id.ToString();
                    venueSolidObject.category = snapshot.ContainsField("category") ? snapshot.GetValue<string>("category") : "default_category";
                    venueSolidObject.name = "solid object " + venueSolidObject.id + " " + venueSolidObject.category;

                    List<float> sizeList = snapshot.ContainsField("size") ? snapshot.GetValue<List<float>>("size") : new List<float> { 1f, 1f };

                    if (sizeList != null && sizeList.Count == 2)
                    {
                        venueSolidObject.size = new Vector2(sizeList[0], sizeList[1]);
                    }
                    else
                    {
                        Debug.LogError($"Invalid size data for solid object {id}. Expected 2 elements, got {sizeList?.Count}");
                    }

                    List<float> positionList = snapshot.ContainsField("position") ? snapshot.GetValue<List<float>>("position") : new List<float> { 1f, 1f };

                    if (positionList != null && positionList.Count == 2)
                    {
                        venueSolidObject.position = new Vector2(positionList[0], positionList[1]);
                    }
                    else
                    {
                        Debug.LogError($"Invalid position data for solid object {id}. Expected 2 elements, got {positionList?.Count}");
                    }

                    Texture2D venueTexture;

                    if (venueSolidObjectsDict.TryGetValue(venueSolidObject.id, out venueTexture))
                    {
                        if (venueTexture != null)
                        {
                            Sprite sprite = SpriteUtility.ConvertToSprite(venueTexture);
                            venueSolidObject.sprite = sprite;
                        }
                        else
                        {
                            venueSolidObjectsDict.Remove(venueSolidObject.id);
                        }
                    }
                    else
                    {
                        int imageId = snapshot.ContainsField("image") ? snapshot.GetValue<int>("image") : default_solid_object_id;
                        string imageUrl = $"gs://orbital2024-9f1b1.appspot.com/venue_images/{imageId}.png";
                        Texture2D texture = await firebaseStorageManager.LoadImageAsync(imageUrl);

                        if (texture == null)
                        {
                            Debug.LogError($"Failed to load image with id: {imageId}. Using default texture.");
                            texture = await firebaseStorageManager.LoadImageAsync($"gs://orbital2024-9f1b1.appspot.com/venue_images/{default_solid_object_id}.png");
                        }

                        Sprite sprite = SpriteUtility.ConvertToSprite(venueTexture);
                        venueSolidObject.sprite = sprite;
                    }

                    venueSolidObject.solidObject = null;
                }
                else
                {
                    Debug.LogError($"Document with id {id} does not exist in Firestore.");
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Error loading venue solid object with id {id}: {ex.Message}");
            }
        }

        return venueSolidObjects.ToArray();
    }

    private async Task<VenueTransferPoint[]> LoadVenueTransferPointsAsync(List<int> ids, string levelId)
    {
        // Implementation to load venue transfer points from Firestore
        // Placeholder for now
        return await Task.FromResult(new VenueTransferPoint[0]);
    }


    // Async Processes to save time
    private async Task ProcessBackgroundAsync(Task<VenueBackground> backgroundTask, VenueRenderer venueRenderer, Venue venue, string levelId)
    {
        venue.venueBackground = await backgroundTask;
        if (levelId == venueRenderer.venue.id)
        {
            await venueRenderer.InitializeBackground();
        }
    }

    private async Task ProcessSolidLayerAsync(Task<VenueSolidLayer> solidLayerTask, VenueRenderer venueRenderer, Venue venue, string levelId)
    {
        venue.venueSolidLayer= await solidLayerTask;
        if (levelId == venueRenderer.venue.id)
        {
            await venueRenderer.InitializeSolidLayer();
        }
    }

    private async Task ProcessBookablesAsync(Task<VenueBookable[]> bookablesTask, VenueManager venueManager, Venue venue, string levelId)
    {
        venue.venueBookables = await bookablesTask;
        if (levelId == venueManager.venue.id)
        {
            await venueManager.InitializeBookables();
        }
    }

    private async Task ProcessFacilitiesAsync(Task<VenueFacility[]> facilitiesTask, VenueManager venueManager, Venue venue, string levelId)
    {
        venue.venueFacilities = await facilitiesTask;
        if (levelId == venueManager.venue.id)
        {
            await venueManager.InitializeFacilities();
        }
    }

    private async Task ProcessInteractablesAsync(Task<VenueInteractable[]> interactablesTask, VenueManager venueManager, Venue venue, string levelId)
    {
        venue.venueInteractables = await interactablesTask;
        if (levelId == venueManager.venue.id)
        {
            await venueManager.InitializeInteractables();
        }
    }

    private async Task ProcessSolidObjectsAsync(Task<VenueSolidObject[]> solidObjectsTask, VenueManager venueManager, Venue venue, string levelId)
    {
        venue.venueSolidObjects = await solidObjectsTask;
        if (levelId == venueManager.venue.id)
        {
            await venueManager.InitializeSolidObjects();
        }
    }

    private async Task ProcessTransferPointsAsync(Task<VenueTransferPoint[]> transferPointsTask, VenueManager venueManager, Venue venue, string levelId)
    {
        venue.venueTransferPoints = await transferPointsTask;
        if (levelId == venueManager.venue.id)
        {
            await venueManager.InitializeTransferPoints();
        }
    }


}
