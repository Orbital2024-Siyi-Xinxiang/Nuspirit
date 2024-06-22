using Firebase.Firestore;
using Firebase.Storage;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Tilemaps;

public class FirebaseFirestoreManager : MonoBehaviour
{
    
    public FirebaseStorageManager firebaseStorageManager;
    public VenueManager venueManager;
    public VenueRenderer venueRenderer;
    //public VenueRenderer venueRenderer;

    FirebaseFirestore firestore = FirebaseFirestore.DefaultInstance;
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

    // Use this for initialization
    public void InitializeDatabase(int Id)
    {
        print("start initializing database");

       venueId = Id;
       StartCoroutine(LoadVenueDataAsync(venueId.ToString()));
    }

    private IEnumerator LoadVenueDataAsync(string venueId)
    {
        FirebaseFirestore firestore = FirebaseFirestore.DefaultInstance;
        print("successfully created firestore instance");

        // Fetch document from Firestore
        DocumentReference docRef = firestore.Collection("venues").Document(venueId);

        print("Start fetching snapshot");
        
        var task = docRef.GetSnapshotAsync();
        yield return new WaitUntil(() => task.IsCompleted);

        DocumentSnapshot snapshot = task.Result;


        print("snapshot fetched successfully!");

        if (snapshot.Exists)
        {
            // Fetch levels and venue name
            List<int> levels = snapshot.GetValue<List<int>>("levels");
            venueName = snapshot.GetValue<string>("name");
            venueLevels = levels.Count;

            string startLevel = venueLevels > 0 ? levels[0].ToString() : "0";

            venueManager.Initialize(startLevel);
            venueRenderer.Initialize(startLevel);
            // Iterate through each level and load venue details
            foreach (int levelId in levels)
            {
                StartCoroutine(RunLoadVenueDetailsAsync(levelId.ToString()));
            }
        }
        else
        {
            print("Document does not exist!");
        }
    }

    private IEnumerator RunLoadVenueDetailsAsync(string levelId)
    {
        var task = LoadVenueDetailsAsync(levelId);
        yield return new WaitUntil(() => task.IsCompleted);
    }

    private async Task<IEnumerator> LoadVenueDetailsAsync(string levelId)
    {
        

        // Fetch document from Firestore
        DocumentReference docRef = firestore.Collection("unity_venues").Document(levelId);
        var task = docRef.GetSnapshotAsync();
        await task;

        DocumentSnapshot snapshot = task.Result;
        if (snapshot.Exists)
        {
            // Retrieve the scriptable object IDs for this venue level
            int? backgroundId = snapshot.GetValue<int>("background");
            int? solidLayerId = snapshot.GetValue<int>("solid_layer");
            List<int> bookableIds = snapshot.GetValue<List<int>>("bookables");
            List<int> facilityIds = snapshot.GetValue<List<int>>("facilities");
            List<int> interactableIds = snapshot.GetValue<List<int>>("interactables");
            List<int> solidObjectIds = snapshot.GetValue<List<int>>("solid_objects");
            List<int> transferPointIds = snapshot.GetValue<List<int>>("transferPoints");

            // Instantiate the Venue scriptable object and populate its fields
            Venue venue = ScriptableObject.CreateInstance<Venue>();
            venue.id = levelId;

            var backgroundTask = LoadVenueBackgroundAsync(backgroundId.GetValueOrDefault(default_background_id));
            var bookablesTask = LoadVenueBookablesAsync(bookableIds);

            // Wait for both tasks to complete
            await Task.WhenAll(backgroundTask, bookablesTask);

            // Assign the results to the venue
            venue.venueBackground = await backgroundTask;
            venue.venueBookables = await bookablesTask;

            // Initialize the background

            if (levelId == venueRenderer.venue.id)
            {
                await venueRenderer.InitializeBackground();
            }

            // Check and initialize bookables if needed
            if (levelId == venueManager.venue.id)
            {
                await venueManager.InitializeBookables();
            }

            venue.venueFacilities = await LoadVenueFacilitiesAsync(facilityIds);
            venue.venueInteractables = await LoadVenueInteractablesAsync(interactableIds);
            venue.venueSolidObjects = await LoadVenueSolidObjectsAsync(solidObjectIds);
            venue.venueTransferPoints = await LoadVenueTransferPointsAsync(transferPointIds);

            // Add the venue to the database
            VenueDatabase venueDatabase = Resources.Load<VenueDatabase>("VenueDatabase");
            venueDatabase.AddVenue(venue);



        }
        else
        {
            print("Document does not exist!");
        }

        return null;
    }

    //private async Task<VenueSolidLayer> LoadVenueSolidLayerAsync(int solidLayerId)
    //{
    //    VenueSolidLayer venueSolidLayer = ScriptableObject.CreateInstance<VenueSolidLayer>();
    //    return venueSolidLayer;
    //}

    private async Task<VenueBackground> LoadVenueBackgroundAsync(int backgroundId)
    {
        string imageUrl = $"gs://orbital2024-9f1b1.appspot.com/venue_images/{backgroundId}.png";
        Texture2D texture = await firebaseStorageManager.LoadImageAsync(imageUrl);

        if (texture == null)
        {
            // Handle error: use default texture
            print($"Failed to load image with id: {backgroundId}. Using default texture.");
            texture = await firebaseStorageManager.LoadImageAsync($"gs://your-firebase-project-id.appspot.com/{default_background_id}.png");
        }

        TileBase[] tiles = TileUtility.ConvertTexturesToTiles(new Texture2D[] { texture });

        VenueBackground venueBackground = ScriptableObject.CreateInstance<VenueBackground>();
        venueBackground.id = backgroundId.ToString();
        TileSet tileSet = ScriptableObject.CreateInstance<TileSet>();
        tileSet.tiles = tiles;
        venueBackground.tileSet = tileSet;

        // start rendering background;

        return venueBackground;
    }

    private async Task<VenueBookable[]> LoadVenueBookablesAsync(List<int> ids)
    {
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
                    venueBookable = snapshot.ConvertTo<VenueBookable>();

                    // Assign additional fields if they are not part of the automatic conversion
                    venueBookable.id = id.ToString();
                    venueBookable.bookableName = snapshot.GetValue<string>("name");

                    // Parse color from HTML string
                    string colorString = snapshot.GetValue<string>("color");
                    if (ColorUtility.TryParseHtmlString(colorString, out Color color))
                    {
                        venueBookable.color = color;
                    }
                    else
                    {
                        print($"Failed to parse color '{colorString}' for venue {id}");
                    }

                    // Convert size list to Vector2
                    List<float> sizeList = snapshot.GetValue<List<float>>("size");
                    if (sizeList != null && sizeList.Count == 2)
                    {
                        venueBookable.size = new Vector2(sizeList[0], sizeList[1]);
                    }
                    else
                    {
                        print($"Invalid size data for venue {id}. Expected 2 elements, got {sizeList?.Count}");
                    }

                    venueBookable.capacity = snapshot.GetValue<int>("capacity");

                    // Convert position list to Vector2
                    List<float> positionList = snapshot.GetValue<List<float>>("position");
                    if (positionList != null && positionList.Count == 2)
                    {
                        venueBookable.position = new Vector2(positionList[0], positionList[1]);
                    }
                    else
                    {
                        print($"Invalid position data for venue {id}. Expected 2 elements, got {positionList?.Count}");
                    }

                    // Assuming 'bookable' is a prefab or GameObject to be assigned later
                    venueBookable.bookable = null;

                    venueBookables.Add(venueBookable);
                }
                else
                {
                    print($"Document with id {id} does not exist in Firestore.");
                }
            }
            catch (System.Exception ex)
            {
                print($"Error loading venue bookable with id {id}: {ex.Message}");
            }
        }

        return venueBookables.ToArray();
    }


    private async Task<VenueFacility[]> LoadVenueFacilitiesAsync(List<int> ids)
    {
        // Implementation to load venue facilities from Firestore
        // Placeholder for now
        return await Task.FromResult(new VenueFacility[0]);
    }

    private async Task<VenueInteractable[]> LoadVenueInteractablesAsync(List<int> ids)
    {
        // Implementation to load venue interactables from Firestore
        // Placeholder for now
        return await Task.FromResult(new VenueInteractable[0]);
    }

    private async Task<VenueSolidObject[]> LoadVenueSolidObjectsAsync(List<int> ids)
    {
        // Implementation to load venue solid objects from Firestore
        // Placeholder for now
        return await Task.FromResult(new VenueSolidObject[0]);
    }

    private async Task<VenueTransferPoint[]> LoadVenueTransferPointsAsync(List<int> ids)
    {
        // Implementation to load venue transfer points from Firestore
        // Placeholder for now
        return await Task.FromResult(new VenueTransferPoint[0]);
    }
}
