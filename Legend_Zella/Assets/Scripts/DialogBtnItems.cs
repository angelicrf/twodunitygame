using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class DialogBtnItems : MonoBehaviour
{
    public TextMeshProUGUI thisBtnOptions;
    void SetBtnOptions(string thisStr)
    {
        if (thisBtnOptions)
        {
            thisBtnOptions.text = thisStr;
        }
    }
}
