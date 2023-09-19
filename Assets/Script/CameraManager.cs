using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public RawImage display;    // RawImage�� ī�޶� ���� ǥ��
    public WebCamTexture camTexture;   // ī�޶� �Է��� �ޱ� ���� WebCamTexture ��ü

    public void Start()    //���� �Լ�
    {
        // ��� ������ ��� ī�޶� ����̽� ��������
        WebCamDevice[] devices = WebCamTexture.devices;

        // ù ��° ī�޶� ����̽� ��������
        WebCamDevice device = devices[0];

        // ����̽� �̸��� ����Ͽ� ���ο� WebCamTexture�� ����
        camTexture = new WebCamTexture(device.name, 1280, 720);

        //
        display = GameObject.Find("BackImage").GetComponent<RawImage>();

        // ����̽��� ��� ȭ���� �� ã�� ���� �߻��߾��� -> RawImage�� ��� ������ ����
        //display = FindObjectOfType<RawImage>();

        // display�� �ؽ�ó�� camTexture�� ����
        display.texture = camTexture;

        // �ſ� ���� ����
        display.uvRect = new Rect(1, 0, -1, 1);

        // ī�޶� ������ �޾ƿ��� ����
        camTexture.Play();

        // ī�޶� ���������� 90�� ȸ��
        display.transform.rotation = Quaternion.Euler(0, 0, 90);
    }
}