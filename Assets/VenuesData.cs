using System;

[Serializable]
public class VenuesData
{
    public string name;//
    public LocationData location;//
    public bool isOutdoor;
    public bool hasAircon;
    public bool hasPrinter;
    public bool hasCharger;
    public bool hasMeetingRooms;
    public string openingTime;//
    public string closingTime;//
    public bool hasFoodCourtsAround;

    public VenuesData(
        string name,//
        LocationData location,//
        bool isOutdoor,
        bool hasAircon,
        bool hasPrinter,
        bool hasCharger,
        bool hasMeetingRooms,
        string openingTime,//
        string closingTime,//
        bool hasFoodCourtsAround)
    {
        this.name = name;
        this.location = location;
        this.isOutdoor = isOutdoor;
        this.hasAircon = hasAircon;
        this.hasPrinter = hasPrinter;
        this.hasCharger = hasCharger;
        this.hasMeetingRooms = hasMeetingRooms;
        this.openingTime = openingTime;
        this.closingTime = closingTime;
        this.hasFoodCourtsAround = hasFoodCourtsAround;
    }
}
