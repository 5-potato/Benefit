using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class OpenWeatherMapAPI : MonoBehaviour
{
    public string KEY_ID;
    public Text weatherText;
    public RawImage weatherIcon;
    public Text explainText;
    public Text weatherClothes;
    public WeatherData weatherInfo;
    public InputField inputField;

    // ���� ������ �ڵ�� ������ �����ϴ� ��ųʸ�
    private Dictionary<string, string> iconDescriptions = new Dictionary<string, string>();
    // �µ� ������ �ش��ϴ� ������ �����ϴ� ��ųʸ�
    private Dictionary<string, string> temperatureDescriptions = new Dictionary<string, string>();

    void Start()
    {
        // ������ ������ ����
        iconDescriptions.Add("01d", "����");
        iconDescriptions.Add("01n", "����");
        iconDescriptions.Add("02d", "���� ����");
        iconDescriptions.Add("02n", "���� ����");
        iconDescriptions.Add("03d", "�帲");
        iconDescriptions.Add("03n", "�帲");
        iconDescriptions.Add("04d", "���� ����");
        iconDescriptions.Add("04n", "���� ����");
        iconDescriptions.Add("09d", "��");
        iconDescriptions.Add("09n", "��");
        iconDescriptions.Add("10d", "�ҳ���");
        iconDescriptions.Add("10n", "�ҳ���");
        iconDescriptions.Add("11d", "õ�� ����");
        iconDescriptions.Add("11n", "õ�� ����");
        iconDescriptions.Add("13d", "��");
        iconDescriptions.Add("13n", "��");
        iconDescriptions.Add("50d", "�Ȱ�");
        iconDescriptions.Add("50n", "�Ȱ�");

        temperatureDescriptions.Add("4-", "���ΰ� �� ������ �ſ� �ٶ��� ���� �δ�, �ܿ� ���� ��������.\n �е�, �β��� ��Ʈ, ���� ��, ��� ��, �񵵸� ���� ��õ�ؿ�:)");
        temperatureDescriptions.Add("5-9", "�ܿ� �����̹Ƿ� ���� �����ϰ� ��������.\n �� ��Ʈ, ��Ʈ��, ���� ��, ��� �� ���� ��õ�ؿ�:)");
        temperatureDescriptions.Add("9-12", "�ʰܿ� �����̹Ƿ� ���� �ɸ��� �ʰ� �����ϰ� �Ծ�� �ؿ�.\n Ʈ��ġ ��Ʈ, �߻� ����, ������ ���� ��õ�ؿ�:)");
        temperatureDescriptions.Add("12-17", "���� �����̹Ƿ� �ϱ����� Ŀ��.\n ����, �����, û����, ��Ʈ, û���� ���� ��õ�ؿ�:)");
        temperatureDescriptions.Add("17-20", "�ʰ��� �����̹Ƿ� �����ϱ� ������, �ҽ��� �� �־��.\n ���� ������̳� ��Ʈ, ������, �ĵ�, �� ���� ���� ��õ�ؿ�:)");
        temperatureDescriptions.Add("20-23", "������ �� �����̹Ƿ� ���� ���� �ſ���.\n ���콺, ���� Ƽ, �����, ������ ���� ��õ�ؿ�:)");
        temperatureDescriptions.Add("23-28", "�ʿ��� �����̹Ƿ� ���� ���� �־��.\n ����, ���� ����, �ݹ���, ����� ���� ��õ�ؿ�:)");
        temperatureDescriptions.Add("28+", "���� ���� �����̹Ƿ� ������ ��������.\n �μҸ�, ����, �ݹ���, ª�� ġ�� ���� ��õ�ؿ�:)");


        CheckCityWeather("Seongbuk-gu");
    }

    public void CheckCityWeather(string city)
    {
        weatherText.gameObject.SetActive(false);
        weatherIcon.gameObject.SetActive(false);
        explainText.gameObject.SetActive(false); // ���� �ؽ�Ʈ�� ����ϴ�
        StartCoroutine(GetWeather(city));

        inputField.text = "";
    }

    IEnumerator GetWeather(string city)
    {
        city = UnityWebRequest.EscapeURL(city);

        string url = "http://api.openweathermap.org/data/2.5/weather?units=metric&appid=";
        url += KEY_ID;
        url += "&q=" + city;

        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        string json = www.downloadHandler.text;
        json = json.Replace("\"base\":", "\"basem\":");
        weatherInfo = JsonUtility.FromJson<WeatherData>(json);

        weatherText.gameObject.SetActive(true);
        weatherText.text = weatherInfo.name + "\n\n";
        weatherText.text += weatherInfo.main.temp.ToString("N1") + " ��C\n";

        if (weatherInfo.weather.Length > 0)
        {
            string iconCode = weatherInfo.weather[0].icon;
            string iconDescription = GetIconDescription(iconCode);
            explainText.gameObject.SetActive(true); // ���� �ؽ�Ʈ�� ���̰� �մϴ�
            explainText.text = "[Benefit ������ ����] " + iconDescription; // ������ �����մϴ�
            StartCoroutine(GetWeatherIcon(iconCode));
        }
    }

    IEnumerator GetWeatherIcon(string icon)
    {
        if (weatherInfo.main.temp <= 4)
        {
            SetTemperatureDescription("4-");
        }
        else if (weatherInfo.main.temp >= 5 && weatherInfo.main.temp < 9)
        {
            SetTemperatureDescription("5-9");
        }
        else if (weatherInfo.main.temp >= 9 && weatherInfo.main.temp < 12)
        {
            SetTemperatureDescription("9-12");
        }
        else if (weatherInfo.main.temp >= 12 && weatherInfo.main.temp < 17)
        {
            SetTemperatureDescription("12-17");
        }
        else if (weatherInfo.main.temp >= 17 && weatherInfo.main.temp < 20)
        {
            SetTemperatureDescription("17-20");
        }
        else if (weatherInfo.main.temp >= 20 && weatherInfo.main.temp < 23)
        {
            SetTemperatureDescription("20-23");
        }
        else if (weatherInfo.main.temp >= 23 && weatherInfo.main.temp < 28)
        {
            SetTemperatureDescription("23-28");
        }
        else if (weatherInfo.main.temp >= 28)
        {
            SetTemperatureDescription("28+");
        }
        else
        {
            SetTemperatureDescription("�� �� ����");
        }

        string url = "http://openweathermap.org/img/wn/" + icon + "@2x.png";
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        weatherIcon.gameObject.SetActive(true);
        weatherIcon.texture = DownloadHandlerTexture.GetContent(www);
    }

    // ������ �ڵ忡 �ش��ϴ� ������ ��ȯ
    string GetIconDescription(string iconCode)
    {
        if (iconDescriptions.ContainsKey(iconCode))
        {
            return iconDescriptions[iconCode];
        }
        else
        {
            return "�� �� ����";
        }
    }

    // �µ� ������ �����ϴ� �Լ�
    void SetTemperatureDescription(string temperatureRange)
    {
        if (temperatureDescriptions.ContainsKey(temperatureRange))
        {
            weatherClothes.text = temperatureDescriptions[temperatureRange]; // ������ ������ weatherClothes�� ǥ��
        }
        else
        {
            weatherClothes.text = "�� �� ����"; // ������ ������ weatherClothes�� ǥ��
        }
    }
}
