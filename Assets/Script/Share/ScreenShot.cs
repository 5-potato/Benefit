using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class ScreenShot : MonoBehaviour
{
    public CameraManager cameraManager;
    public Camera camera;       //보여지는 카메라.

    private int resWidth;
    private int resHeight;
    string path;
    // Use this for initialization
    void Start()
    {
        resWidth = Screen.width;
        resHeight = Screen.height;
        path = Application.dataPath + "/ScreenShot/";
        Debug.Log(path);
    }

    public void ClickScreenShot()
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        if (!dir.Exists)
        {
            Directory.CreateDirectory(path);
        }
        string name;
        name = path + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        camera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
        camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        screenShot.Apply();

        byte[] bytes = screenShot.EncodeToPNG();
        File.WriteAllBytes(name, bytes);

        changeScene();

    }
    //사진 촬영 후, 보여주는 화면으로 전환하는 메소드
    public void changeScene()
    {
        SceneManager.LoadScene("picScene");
        offCamenra();

    }
    //화면 전환 시, 카메라 끄기 기능 필요 
    public void offCamenra()
    {
        cameraManager = FindObjectOfType<CameraManager>();
        if (cameraManager != null)
        {
            WebCamTexture camTexture = cameraManager.camTexture;
            camTexture.Stop();
        }
        else
        {
            Debug.Log("camera is not found");
        }
    }

    public void goHome()
    {
        SceneManager.LoadScene("FirstMain");
        offCamenra();

    }

}