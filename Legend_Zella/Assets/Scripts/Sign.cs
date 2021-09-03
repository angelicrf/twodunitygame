using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : InteractableObjs
{
    public GameObject dialogBox;
    public Text dialogText;
    public string textDisplay; 
   
    private void OnTriggerExit2D(Collider2D other){
        if(other.name == "Player"){ 
            textMarkSignal.ReadSignals();
            // need to create a  new dialog box 
           /*  isDialogActive = false;
            dialogBox.SetActive(false); */
        }
    }
    private void TextFunc(){
         isDialogActive = true;
         dialogBox.SetActive(true);
         textDisplay = "You Hit the Sign....";
         dialogText.text = textDisplay;
    }
}
