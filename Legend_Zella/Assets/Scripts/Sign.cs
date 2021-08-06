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
  

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("IsEnteredClodider..." + other.name);
        // if Player
        if(other.name == "Player"){
            TextFunc();
        }
     
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.name == "Player"){
            isDialogActive = false;
            dialogBox.SetActive(false);
        }
    }
    private void TextFunc(){
         isDialogActive = true;
         dialogBox.SetActive(true);
         textDisplay = "You Hit the Sign....";
         dialogText.text = textDisplay;
    }
}
