using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTextClue : MonoBehaviour
{
    public GameObject textToAsk;
    public bool isAskedText = false;

    public void ChangeAskText()
    {
        isAskedText = !isAskedText;

        if (isAskedText)
        {
            textToAsk.SetActive(true);
        }
        else
        {
            textToAsk.SetActive(false);
        }
    }
}
