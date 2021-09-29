using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : InteractableObjs
{
    public GameObject dialogBox;
    public Text dialogText;
    public string textDisplay; 
    public void Update(){
        if(Input.GetButtonDown("attack")){
            if(dialogBox.activeInHierarchy){
              deactiveTextFunc();
            }
        }else{
              activeTextFunc();             
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.name == "Player" && !other.isTrigger){ 
            textMarkSignal.ReadSignals();
        }
    }
    private void activeTextFunc(){
         isDialogActive = true;
         dialogBox.SetActive(true);
         textDisplay = "You Hit the Sign....";
         dialogText.text = textDisplay;
    }
    private void deactiveTextFunc(){
       isDialogActive = false;
       dialogBox.SetActive(false); 
    }
}
