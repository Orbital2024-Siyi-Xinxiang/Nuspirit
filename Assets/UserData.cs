using System;
using System.Collections.Generic;

[Serializable]
public class UserData
{
    public string ID;
    public string email;
    public string password;
    public string avatarDesign;
    public bool isOutdoor;
    public bool hasAircon;
    public bool hasPrinter;
    public bool hasCharger;
    public bool hasMeetingRooms;
    public string openingTime;
    public string closingTime;
    public bool hasFoodCourtsAround;
    public bool PreferenceInitialized;  // New field
    public List<FriendData> friends;
    public UserLocationData location;

    public UserData(
        string id, 
        string email, 
        string password, 
        string avatarDesign = "defaultAvatar", 
        bool isOutdoor = false, 
        bool hasAircon = false, 
        bool hasPrinter = false, 
        bool hasCharger = false, 
        bool hasMeetingRooms = false, 
        string openingTime = "00:00", 
        string closingTime = "00:00", 
        bool hasFoodCourtsAround = false)
    {
        this.ID = id;
        this.email = email;
        this.password = password;
        this.avatarDesign = avatarDesign;
        this.isOutdoor = isOutdoor;
        this.hasAircon = hasAircon;
        this.hasPrinter = hasPrinter;
        this.hasCharger = hasCharger;
        this.hasMeetingRooms = hasMeetingRooms;
        this.openingTime = openingTime;
        this.closingTime = closingTime;
        this.hasFoodCourtsAround = hasFoodCourtsAround;
        this.PreferenceInitialized = false; // Default value
        this.friends = new List<FriendData>();
        this.location = new UserLocationData();
    }
}

[Serializable]
public class FriendData
{
    public string ID;
    public string requestMessage;
    public bool agreed;
    public bool requestGathering;
    public bool gatheringAgreed;

    public FriendData(string id, string requestMessage, bool agreed, bool requestGathering, bool gatheringAgreed)
    {
        this.ID = id;
        this.requestMessage = requestMessage;
        this.agreed = agreed;
        this.requestGathering = requestGathering;
        this.gatheringAgreed = gatheringAgreed;
    }
}

[Serializable]
public class UserLocationData
{
    public float latitude;
    public float longitude;

    public UserLocationData()
    {
        this.latitude = 0f;
        this.longitude = 0f;
    }

    public UserLocationData(float latitude, float longitude)
    {
        this.latitude = latitude;
        this.longitude = longitude;
    }




    
}
