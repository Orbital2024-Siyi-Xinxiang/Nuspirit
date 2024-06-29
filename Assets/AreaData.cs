using System;
using System.Collections.Generic;

[Serializable]
public class AreaData
{
    public string sceneName;
    public List<LocationData> vertices;

    public AreaData(string sceneName, List<LocationData> vertices)
    {
        this.sceneName = sceneName;
        this.vertices = vertices;
    }
}
