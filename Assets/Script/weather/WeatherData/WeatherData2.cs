using UnityEngine;

[System.Serializable]
public class OWM_Coord2
{
    public float lon;
    public float lat;
}

[System.Serializable]
public class OWM_Weather2
{
    public int id;
    public string main;
    public string description;
    public string icon;
}

[System.Serializable]
public class OWM_Main2
{
    public float temp;
    public float feels_like;
    public float temp_min;
    public float temp_max;
    public int pressure;
    public int humidity;
}

[System.Serializable]
public class OWM_Wind2
{
    public float speed;
    public int deg;
}

[System.Serializable]
public class OWM_Clouds2
{
    public int all;
}

[System.Serializable]
public class OWM_Sys2
{
    public int type;
    public int id;
    public string country;
    public int sunrise;
    public int sunset;
}

[System.Serializable]
public class WeatherData2
{
    public OWM_Coord2 coord;
    public OWM_Weather2[] weather;
    public string basem;
    public OWM_Main2 main;
    public int visibility;
    public OWM_Wind2 wind;
    public OWM_Clouds2 clouds;
    public int dt;
    public OWM_Sys2 sys;
    public int timezone;
    public int id;
    public string name;
    public int cod;
}

[System.Serializable]
public class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}

