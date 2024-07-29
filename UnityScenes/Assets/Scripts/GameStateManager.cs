using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameStateManager : MonoBehaviour
{
    public FirebaseFirestoreManager firebaseFirestoreManager;
    public FirebaseInitializer firebaseInitializer;
    public VenueDatabase VenueDatabase;
    public VenueManager venueManager;
    public SceneLoader sceneLoader;
    public int venueId = 54619721;
    public Loading loading;
    public static bool justTransferred = false;

    public void InitializeSpecificVenue()
    {
        //print("start specific venue");
        sceneLoader = SceneLoader.Instance;
        firebaseInitializer.Initialize();
        firebaseFirestoreManager.InitializeDatabase(venueId);

        // for test purpose only load 0(the first floor of a the venue set manually in firestoremanager)
    }

    // called by urlSchemeHandler
    public void SetVenueId(string id)
    {
        venueId = int.Parse(id);
        InitializeSpecificVenue();
        loading.StartLoading();
    }
}
