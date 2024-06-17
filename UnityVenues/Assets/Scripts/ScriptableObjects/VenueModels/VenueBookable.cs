using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VenueBookable", menuName = "Scriptable Objects/VenueBookable")]
public class VenueBookable : ScriptableObject
{
    public string id;
    public string bookableName;
    public int capacity;
    public Vector2 position;
    public BookableStyle bookableStyle;
    public List<TimeRange> availableTimes; // Add availability times
}


[System.Serializable]
public class BookableStyle
{
    public string id;
    public Color color;
    public Vector2 size;
}

[System.Serializable]
public class TimeRange
{
    public string dayOfWeek;
    public string startTime;
    public string endTime;
}

