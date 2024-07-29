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
    [SerializeField]
    public Dictionary<string, List<int>> slots;
    [SerializeField]
    public Dictionary<string, List<int>> available;
    [SerializeField]
    public Dictionary<string, Dictionary<int, string>> booked;

    public Bookable bookable;
}
