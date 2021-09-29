using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBox : MonoBehaviour
{

    public Inventory gmInventory;
    public TresureItem gmItem;
    private GameObject interObj;
    private Animator animator;
    private Rigidbody2D otherPlRigid;

    
    void Start()
    {
        interObj = GameObject.Find("Player").transform.GetChild(5).gameObject;
        animator = GetComponent<Animator>(); 
        //gmInventory.itemCount = 0;      
        gmInventory.isItem = false;
        //gmItem.isOpen = false;
    }

    void Update()
    {
  
    }
     private void OnTriggerEnter2D(Collider2D other){

        if(other.name == "Player" && ! gmItem.initialIsOpen && ! other.isTrigger){  
           otherPlRigid  = other.GetComponent<Rigidbody2D>();
       
            if(Input.GetButtonDown("attack")){
               //interObj.textMarkSignal.ReadSignals();
               animator.SetTrigger("TrBox");
               animator.SetBool("isActive", true);
               gmItem.isOpen = true;
              
               if(gmItem.items.CompareTag("KeyItem")){
                   otherPlRigid.GetComponent<PlayerMouvment>().currentPlState = PlayerMouvment.PlayerState.interact;             
                   interObj.SetActive(true);              
                   gmInventory.isItem = true;
                   gmInventory.getItems();
               }
             }
        }    
    }
    private void OnTriggerExit2D(Collider2D other){

        if(other.name == "Player" && !other.isTrigger){
            otherPlRigid.GetComponent<PlayerMouvment>().currentPlState = PlayerMouvment.PlayerState.idle; 
               interObj.SetActive(false);
               animator.SetBool("isActive", false);     
            //interObj.textMarkSignal.ReadSignals();
                gmItem.items.SetActive(false);
                gmInventory.isItem = false;
        }
    }

}
