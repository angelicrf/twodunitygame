using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : InteractableObjs
{
    public GameObject dialogBox;
    public Text dialogText;
    public string textDisplay;
    public void Update()
    {
        if (Input.GetButtonDown("attack"))
        {

            if (dialogBox.activeInHierarchy)
            {
                DeactiveTextFunc();
            }
        }
        else
        {
            ActiveTextFunc();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player" && !other.isTrigger)
        {
            textMarkSignal.ReadSignals();
        }
    }
    private void ActiveTextFunc()
    {
        isDialogActive = true;
        dialogBox.SetActive(true);
        textDisplay = "You Hit the Sign....";
        dialogText.text = textDisplay;
    }
    private void DeactiveTextFunc()
    {
        isDialogActive = false;
        dialogBox.SetActive(false);
    }
}
