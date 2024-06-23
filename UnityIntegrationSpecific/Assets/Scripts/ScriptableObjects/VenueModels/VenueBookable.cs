using UnityEngine;
using Firebase.Firestore;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "VenueBookable", menuName = "Scriptable Objects/VenueBookable")]
[FirestoreData]
public class VenueBookable : ScriptableObject
{
    public string id;

    // bookable style
    public string bookableName;
    public Color color;
    public Vector2 size;

    public int capacity;
    public Vector2 position;

    // book info

    private Dictionary<string, List<int>> _slots;
    [FirestoreProperty]
    public Dictionary<string, List<int>> slots
    {
        get { return _slots; }
        set { _slots = value; }
    }

    private Dictionary<string, List<int>> _available;
    [FirestoreProperty]
    public Dictionary<string, List<int>> available
    {
        get { return _available; }
        set { _available = value; }
    }

    private Dictionary<string, List<Dictionary<int, string>>> _booked;
    [FirestoreProperty]
    public Dictionary<string, List<Dictionary<int, string>>> booked
    {
        get { return _booked; }
        set { _booked = value; }
    }

    public Bookable bookable;
}
