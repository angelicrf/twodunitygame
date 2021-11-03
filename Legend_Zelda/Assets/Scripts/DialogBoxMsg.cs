using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[CreateAssetMenu]
public class DialogBoxMsg : MonoBehaviour
{
    private static DialogBoxMsg isClass;
    public static DialogBoxMsg Instance()
    {
        if (!isClass)
        {
            isClass = FindObjectOfType(typeof(DialogBoxMsg)) as DialogBoxMsg;
        }
        return isClass;
    }
    public GameObject dspDialogBox;

    public Text dspText;
    public string dspMsg;

    public void AppearBox()
    {
        dspDialogBox.SetActive(true);
        dspText.text = dspMsg;
        dspText.color = Color.red;
    }
    public void DisappearBox()
    {
        dspDialogBox.SetActive(false);
        dspText.text = null;
    }

}
