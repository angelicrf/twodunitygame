using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string textDisplay; 
    public bool isDialogActive;
    public Signal textMarkSignal;
    
    private void OnTriggerEnter2D(Collider2D other){

        if(other.name == "Player"){  
            //textMarkSignal.TestSignal();
            textMarkSignal.ReadSignals();
            //TextFunc();
        }    
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.name == "Player"){ 
            textMarkSignal.ReadSignals();
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
