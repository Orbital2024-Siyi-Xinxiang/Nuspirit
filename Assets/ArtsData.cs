using System;

[Serializable]
public class ArtsData
{
    public string defaultMaps;
    public string outdoorBackground;
    public string outdoorBuildings;
    public string indoorFurniture;
    public string indoorWalls;
    public string indoorFloors;
    public string avatar;

    public ArtsData()
    {
        this.defaultMaps = "";
        this.outdoorBackground = "";
        this.outdoorBuildings = "";
        this.indoorFurniture = "";
        this.indoorWalls = "";
        this.indoorFloors = "";
        this.avatar = "";
    }
}
