using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class loadScreen : MonoBehaviour
{
    public string path;
    public RawImage screen;
    private int resWidth;
    private int resHeight;

    void Start()
    {
        resWidth = Screen.width;
        resHeight = Screen.height;
        path = Application.dataPath + "/ScreenShot/";
        screen = GetComponent<RawImage>();
        Debug.Log(path);
        ShowCapturedImage();
    }
    // 최근에 촬영한 사진을 screen에 표시하는 메소드
    public void ShowCapturedImage()
    {
        string[] screenshotFiles = Directory.GetFiles(path, "*.png");
        if (screenshotFiles.Length > 0)
        {
            string latestScreenshotPath = screenshotFiles[screenshotFiles.Length - 1];
            byte[] imageData = File.ReadAllBytes(latestScreenshotPath);
            Texture texture = new Texture2D(2, 2);
            ((Texture2D)texture).LoadImage(imageData);
            screen.texture = texture;
        }
    }
}