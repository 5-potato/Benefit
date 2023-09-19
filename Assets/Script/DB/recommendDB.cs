using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using System;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class recommendDB : MonoBehaviour
{

    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;

    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;

    public string link1 = string.Empty;
    public string link2 = string.Empty;
    public string link3 = string.Empty;
    public string link4 = string.Empty;
    public Sprite[] imgSprites;

    private IDbConnection dbConnection;

    private void Start()
    {
        InitializeDatabase();
        DisplayTop5Items();
    }

    public void InitializeDatabase()
    {
        string dbname = "/ClothesItems.db";
        string connectionString = "URI=file:" + Application.streamingAssetsPath + dbname;
        dbConnection = new SqliteConnection(connectionString);
        dbConnection.Open();
    }

    //recommendScene 에서 호출하기
    public void DisplayTop5Items()
    {
        string query = "SELECT * FROM ClothesItems ORDER BY ViewCount DESC LIMIT 4"; //내림차순 & 상위 4개 추출 쿼리
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;
        IDataReader dataReader = dbCommand.ExecuteReader();
        int count = 1;

        while (dataReader.Read())
        {
            int clothesID = dataReader.GetInt32(dataReader.GetOrdinal("ClothesItems"));
            string name = dataReader.GetString(dataReader.GetOrdinal("Name"));
            string link = dataReader.GetString(dataReader.GetOrdinal("Link"));
            //string filepath = dataReader.GetString(dataReader.GetOrdinal("ModelFilePath"));
            int viewCount = dataReader.GetInt32(dataReader.GetOrdinal("ViewCount"));

            string itemInfo = string.Empty;

            if (count == 1 && viewCount!=0)
            {
                itemInfo = "1. "  + name + " ViewCount: " + viewCount;
                link1 = link;
                text1.text = itemInfo;
                GameObject.Find("Button1").GetComponent<Image>().sprite = imgSprites[clothesID - 1];
            }
            else if (count == 2 && viewCount != 0)
            {
                itemInfo = "2. " + name + " ViewCount: " + viewCount;
                link2 = link;
                text2.text = itemInfo;
                GameObject.Find("Button2").GetComponent<Image>().sprite = imgSprites[clothesID - 1];
            }
            else if (count == 3 && viewCount != 0)
            {
                itemInfo = "3. "  + name + " ViewCount: " + viewCount;
                link3 = link;
                text3.text = itemInfo;
                GameObject.Find("Button3").GetComponent<Image>().sprite = imgSprites[clothesID - 1];
            }
            else if (count == 4&& viewCount != 0)
            {
                itemInfo = "4. "  + name + " ViewCount: " + viewCount;
                link4 = link;
                text4.text = itemInfo;
                GameObject.Find("Button4").GetComponent<Image>().sprite = imgSprites[clothesID - 1];
            }
            count++;
        }
        dataReader.Close();

        btn1.onClick.AddListener(() => OpenLink1());
        btn2.onClick.AddListener(() => OpenLink2());
        btn3.onClick.AddListener(() => OpenLink3());
        btn4.onClick.AddListener(() => OpenLink4());
    }
    public void OpenLink1()
    {
        Application.OpenURL(link1);
    }
    public void OpenLink2()
    {
        Application.OpenURL(link2);
    }
    public void OpenLink3()
    {
        Application.OpenURL(link3);
    }
    public void OpenLink4()
    {
        Application.OpenURL(link4);
    }
    //메인으로 이동 & DB 초기화
    public void gotoMain()
    {
        ResetViewCount();

        SceneManager.LoadScene("FirstMain");

    }
    private void ResetViewCount()
    {
        string query = "UPDATE ClothesItems SET ViewCount = 0";
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;
        dbCommand.ExecuteNonQuery();
        dbCommand.Dispose();

    }

}