using UnityEngine;

public class VenueManager : MonoBehaviour
{
    public VenueDatabase venueDatabase;
    public GameObject bookablePrefab;
    public GameObject facilityPrefab;
    public GameObject solidObjectPrefab;
    public GameObject interactablePrefab;
    public GameObject transferPointPrefab;
    public GameObject venueRendererPrefab;

    public string venueId;
    public Texture2D[] textures; // Array to hold your textures

    private void Start()
    {
        // Example to load a specific venue
        LoadVenue(venueId);
    }

    public void LoadVenue(string venueId)
    {
        Venue venue = venueDatabase.GetVenue(venueId); // get loaded venue from venueID

        if (venue != null)
        {
            // Identify and slice textures
            Texture2D venueTexture = FindTextureById(venueId);
            if (venueTexture != null)
            {
                // Create TileSet from the identified texture
                TileSet tileSet = ScriptableObject.CreateInstance<TileSet>();
                tileSet.tiles = TileUtility.ConvertTexturesToTiles(new Texture2D[] { venueTexture });

                // Assign the TileSet to the VenueBackground
                venue.venueBackground.tileSet = tileSet;
            }

            // Instantiate the VenueRenderer and pass the venue data
            GameObject venueRendererObject = Instantiate(venueRendererPrefab, Vector3.zero, Quaternion.identity);
            VenueRenderer venueRenderer = venueRendererObject.GetComponent<VenueRenderer>();
            venueRenderer.Initialize(venue);

            // Instantiate other venue objects
            InstantiateObjects(venue);
        }
    }

    private Texture2D FindTextureById(string id)
    {
        foreach (var texture in textures)
        {
            if (texture.name == id)
            {
                return texture;
            }
        }
        return null;
    }

    private void InstantiateObjects(Venue venue)
    {
        // Instantiate Bookables
        foreach (var bookable in venue.venueBookables)
        {
            InstantiatePrefab(bookablePrefab, bookable.position, bookable.bookableStyle.size, bookable.bookableStyle.color);
        }

        // Instantiate Facilities
        foreach (var facility in venue.venueFacilities)
        {
            InstantiatePrefab(facilityPrefab, facility.position);
        }

        // Instantiate Solid Objects
        foreach (var solidObject in venue.venueSolidObjects)
        {
            InstantiatePrefab(solidObjectPrefab, solidObject.position);
        }

        // Instantiate Interactables
        foreach (var interactable in venue.venueInteractables)
        {
            InstantiatePrefab(interactablePrefab, interactable.position);
        }

        // Instantiate Transfer Points
        foreach (var transferPoint in venue.venueTransferPoints)
        {
            InstantiatePrefab(transferPointPrefab, transferPoint.position);
        }
    }

    private void InstantiatePrefab(GameObject prefab, Vector3 position, Vector2 size = default, Color color = default)
    {
        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        if (size != default)
        {
            obj.transform.localScale = new Vector3(size.x, size.y, 1);
        }
        if (color != default)
        {
            obj.GetComponent<Renderer>().material.color = color;
        }
    }
}
