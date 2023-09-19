using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using System;

public class Test : MonoBehaviour
{
    private IDbConnection dbConnection;


    public Button redclothes1;
    public Button redclothes2;
    public Button redclothes3;
    public Button redclothes4;
    public Button redclothes5;
    public Button redclothes6;
    public Button redclothes7;

    public Button pinkclothes1;
    public Button pinkclothes2;
    public Button pinkclothes3;
    public Button pinkclothes4;
    public Button pinkclothes5;
    public Button pinkclothes6;
    public Button pinkclothes7;

    public Button yellowclothes1;
    public Button yellowclothes2;
    public Button yellowclothes3;
    public Button yellowclothes4;
    public Button yellowclothes5;
    public Button yellowclothes6;
    public Button yellowclothes7;

    public Button greenclothes1;
    public Button greenclothes2;
    public Button greenclothes3;
    public Button greenclothes4;
    public Button greenclothes5;
    public Button greenclothes6;
    public Button greenclothes7;

    public Button blueclothes1;
    public Button blueclothes2;
    public Button blueclothes3;
    public Button blueclothes4;
    public Button blueclothes5;
    public Button blueclothes6;
    public Button blueclothes7;

    public Button whiteclothes1;
    public Button whiteclothes2;
    public Button whiteclothes3;
    public Button whiteclothes4;
    public Button whiteclothes5;
    public Button whiteclothes6;
    public Button whiteclothes7;

    public Button blackclothes1;
    public Button blackclothes2;
    public Button blackclothes3;
    public Button blackclothes4;
    public Button blackclothes5;
    public Button blackclothes6;
    public Button blackclothes7;

    public Button hansungclothes1;
    public Button hansungclothes2;
    public Button hansungclothes3;
    public Button hansungclothes4;
    public Button hansungclothes5;


    private void DatabaseUpdate(string query)
    {
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;
        dbCommand.ExecuteNonQuery();
        dbCommand.Dispose();
    }

    private void OnButtonClick(int clothesItemID)
    {
        string updateQuery = "UPDATE ClothesItems SET ViewCount = ViewCount + 1 WHERE ClothesItems = " + clothesItemID;
        DatabaseUpdate(updateQuery);
        Debug.Log(clothesItemID + "clothes ViewCount is UpdateOK");

    }

    public void InitializeDatabase()
    {
        string dbname = "/ClothesItems.db";
        string connectionString = "URI=file:" + Application.streamingAssetsPath + dbname;
        dbConnection = new SqliteConnection(connectionString);
        dbConnection.Open();
    }
    public void Start()
    {
        redclothes1.onClick.AddListener(() => OnButtonClick(1));
        redclothes2.onClick.AddListener(() => OnButtonClick(2));
        redclothes3.onClick.AddListener(() => OnButtonClick(3));
        redclothes4.onClick.AddListener(() => OnButtonClick(4));
        redclothes5.onClick.AddListener(() => OnButtonClick(5));
        redclothes6.onClick.AddListener(() => OnButtonClick(6));
        redclothes7.onClick.AddListener(() => OnButtonClick(7));


        pinkclothes1.onClick.AddListener(() => OnButtonClick(8));
        pinkclothes2.onClick.AddListener(() => OnButtonClick(9));
        pinkclothes3.onClick.AddListener(() => OnButtonClick(10));
        pinkclothes4.onClick.AddListener(() => OnButtonClick(11));
        pinkclothes5.onClick.AddListener(() => OnButtonClick(12));
        pinkclothes6.onClick.AddListener(() => OnButtonClick(13));
        pinkclothes7.onClick.AddListener(() => OnButtonClick(14));

        yellowclothes1.onClick.AddListener(() => OnButtonClick(15));
        yellowclothes2.onClick.AddListener(() => OnButtonClick(16));
        yellowclothes3.onClick.AddListener(() => OnButtonClick(17));
        yellowclothes4.onClick.AddListener(() => OnButtonClick(18));
        yellowclothes5.onClick.AddListener(() => OnButtonClick(19));
        yellowclothes6.onClick.AddListener(() => OnButtonClick(20));
        yellowclothes7.onClick.AddListener(() => OnButtonClick(21));

        greenclothes1.onClick.AddListener(() => OnButtonClick(22));
        greenclothes2.onClick.AddListener(() => OnButtonClick(23));
        greenclothes3.onClick.AddListener(() => OnButtonClick(24));
        greenclothes4.onClick.AddListener(() => OnButtonClick(25));
        greenclothes5.onClick.AddListener(() => OnButtonClick(26));
        greenclothes6.onClick.AddListener(() => OnButtonClick(27));
        greenclothes7.onClick.AddListener(() => OnButtonClick(28));


        blueclothes1.onClick.AddListener(() => OnButtonClick(29));
        blueclothes2.onClick.AddListener(() => OnButtonClick(30));
        blueclothes3.onClick.AddListener(() => OnButtonClick(31));
        blueclothes4.onClick.AddListener(() => OnButtonClick(32));
        blueclothes5.onClick.AddListener(() => OnButtonClick(33));
        blueclothes6.onClick.AddListener(() => OnButtonClick(34));
        blueclothes7.onClick.AddListener(() => OnButtonClick(35));

        whiteclothes1.onClick.AddListener(() => OnButtonClick(36));
        whiteclothes2.onClick.AddListener(() => OnButtonClick(37));
        whiteclothes3.onClick.AddListener(() => OnButtonClick(38));
        whiteclothes4.onClick.AddListener(() => OnButtonClick(39));
        whiteclothes5.onClick.AddListener(() => OnButtonClick(40));
        whiteclothes6.onClick.AddListener(() => OnButtonClick(41));
        whiteclothes7.onClick.AddListener(() => OnButtonClick(42));

        blackclothes1.onClick.AddListener(() => OnButtonClick(43));
        blackclothes2.onClick.AddListener(() => OnButtonClick(44));
        blackclothes3.onClick.AddListener(() => OnButtonClick(45));
        blackclothes4.onClick.AddListener(() => OnButtonClick(46));
        blackclothes5.onClick.AddListener(() => OnButtonClick(47));
        blackclothes6.onClick.AddListener(() => OnButtonClick(48));
        blackclothes7.onClick.AddListener(() => OnButtonClick(49));

        hansungclothes1.onClick.AddListener(() => OnButtonClick(50));
        hansungclothes2.onClick.AddListener(() => OnButtonClick(51));
        hansungclothes3.onClick.AddListener(() => OnButtonClick(52));
        hansungclothes4.onClick.AddListener(() => OnButtonClick(53));
        hansungclothes5.onClick.AddListener(() => OnButtonClick(54));







        InitializeDatabase();
    }

    

}
