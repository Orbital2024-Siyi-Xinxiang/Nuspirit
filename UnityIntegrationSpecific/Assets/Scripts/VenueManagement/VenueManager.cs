using System.Threading.Tasks;
using UnityEngine;

public class VenueManager : MonoBehaviour
{


    public Venue venue;

    public VenueRenderer venueRenderer;
    public VenueDatabase venueDatabase;
    public GameObject bookablePrefab;
    public GameObject facilityPrefab;
    public GameObject solidObjectPrefab;
    public GameObject interactablePrefab;
    public GameObject transferPointPrefab;




    public void Initialize(string venueId)
    {

        venue = venueDatabase.GetVenue(venueId);
        // initializes  venueRenderer(fpr background tilemap rendering and solidLayer rendering)
        //print("venue manager initialized");

        //await InitializeFacilities();
        //await InitializeInteractables();
        //await InitializeSolidObjects();
        //await InitializeTransferPoints();
    }

    public Task InitializeBookables()
    {
        // Instantiate Bookables
        print($"start initializing bookables for {venue.id}");

        foreach (VenueBookable bookableData in venue.venueBookables)
        {
            print("instantiate!!!!!!!!!!");
            GameObject obj = Instantiate(bookablePrefab, bookableData.position, Quaternion.identity);
            if (bookableData.size != default)
            {
                obj.transform.localScale = new Vector3(bookableData.size.x, bookableData.size.y, 1);
            }
            if (bookableData.color != default)
            {
                obj.GetComponent<Renderer>().material.color = bookableData.color;
            }

            Bookable bookable = obj.GetComponent<Bookable>();
            bookable.Initialize(bookableData);
            bookableData.bookable = bookable;
        }

        return Task.CompletedTask;
    }

    public void InitializeFacilities()
    {

    }

    private void InitializeInteractables()
    {

    }

    public void InitializeSolidObjects()
    {

    }

    public void InitializeTransferPoints()
    {

    }

}
