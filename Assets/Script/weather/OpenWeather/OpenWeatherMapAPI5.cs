using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class OpenWeatherMapAPI5 : MonoBehaviour
{
    public string KEY_ID;
    public Text weatherText5;
    public RawImage weatherIcon5;
    public WeatherData5 weatherInfo5;
    public InputField inputField;

    private DateTime tomorrow5;
    private string defaultCity = "Seongbuk-gu"; // �⺻ ���� ����

    void Start()
    {
        DateTime currentDate = DateTime.Now;
        tomorrow5 = currentDate.AddDays(4);
        CheckCityWeather(defaultCity); // ���� �� �⺻ ���÷� ���� ���� ��������
    }

    public void CheckCityWeather(string city)
    {
        Debug.Log("CheckCityWeather: " + city); // ����� �α� �߰�
        StartCoroutine(GetWeather(city));
    }

    IEnumerator GetWeather(string city)
    {
        city = UnityWebRequest.EscapeURL(city);

        string url = "http://api.openweathermap.org/data/2.5/forecast?units=metric&appid=" + KEY_ID + "&q=" + city;

        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("Network error: " + www.error);
        }
        else
        {
            string json = www.downloadHandler.text;
            WeatherForecastData5 forecastData = JsonUtility.FromJson<WeatherForecastData5>(json);

            if (forecastData != null && forecastData.list.Length > 0)
            {
                // ������ �ְ� �� ���� �µ��� ���� �������� ����մϴ�.
                float maxTemp = float.MinValue;
                float minTemp = float.MaxValue;

                // ù ��° ���� �������� ������ ���� ���
                string icon = forecastData.list[0].weather[0].icon;

                foreach (WeatherData5 data in forecastData.list)
                {
                    DateTime forecastDate = UnixTimeStampToDateTime(data.dt);

                    // ������ �����͸� ���
                    if (forecastDate.Date == tomorrow5.Date)
                    {
                        if (data.main.temp_max > maxTemp)
                        {
                            maxTemp = data.main.temp_max;
                        }

                        if (data.main.temp_min < minTemp)
                        {
                            minTemp = data.main.temp_min;
                        }
                    }
                }

                // UI ������Ʈ�� �ڷ�ƾ���� ó��
                yield return UpdateUI(maxTemp, minTemp, icon);
            }
        }
    }

    IEnumerator UpdateUI(float maxTemp, float minTemp, string icon)
    {
        weatherText5.gameObject.SetActive(true);
        weatherText5.text = tomorrow5.ToString("yyyy-MM-dd") + "\n" +
            minTemp.ToString("N1") + " ��C / " + maxTemp.ToString("N1") + " ��C\n";

        // ���� �������� ǥ��
        string url = "http://openweathermap.org/img/wn/" + icon + "@2x.png";
        UnityWebRequest iconRequest = UnityWebRequestTexture.GetTexture(url);
        yield return iconRequest.SendWebRequest();

        if (!iconRequest.isNetworkError && !iconRequest.isHttpError)
        {
            Texture2D iconTexture = DownloadHandlerTexture.GetContent(iconRequest);
            weatherIcon5.texture = iconTexture;
            weatherIcon5.gameObject.SetActive(true);
        }
    }

    DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return epoch.AddSeconds(unixTimeStamp).ToLocalTime();
    }
}

[Serializable]
public class WeatherForecastData5
{
    public WeatherData5[] list;
}
