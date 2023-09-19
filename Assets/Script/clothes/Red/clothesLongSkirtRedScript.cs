using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clothesLongSkirtRedScript : MonoBehaviour
{
    public RawImage clothesLongRed;
    public RawImage clothesLongSkirtRed;
    public RawImage clothesSkirtRed;
    public RawImage clothesLongPantsRed;
    public RawImage clothesPantsRed;
    public RawImage clothesLongPink;
    public RawImage clothesLongSkirtPink;
    public RawImage clothesSkirtPink;
    public RawImage clothesLongPantsPink;
    public RawImage clothesPantsPink;
    public RawImage clothesLongYellow;
    public RawImage clothesLongSkirtYellow;
    public RawImage clothesSkirtYellow;
    public RawImage clothesLongPantsYellow;
    public RawImage clothesPantsYellow;
    public RawImage clothesLongGreen;
    public RawImage clothesLongSkirtGreen;
    public RawImage clothesSkirtGreen;
    public RawImage clothesLongPantsGreen;
    public RawImage clothesPantsGreen;
    public RawImage clothesLongBlue;
    public RawImage clothesLongSkirtBlue;
    public RawImage clothesSkirtBlue;
    public RawImage clothesLongPantsBlue;
    public RawImage clothesPantsBlue;
    public RawImage clothesLongPurple;
    public RawImage clothesLongSkirtPurple;
    public RawImage clothesSkirtPurple;
    public RawImage clothesLongPantsPurple;
    public RawImage clothesPantsPurple;
    public RawImage clothesLongBlack;
    public RawImage clothesLongSkirtBlack;
    public RawImage clothesSkirtBlack;
    public RawImage clothesLongPantsBlack;
    public RawImage clothesPantsBlack;


    public RawImage clothesHansungOut2;
    public RawImage clothesHansungPants;


    public void Start()
    {
        clothesLongSkirtRed.gameObject.SetActive(false);
    }

    public void clothesLongSkirtRedClicked()
    {
        if (clothesLongRed != null)
        {
            clothesLongRed.gameObject.SetActive(false);
        }

        if (clothesSkirtRed != null)
        {
            clothesSkirtRed.gameObject.SetActive(false);
        }

        if (clothesLongPantsRed != null)
        {
            clothesLongPantsRed.gameObject.SetActive(false);
        }

        if (clothesPantsRed != null)
        {
            clothesPantsRed.gameObject.SetActive(false);
        }

        if (clothesLongPink != null)
        {
            clothesLongRed.gameObject.SetActive(false);
        }

        if (clothesLongSkirtPink != null)
        {
            clothesLongSkirtPink.gameObject.SetActive(false);
        }

        if (clothesSkirtPink != null)
        {
            clothesSkirtPink.gameObject.SetActive(false);
        }

        if (clothesLongPantsPink != null)
        {
            clothesLongPantsPink.gameObject.SetActive(false);
        }

        if (clothesPantsPink != null)
        {
            clothesPantsPink.gameObject.SetActive(false);
        }

        if (clothesLongYellow != null)
        {
            clothesLongYellow.gameObject.SetActive(false);
        }

        if (clothesLongSkirtYellow != null)
        {
            clothesLongSkirtYellow.gameObject.SetActive(false);
        }

        if (clothesSkirtYellow != null)
        {
            clothesSkirtYellow.gameObject.SetActive(false);
        }

        if (clothesLongPantsYellow != null)
        {
            clothesLongPantsYellow.gameObject.SetActive(false);
        }

        if (clothesPantsYellow != null)
        {
            clothesPantsYellow.gameObject.SetActive(false);
        }

        if (clothesLongGreen != null)
        {
            clothesLongGreen.gameObject.SetActive(false);
        }

        if (clothesLongSkirtGreen != null)
        {
            clothesLongSkirtGreen.gameObject.SetActive(false);
        }

        if (clothesSkirtGreen != null)
        {
            clothesSkirtGreen.gameObject.SetActive(false);
        }

        if (clothesLongPantsGreen != null)
        {
            clothesLongPantsGreen.gameObject.SetActive(false);
        }

        if (clothesPantsGreen != null)
        {
            clothesPantsGreen.gameObject.SetActive(false);
        }

        //보라
        if (clothesLongPurple != null)
        {
            clothesLongPurple.gameObject.SetActive(false);
        }

        if (clothesLongSkirtPurple != null)
        {
            clothesLongSkirtPurple.gameObject.SetActive(false);
        }

        if (clothesSkirtPurple != null)
        {
            clothesSkirtPurple.gameObject.SetActive(false);
        }

        if (clothesLongPantsPurple != null)
        {
            clothesLongPantsPurple.gameObject.SetActive(false);
        }

        if (clothesPantsPurple != null)
        {
            clothesPantsPurple.gameObject.SetActive(false);
        }

        //검정
        if (clothesLongBlack != null)
        {
            clothesLongBlack.gameObject.SetActive(false);
        }

        if (clothesLongSkirtBlack != null)
        {
            clothesLongSkirtBlack.gameObject.SetActive(false);
        }

        if (clothesSkirtBlack != null)
        {
            clothesSkirtBlack.gameObject.SetActive(false);
        }

        if (clothesLongPantsBlack != null)
        {
            clothesLongPantsBlack.gameObject.SetActive(false);
        }

        if (clothesPantsBlack != null)
        {
            clothesPantsBlack.gameObject.SetActive(false);
        }
        //한성
        if (clothesHansungPants != null)
        {
            clothesHansungPants.gameObject.SetActive(false);
        }

        if (clothesHansungOut2 != null)
        {
            clothesHansungOut2.gameObject.SetActive(false);
        }

        clothesLongSkirtRed.gameObject.SetActive(!clothesLongSkirtRed.gameObject.activeSelf);
    }
}
