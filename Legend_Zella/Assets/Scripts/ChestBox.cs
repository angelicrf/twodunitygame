using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBox : MonoBehaviour
{
    public Inventory gmInventory;
    public TresureItem gmItem;
    private GameObject interObj;
    private Animator animator;
    private bool isCollision;
    private Rigidbody2D otherPlRigid;
    
    void Start()
    {
        isCollision = false;
        interObj = GameObject.Find("Player").transform.GetChild(5).gameObject;
        animator = GetComponent<Animator>(); 
        gmInventory.itemCount = 0; 
     
     gmInventory.isItem = false;
     gmItem.isOpen = false;
    }

    void Update()
    {
  
    }
     private void OnTriggerEnter2D(Collider2D other){

        if(other.name == "Player"){  

           isCollision = true;
           otherPlRigid  = other.GetComponent<Rigidbody2D>();
        }    
    }
  /*   private void OnTriggerExit2D(Collider2D other){

        if(other.name == "Player"){
        }
    } */
      private void OnCollisionEnter2D(Collision2D other){
           if(isCollision && Input.anyKey){
               if(Input.GetKey("right") || Input.GetKey("left") || Input.GetKey("up") || Input.GetKey("down")){
               //interObj.textMarkSignal.ReadSignals();
               animator.SetTrigger("TrBox");
               animator.SetBool("isActive", true);
               gmItem.isOpen = true;
              
               if(gmItem.items.CompareTag("KeyItem")){
                   otherPlRigid.GetComponent<PlayerMouvment>().currentPlState = PlayerMouvment.PlayerState.interact;             
                   interObj.SetActive(true);              
                   gmInventory.isItem = true;
                   gmInventory.getItems();
                   isCollision = false;
               }
             }
           }
        }
        private void OnCollisionExit2D(Collision2D other){
            if(!isCollision){
               otherPlRigid.GetComponent<PlayerMouvment>().currentPlState = PlayerMouvment.PlayerState.idle; 
               interObj.SetActive(false);
               animator.SetBool("isActive", false);     
            //interObj.textMarkSignal.ReadSignals();
                // change player status to walk
                gmItem.items.SetActive(false);
                gmInventory.isItem = false;
                gmItem.isOpen = false;
            }
        }

}
