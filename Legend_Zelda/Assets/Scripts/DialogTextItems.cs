using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class DialogTextItems : MonoBehaviour
{
    public TextMeshProUGUI thisDialogText;
    public int thisTextInt;
    public void SetDialogText(string thisStr, int thisInt)
    {

        thisDialogText.text = thisStr;
        thisDialogText.color = Color.black;
        thisDialogText.maskable = false;
        thisTextInt = thisInt;

    }
}
