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

    // 날씨 아이콘 코드와 설명을 매핑하는 딕셔너리
    private Dictionary<string, string> iconDescriptions = new Dictionary<string, string>();
    // 온도 범위와 해당하는 설명을 매핑하는 딕셔너리
    private Dictionary<string, string> temperatureDescriptions = new Dictionary<string, string>();

    void Start()
    {
        // 아이콘 설명을 매핑
        iconDescriptions.Add("01d", "맑음");
        iconDescriptions.Add("01n", "맑음");
        iconDescriptions.Add("02d", "구름 조금");
        iconDescriptions.Add("02n", "구름 조금");
        iconDescriptions.Add("03d", "흐림");
        iconDescriptions.Add("03n", "흐림");
        iconDescriptions.Add("04d", "많은 구름");
        iconDescriptions.Add("04n", "많은 구름");
        iconDescriptions.Add("09d", "비");
        iconDescriptions.Add("09n", "비");
        iconDescriptions.Add("10d", "소나기");
        iconDescriptions.Add("10n", "소나기");
        iconDescriptions.Add("11d", "천둥 번개");
        iconDescriptions.Add("11n", "천둥 번개");
        iconDescriptions.Add("13d", "눈");
        iconDescriptions.Add("13n", "눈");
        iconDescriptions.Add("50d", "안개");
        iconDescriptions.Add("50n", "안개");

        temperatureDescriptions.Add("4-", "도로가 얼 정도로 매우 바람이 많이 부니, 겨울 옷을 입으세요.\n 패딩, 두꺼운 코트, 누빔 옷, 기모 옷, 목도리 등을 추천해요:)");
        temperatureDescriptions.Add("5-9", "겨울 날씨이므로 옷을 따뜻하게 입으세요.\n 울 코트, 히트텍, 가죽 옷, 기모 옷 등을 추천해요:)");
        temperatureDescriptions.Add("9-12", "초겨울 날씨이므로 감기 걸리지 않게 따뜻하게 입어야 해요.\n 트렌치 코트, 야상 점퍼, 기모바지 등을 추천해요:)");
        temperatureDescriptions.Add("12-17", "가을 날씨이므로 일교차가 커요.\n 자켓, 가디건, 청자켓, 니트, 청바지 등을 추천해요:)");
        temperatureDescriptions.Add("17-20", "초가을 날씨이므로 따뜻하긴 하지만, 쌀쌀할 수 있어요.\n 얇은 가디건이나 니트, 맨투맨, 후드, 긴 바지 등을 추천해요:)");
        temperatureDescriptions.Add("20-23", "따뜻한 봄 날씨이므로 춥진 않을 거예요.\n 블라우스, 긴팔 티, 면바지, 슬랙스 등을 추천해요:)");
        temperatureDescriptions.Add("23-28", "초여름 날씨이므로 더울 수도 있어요.\n 반팔, 얇은 셔츠, 반바지, 면바지 등을 추천해요:)");
        temperatureDescriptions.Add("28+", "더운 여름 날씨이므로 가볍게 입으세요.\n 민소매, 반팔, 반바지, 짧은 치마 등을 추천해요:)");


        CheckCityWeather("Seongbuk-gu");
    }

    public void CheckCityWeather(string city)
    {
        weatherText.gameObject.SetActive(false);
        weatherIcon.gameObject.SetActive(false);
        explainText.gameObject.SetActive(false); // 설명 텍스트를 숨깁니다
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
        weatherText.text += weatherInfo.main.temp.ToString("N1") + " °C\n";

        if (weatherInfo.weather.Length > 0)
        {
            string iconCode = weatherInfo.weather[0].icon;
            string iconDescription = GetIconDescription(iconCode);
            explainText.gameObject.SetActive(true); // 설명 텍스트를 보이게 합니다
            explainText.text = "[Benefit 오늘의 날씨] " + iconDescription; // 설명을 설정합니다
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
            SetTemperatureDescription("알 수 없음");
        }

        string url = "http://openweathermap.org/img/wn/" + icon + "@2x.png";
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        weatherIcon.gameObject.SetActive(true);
        weatherIcon.texture = DownloadHandlerTexture.GetContent(www);
    }

    // 아이콘 코드에 해당하는 설명을 반환
    string GetIconDescription(string iconCode)
    {
        if (iconDescriptions.ContainsKey(iconCode))
        {
            return iconDescriptions[iconCode];
        }
        else
        {
            return "알 수 없음";
        }
    }

    // 온도 설명을 설정하는 함수
    void SetTemperatureDescription(string temperatureRange)
    {
        if (temperatureDescriptions.ContainsKey(temperatureRange))
        {
            weatherClothes.text = temperatureDescriptions[temperatureRange]; // 옷차림 설명을 weatherClothes에 표시
        }
        else
        {
            weatherClothes.text = "알 수 없음"; // 옷차림 설명을 weatherClothes에 표시
        }
    }
}
