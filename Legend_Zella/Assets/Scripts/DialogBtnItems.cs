using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class DialogBtnItems : MonoBehaviour
{
    public TextMeshProUGUI thisBtnOptions;
    public int thisBtnInt;
    public void SetBtnOptions(string thisStr, int thisInt)
    {
        if (thisBtnOptions)
        {
            thisBtnOptions.text = thisStr;
            thisBtnInt = thisInt;
        }
    }
}
