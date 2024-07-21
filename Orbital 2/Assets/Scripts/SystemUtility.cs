using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class SystemUtility
{
    // Use this for converting dictionary of rgb into unity color data
    public static Color ConvertToColorFromDictRGB(Dictionary<string, object> colorData)
    {
        float r = float.Parse(colorData["r"].ToString());
        float g = float.Parse(colorData["g"].ToString());
        float b = float.Parse(colorData["b"].ToString());
        float a = float.Parse(colorData["a"].ToString());
        return new Color(r, g, b, a);
    }

    // use this for parsing color data from string
    // TODO

    //use this func for layout modification and analytic monitoring
    // TODO

    //  get Current date in string 'yyyymmdd'
    public static string GetCurrentDate()
    {
        return DateTime.Now.ToString("yyyyMMdd");
    }

    //  get current time in int
    public static int GetCurrentTime()
    {
        return int.Parse(DateTime.Now.ToString("HHmm"));
    }

    //  get current hr in int
    public static int GetCurrentHour()
    {
        return DateTime.Now.Hour;
    }

    //  get current min in int
    public static int GetCurrentMin()
    {
        return DateTime.Now.Minute;
    }
}



