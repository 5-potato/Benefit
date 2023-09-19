using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Share : MonoBehaviour
{
    public void changeNext()
    {
        SceneManager.LoadScene("shareScene");
    }
    public void changeMain()
    {
        SceneManager.LoadScene("recommendScene");
    }
}