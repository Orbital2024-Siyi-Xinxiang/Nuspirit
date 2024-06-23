using UnityEngine;
using UnityEngine.Tilemaps;

public class GameStateManager : MonoBehaviour
{
    public FirebaseFirestoreManager firebaseFirestoreManager;
    public VenueDatabase VenueDatabase;
    public VenueManager venueManager;

    public const int testVenueId = 54619721;
    public const string testLevelId = "0";


    public static bool justTransferred = false;

    private void Start()
    {
        Debug.Log("start");

        venueManager.Initialize(testLevelId);
        firebaseFirestoreManager.InitializeDatabase(testVenueId);
        // for test purpose only load 0(the first floor of a the venue set manually in firestoremanager)
    }

    private void Update()
    {
        
    }

    // when scene venue changes, need to initialize another venue Manager and venue Renderer
}
