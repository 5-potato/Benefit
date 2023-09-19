using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hansungButton : MonoBehaviour
{
    public GameObject scrollView;

    public void Start()
    {
        scrollView.SetActive(false);
    }

    public void weatherClicked()
    {
        scrollView.SetActive(!scrollView.activeSelf);
    }
}
