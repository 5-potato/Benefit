using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public RawImage display;    // RawImage에 카메라 영상 표시
    public WebCamTexture camTexture;   // 카메라 입력을 받기 위한 WebCamTexture 객체

    public void Start()    //시작 함수
    {
        // 사용 가능한 모든 카메라 디바이스 가져오기
        WebCamDevice[] devices = WebCamTexture.devices;

        // 첫 번째 카메라 디바이스 가져오기
        WebCamDevice device = devices[0];

        // 디바이스 이름을 사용하여 새로운 WebCamTexture를 생성
        camTexture = new WebCamTexture(device.name, 1280, 720);

        //
        display = GameObject.Find("BackImage").GetComponent<RawImage>();

        // 디바이스를 띄울 화면을 못 찾는 에러 발생했었음 -> RawImage에 띄울 것임을 지정
        //display = FindObjectOfType<RawImage>();

        // display의 텍스처를 camTexture로 설정
        display.texture = camTexture;

        // 거울 모드로 설정
        display.uvRect = new Rect(1, 0, -1, 1);

        // 카메라 영상을 받아오기 시작
        camTexture.Play();

        // 카메라 오른쪽으로 90도 회전
        display.transform.rotation = Quaternion.Euler(0, 0, 90);
    }
}