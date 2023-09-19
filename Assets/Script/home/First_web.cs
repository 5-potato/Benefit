using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class First_web : MonoBehaviour
{
    public void Change()
    {
        SceneManager.LoadScene("WebCam");
    }
    public void nextWeather()
    {
        SceneManager.LoadScene("weather");
    }
}
