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
        message.From = new System.Net.Mail.MailAddress("zx9086@naver.com"); //보내는 사람 이메일 넣기
        message.To.Add(emString); //인풋필드로 받을 이메일 주소 넣음
        message.Subject = "Benefit:가상피팅 서비스"; //이메일 제목
        message.SubjectEncoding = System.Text.Encoding.UTF8;
        message.Body = "가상피팅 사진을 보내드립니다:)";//이메일 내용
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
            smtp.UseDefaultCredentials = false; // 시스템에 설정된 인증 정보를 사용하지 않는다.
            smtp.EnableSsl = true;  // SSL을 사용한다.
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network; // 이걸 하지 않으면 naver 에 인증을 받지 못한다.
            smtp.Credentials = new System.Net.NetworkCredential("zx9086@naver.com", "std90863**");//보내는 사람 아이디와 비밀번호
            smtp.Send(message);
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("이메일 전송 실패");
        }
        SceneManager.LoadScene("recommendScene");
    }
}