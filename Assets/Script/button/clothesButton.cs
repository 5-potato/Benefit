using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clothesButton : MonoBehaviour
{
    public GameObject scrollView;

    public void Start()
    {
        scrollView.SetActive(false);
    }

    public void clothesClicked()
    {
        scrollView.SetActive(!scrollView.activeSelf);
    }
}
