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
    private List<GameObject> allPrizes = new List<GameObject>();
    private List<string> allFoundNames = new List<string>();
    public Signal arrowSignal;
    
    void Start()
    {
        interObj = GameObject.Find("Player").transform.GetChild(5).gameObject;
        animator = GetComponent<Animator>(); 
        //gmInventory.itemCount = 0;      
        gmInventory.isItem = false;
        addAllItemsList();
       
        allFoundNames.Add("ItemKey"); 
        allFoundNames.Add("Bow");
       
        //gmItem.isOpen = false;
    }
     private void OnTriggerEnter2D(Collider2D other){

        if(other.name == "Player" && ! gmItem.initialIsOpen && ! other.isTrigger){  
           
           otherPlRigid  = other.GetComponent<Rigidbody2D>();
            if(Input.GetKey(KeyCode.UpArrow)){
                        animator.SetTrigger("TrBox");
                        animator.SetBool("isActive", true);
                        gmItem.isOpen = true;
                    for (int i = 0; i < allFoundNames.Count; i++)
                    {
                        if(gmItem.items.CompareTag(allFoundNames[i])){
                            if(gmItem.items.CompareTag("Bow")){
                                if(arrowSignal != null){
                                    arrowSignal.hasSignal = true;
                                    arrowSignal.ReadSignals();
                                }
                            }
                            otherPlRigid.GetComponent<PlayerMouvment>().currentPlState = PlayerMouvment.PlayerState.interact;             
                            //call func
                            interObj = allPrizes[i];
                            //allPrizes[1];
                            interObj.SetActive(true);           
                            gmInventory.isItem = true;
                            gmInventory.getItems();
                         }
                       }                                           
                     }
                }
               //interObj.textMarkSignal.ReadSignals();     
    }
    private void addAllItemsList(){
      GameObject gmOne = GameObject.Find("Player").transform.GetChild(5).gameObject;
      GameObject gmTwo = GameObject.Find("Player").transform.GetChild(6).gameObject;
      allPrizes.Add(gmOne);
      allPrizes.Add(gmTwo);    
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
