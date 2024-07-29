using Firebase.Firestore;
using Firebase.Extensions;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class UserManager : MonoBehaviour
{
    public VenueDatabase venueDatabase;
    public VenueRenderer venueRenderer;
    public Venue venue;

    private FirebaseFirestore db;

    public GameObject chatWithUsers;
    public GameObject userPrefab; // Prefab to represent users in the scene
    private Dictionary<string, GameObject> userGameObjects = new Dictionary<string, GameObject>();


    private void InitializeVenueUsers()
    {
        venue = venueRenderer.venue;
    }
   

    public void StartManagingUsers(string venueId)
    {
        // Initialize Firestore
        db = FirebaseFirestore.DefaultInstance;

        venue = venueDatabase.GetVenue(venueId);
        // Subscribe to Firestore updates
        ListenToUserLocations();
    }

    private void ListenToUserLocations()
    {
        db.Collection("venues_users").Listen(snapshot =>
        {
            foreach (var document in snapshot.Documents)
            {
                if (document.Id == venue.id)
                {
                    var status = document.GetValue<string>("status");
                    string userId = "0";
                    if (status == "studying")
                    {
                        GenerateStudyingUser();
                    }
                }
                var realCharacters = document.GetValue<string[]>("real_characters");
                foreach (var characterId in realCharacters)
                {
                    if (!userGameObjects.ContainsKey(characterId))
                    {
                        var userObject = Instantiate(userPrefab, new Vector2(1, 1), Quaternion.identity);
                        userObject.name = characterId;
                        userGameObjects.Add(characterId, userObject);

                        // Add click listener
                        userObject.AddComponent<Button>().onClick.AddListener(() => OnUserClicked(userObject));
                    }
                }
            }
        });
    }


    private void GenerateStudyingUser()
    {
        // TODO: detect user location and generate the user object at corresponding location

    }

    private void GenerateRoamingUser()
    {
        // TODO: generate random-mooving user in the venue and add on lick listener for user information 
    }



    private void SendMessageToUser(string user, string messaging)
    {
        // TODO send message to the user using firebase messaging or unity app messaging 
    }

    private void OnUserClicked(GameObject userObject)
    {
        chatWithUsers.SetActive(true);
    }

    void Update()
    {
        foreach (var userObject in userGameObjects.Values)
        {
            // Move userObject randomly within a certain range
                userObject.transform.position = new Vector2(
                userObject.transform.position.x + Random.Range(-0.1f, 0.1f),
                userObject.transform.position.y + Random.Range(-0.1f, 0.1f)
            );
        }
    }




    void VenueUserUpdate()
    {
        // TODO: link to listen to user locations. update user information every 10 seconds
    }
}
