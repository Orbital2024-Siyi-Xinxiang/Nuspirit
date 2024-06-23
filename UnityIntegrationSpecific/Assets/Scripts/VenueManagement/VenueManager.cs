using System.Threading.Tasks;
using UnityEngine;

public class VenueManager : MonoBehaviour
{


    public Venue venue;

    public VenueRenderer venueRenderer;
    public VenueDatabase venueDatabase;
    // prefab for instantiation
    public GameObject bookablePrefab;
    public GameObject facilityPrefab;
    public GameObject solidObjectPrefab;
    public GameObject interactablePrefab;
    public GameObject transferPointPrefab;




    public void Initialize(string venueId)
    {

        venue = venueDatabase.GetVenue(venueId);
        // initializes  venueRenderer(fpr background tilemap rendering and solidLayer rendering)
    }

    public Task InitializeBookables()
    {
        // Instantiate Bookables
        print($"start initializing bookables for {venue.id}");

        foreach (VenueBookable bookableData in venue.venueBookables)
        {
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

    public Task InitializeFacilities()
    {
        // Instantiate Facilities GameObjects using facility prefab
        print($"start initializing facilities for {venue.id}");

        foreach (VenueFacility facilityData in venue.venueFacilities)
        {
            GameObject obj = Instantiate(facilityPrefab, facilityData.position, Quaternion.identity);

            if (facilityData.size != default)
            {
                obj.transform.localScale = new Vector3(facilityData.size.x, facilityData.size.y, 1);
            }
            if (facilityData.sprite != default)
            {
                obj.GetComponent<SpriteRenderer>().sprite = facilityData.sprite;
            }

            Facility facility = obj.GetComponent<Facility>();
            facility.Initialize(facilityData);
            facilityData.facility = facility;
        }

        return Task.CompletedTask;
    }

    public Task InitializeInteractables()
    {
        // Instantiate Interactables
        print($"start initializing interactables for {venue.id}");

        foreach (VenueInteractable interactableData in venue.venueInteractables)
        {
            GameObject obj = Instantiate(interactablePrefab, interactableData.position, Quaternion.identity);

            if (interactableData.size != default)
            {
                obj.transform.localScale = new Vector3(interactableData.size.x, interactableData.size.y, 1);
            }
            if (interactableData.sprite != default)
            {
                obj.GetComponent<SpriteRenderer>().sprite = interactableData.sprite;
            }

            Interactable interactable = obj.GetComponent<Interactable>();
            interactable.Initialize(interactableData);
            interactableData.interactable = interactable;
        }

        return Task.CompletedTask;
    }

    public Task InitializeTransferPoints()
    {
        // Instantiate Transfer Points
        print($"start initializing transfer points for {venue.id}");

        foreach (VenueTransferPoint transferPointData in venue.venueTransferPoints)
        {
            GameObject obj = Instantiate(transferPointPrefab, transferPointData.position, Quaternion.identity);

            TransferPoint transferPoint = obj.GetComponent<TransferPoint>();
            transferPoint.Initialize(transferPointData);
            transferPointData.transferPoint = transferPoint;
        }

        return Task.CompletedTask;
    }

    public Task InitializeSolidObjects()
    {
        // Instantiate Solid Objects
        print($"start initializing solid objects for {venue.id}");

        foreach (VenueSolidObject solidObjectData in venue.venueSolidObjects)
        {
            GameObject obj = Instantiate(solidObjectPrefab, solidObjectData.position, Quaternion.identity);

            if (solidObjectData.size != default)
            {
                obj.transform.localScale = new Vector3(solidObjectData.size.x, solidObjectData.size.y, 1);
            }
            if (solidObjectData.sprite != default)
            {
                obj.GetComponent<SpriteRenderer>().sprite = solidObjectData.sprite;
            }

            SolidObject solidObject = obj.GetComponent<SolidObject>();
            solidObject.Initialize(solidObjectData);
            solidObjectData.solidObject = solidObject;
        }

        return Task.CompletedTask;
    }
}
