using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungObjectAnim : MonoBehaviour
{
    public Animator dungAnim;
    public bool isFDoorOpen = false;
    public Rigidbody2D plRigid;
    //private bool isThree = false;
    public Signal changeDungStates;
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
    }
   void OnTriggerEnter2D(Collider2D other){
       if(other.CompareTag("Player") && !isFDoorOpen){
          StartCoroutine(dungObjChange());
       }
   }
   public IEnumerator dungObjChange(){
           plRigid.GetComponent<PlayerMouvment>().currentPlState = PlayerMouvment.PlayerState.idle;
           dungAnim.SetBool("isDungObj", true);
           isFDoorOpen = true;         
           yield return new WaitForSeconds(4f);
           plRigid.GetComponent<PlayerMouvment>().currentPlState = PlayerMouvment.PlayerState.walk;
   }
   void OnTriggerExit2D(Collider2D other){
       if(other.CompareTag("Player")){
        StartCoroutine(dungObjStart());
       // doorClose();
       }
   }
   public IEnumerator dungObjStart(){
      yield return null;
      dungAnim.SetBool("isDungObj", false);
   }
}
