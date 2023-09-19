using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clothesSleevelessYellowScript : MonoBehaviour
{
    public RawImage clothesTopRed;
    public RawImage clothesSleevelessRed;
    public RawImage clothesLongRed;
    public RawImage clothesTopPink;
    public RawImage clothesSleevelessPink;
    public RawImage clothesLongPink;
    public RawImage clothesTopYellow;
    public RawImage clothesSleevelessYellow;
    public RawImage clothesLongYellow;
    public RawImage clothesTopGreen;
    public RawImage clothesSleevelessGreen;
    public RawImage clothesLongGreen;
    public RawImage clothesTopBlue;
    public RawImage clothesSleevelessBlue;
    public RawImage clothesLongBlue;
    public RawImage clothesTopPurple;
    public RawImage clothesSleevelessPurple;
    public RawImage clothesLongPurple;
    public RawImage clothesTopBlack;
    public RawImage clothesSleevelessBlack;
    public RawImage clothesLongBlack;

    public RawImage clothesHansungTop;
    public RawImage clothesHansungTopBlack;
    public RawImage clothesHansungOut1;
    public RawImage clothesHansungOut2;

    public void Start()
    {
        clothesSleevelessYellow.gameObject.SetActive(false);
    }

    public void clothesSleevelessYellowClicked()
    {
        if (clothesTopRed != null)
        {
            clothesTopRed.gameObject.SetActive(false);
        }

        if (clothesSleevelessRed != null)
        {
            clothesSleevelessRed.gameObject.SetActive(false);
        }

        if (clothesLongRed != null)
        {
            clothesLongRed.gameObject.SetActive(false);
        }

        if (clothesTopPink != null)
        {
            clothesTopPink.gameObject.SetActive(false);
        }

        if (clothesSleevelessPink != null)
        {
            clothesSleevelessPink.gameObject.SetActive(false);
        }

        if (clothesLongPink != null)
        {
            clothesLongPink.gameObject.SetActive(false);
        }

        if (clothesTopYellow != null)
        {
            clothesTopYellow.gameObject.SetActive(false);
        }

        if (clothesLongYellow != null)
        {
            clothesLongYellow.gameObject.SetActive(false);
        }

        if (clothesTopGreen != null)
        {
            clothesTopGreen.gameObject.SetActive(false);
        }

        if (clothesSleevelessGreen != null)
        {
            clothesSleevelessGreen.gameObject.SetActive(false);
        }

        if (clothesLongGreen != null)
        {
            clothesLongGreen.gameObject.SetActive(false);
        }

        if (clothesTopBlue != null)
        {
            clothesTopBlue.gameObject.SetActive(false);
        }

        if (clothesSleevelessBlue != null)
        {
            clothesSleevelessBlue.gameObject.SetActive(false);
        }

        if (clothesLongBlue != null)
        {
            clothesLongBlue.gameObject.SetActive(false);
        }

        //보라
        if (clothesTopPurple != null)
        {
            clothesTopPurple.gameObject.SetActive(false);
        }

        if (clothesSleevelessPurple != null)
        {
            clothesSleevelessPurple.gameObject.SetActive(false);
        }

        if (clothesLongPurple != null)
        {
            clothesLongPurple.gameObject.SetActive(false);
        }

        //검정
        if (clothesTopBlack != null)
        {
            clothesTopBlack.gameObject.SetActive(false);
        }

        if (clothesSleevelessBlack != null)
        {
            clothesSleevelessBlack.gameObject.SetActive(false);
        }

        if (clothesLongBlack != null)
        {
            clothesLongBlack.gameObject.SetActive(false);
        }

        //한성
        if (clothesHansungOut1 != null)
        {
            clothesHansungOut1.gameObject.SetActive(false);
        }

        if (clothesHansungOut2 != null)
        {
            clothesHansungOut2.gameObject.SetActive(false);
        }
        if (clothesHansungTop != null)
        {
            clothesHansungTop.gameObject.SetActive(false);
        }

        if (clothesHansungTopBlack != null)
        {
            clothesHansungTopBlack.gameObject.SetActive(false);
        }

        clothesSleevelessYellow.gameObject.SetActive(!clothesSleevelessYellow.gameObject.activeSelf);
    }
}

