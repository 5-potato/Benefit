using UnityEngine;

[System.Serializable]
public class OWM_Coord3
{
    public float lon;
    public float lat;
}

[System.Serializable]
public class OWM_Weather3
{
    public int id;
    public string main;
    public string description;
    public string icon;
}

[System.Serializable]
public class OWM_Main3
{
    public float temp;
    public float feels_like;
    public float temp_min;
    public float temp_max;
    public int pressure;
    public int humidity;
}

[System.Serializable]
public class OWM_Wind3
{
    public float speed;
    public int deg;
}

[System.Serializable]
public class OWM_Clouds3
{
    public int all;
}

[System.Serializable]
public class OWM_Sys3
{
    public int type;
    public int id;
    public string country;
    public int sunrise;
    public int sunset;
}

[System.Serializable]
public class WeatherData3
{
    public OWM_Coord3 coord;
    public OWM_Weather3[] weather;
    public string basem;
    public OWM_Main3 main;
    public int visibility;
    public OWM_Wind3 wind;
    public OWM_Clouds3 clouds;
    public int dt;
    public OWM_Sys3 sys;
    public int timezone;
    public int id;
    public string name;
    public int cod;
}

[System.Serializable]
public class JsonHelper3
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

