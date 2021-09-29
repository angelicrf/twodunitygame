using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungObjectAnim : MonoBehaviour
{
    public Animator dungAnim;
    public bool isFDoorOpen = false;
     public Inventory dngInventory;
    public Rigidbody2D plRigid;
    //private bool isThree = false;
    public Signal changeDungStates;
    private DialogBoxMsg msgBoxAnim;
    private bool isPlayed = false;
    public static DungObjectAnim  isDoorDungClass;
   
   public static DungObjectAnim Instance(){ 
         if (!isDoorDungClass)
         {
             isDoorDungClass = FindObjectOfType(typeof(DungObjectAnim)) as DungObjectAnim;
         }
         return isDoorDungClass;
         }
  
    void Start()
    {
       dungAnim = GetComponent<Animator>(); 
       msgBoxAnim = DialogBoxMsg.Instance();
    }
   void OnTriggerEnter2D(Collider2D other){
       if(other.CompareTag("Player")){
           if(!isFDoorOpen){
               StartCoroutine(dungObjChange());
                 //add item
               dngInventory.isItem = true;
               dngInventory.getItems();
           }else if(isPlayed && isFDoorOpen){
               //display abox msg
               msgBoxAnim.appearBox();
           }
       }
   }
   public IEnumerator dungObjChange(){
           plRigid.GetComponent<PlayerMouvment>().currentPlState = PlayerMouvment.PlayerState.idle;
           dungAnim.SetBool("isDungObj", true);
           isFDoorOpen = true;         
           yield return new WaitForSeconds(4f);
           plRigid.GetComponent<PlayerMouvment>().currentPlState = PlayerMouvment.PlayerState.walk;
           isPlayed = true;
   }
   void OnTriggerExit2D(Collider2D other){
       if(other.CompareTag("Player")){
         StartCoroutine(dungObjStart());
         msgBoxAnim.disappearBox();
       // doorClose();
       }
   }
   public IEnumerator dungObjStart(){
      yield return null;
      dungAnim.SetBool("isDungObj", false);
   }
}
