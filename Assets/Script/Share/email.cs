using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class email : MonoBehaviour
{
    public InputField em;
    public string emString;

    public string path;
    private void Start()
    {
        path = path = Application.dataPath + "/ScreenShot/";
    }


    public void onClickButton()
    {
        emString = em.text.ToString();
        MailMessage message = new System.Net.Mail.MailMessage();
        message.From = new System.Net.Mail.MailAddress("zx9086@naver.com"); //������ ��� �̸��� �ֱ�
        message.To.Add(emString); //��ǲ�ʵ�� ���� �̸��� �ּ� ����
        message.Subject = "Benefit:�������� ����"; //�̸��� ����
        message.SubjectEncoding = System.Text.Encoding.UTF8;
        message.Body = "�������� ������ �����帳�ϴ�:)";//�̸��� ����
        message.BodyEncoding = System.Text.Encoding.UTF8;
        string[] screenshotFiles = Directory.GetFiles(path, "*.png");
        if (screenshotFiles.Length > 0)
        {
            string latestScreenshotPath = screenshotFiles[screenshotFiles.Length - 1];
            message.Attachments.Add(new Attachment(latestScreenshotPath));
        }

        try
        {
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.naver.com", 587);
            smtp.UseDefaultCredentials = false; // �ý��ۿ� ������ ���� ������ ������� �ʴ´�.
            smtp.EnableSsl = true;  // SSL�� ����Ѵ�.
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network; // �̰� ���� ������ naver �� ������ ���� ���Ѵ�.
            smtp.Credentials = new System.Net.NetworkCredential("zx9086@naver.com", "std90863**");//������ ��� ���̵�� ��й�ȣ
            smtp.Send(message);
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("�̸��� ���� ����");
        }
        SceneManager.LoadScene("recommendScene");
    }
}