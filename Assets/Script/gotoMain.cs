using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoMain : MonoBehaviour
{
    // Start is called before the first frame update
    public void weathertoMain()
    {
        SceneManager.LoadScene("FirstMain");
    }
}
