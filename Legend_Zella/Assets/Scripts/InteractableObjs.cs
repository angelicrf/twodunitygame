using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjs : MonoBehaviour
{
    public Signal textMarkSignal;

    public bool isDialogActive;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other){

        if(other.name == "Player"){  
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
}
