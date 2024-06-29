using System;

[Serializable]
public class LocationData
{
    public float latitude;
    public float longitude;

    public LocationData()
    {
        this.latitude = 0f;
        this.longitude = 0f;
    }

    public LocationData(float latitude, float longitude)
    {
        this.latitude = latitude;
        this.longitude = longitude;
    }
}
