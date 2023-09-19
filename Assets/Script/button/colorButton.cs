using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorButton : MonoBehaviour
{
    public GameObject scrollView;

    public void Start()
    {
        scrollView.SetActive(false);
    }

    public void colorClicked()
    {
        scrollView.SetActive(!scrollView.activeSelf);
    }
}
