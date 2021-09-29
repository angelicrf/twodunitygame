using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungDoor : InteractableObjs
{
    public enum DungRoomName{ roomOne, roomTwo, roomThree,roomFour,NoRoom}
    public enum DungDoorName{dungDoorOne, dungDoorTwo, dungDoorThree, dungDoorFour,NoDoor}
    public DungDoorName dngDoorType;
    public DungRoomName selectDungRoom;
    public GameObject dngDoor;
    public Collider2D dnDoorCld;
    public Signal doorOneSignal;
    public Signal doorTwoSignal;
    public Signal doorThreeSignal;
    public Signal doorFourSignal;
    public bool setHasSignal;
    public bool setDoorSignal;
    public bool setDoorFour; 
    public bool testIsOpen;
    public bool setDoorThree;
    private DungRoomThree dngRoomThree;
    public static DungDoor isDungDoorClass;
   

   public static DungDoor Instance(){ 
         if (!isDungDoorClass)
         {
             isDungDoorClass = FindObjectOfType(typeof(DungDoor)) as DungDoor;
         }
         return isDungDoorClass;
         }
    void LateUpdate()
    {
     dngRoomThree = DungRoomThree.Instance();
     if(doorThreeSignal != null){      
       setDoorThree = doorThreeSignal.hasSignal;
     }
      if(doorFourSignal != null){      
       setDoorFour = doorFourSignal.hasSignal;
     } 
     setHasSignal = doorOneSignal.hasSignal;
     setDoorSignal = doorTwoSignal.hasSignal;
     
      DungObjectAnim gt = DungObjectAnim.Instance();
     testIsOpen = gt.isFDoorOpen; 
     if(setHasSignal || setDoorSignal || setDoorThree || setDoorFour){
        StartCoroutine(doChanges());
     }
    }
    public IEnumerator doChanges(){
       changeStatesByname();
       yield return null;
       //changeDoorsStat();
    }
     bool useFunc(){ return true;}
     string strFunc(string strF){return strF;}
     private void changeStatesByname(){
     bool newFunc = useFunc();
     string useStrFunc = strFunc("rfe");
         (dngDoorType, selectDungRoom , useStrFunc) = (setDoorSignal && testIsOpen) ? (DungDoorName.dungDoorThree, DungRoomName.roomThree,casesMethod("DungenDoorRight")) : 
                      (setHasSignal)  ? (DungDoorName.dungDoorOne , DungRoomName.roomOne, casesMethod("DungenDoor")): 
                      (setDoorThree)  ? (DungDoorName.dungDoorTwo , DungRoomName.roomTwo, casesMethod("DungenDoorDown")): 
                      (setDoorFour)  ? (DungDoorName.dungDoorFour , DungRoomName.roomFour, casesMethod("DungenDoorBtn")):
                      (DungDoorName.NoDoor, DungRoomName.NoRoom, casesMethod(""));   

         if(!setDoorThree){
            doorClose("DungenDoorDown");
         }               
     }        
    private string casesMethod(string gmName){
       if(gmName != null || gmName != ""){
         //dngInventory.isItem = true;
         //dngInventory.getItems();
            //if(isDialogActive && dngInventory.itemCount > 0){
                   doorOpen(gmName);
        //}
       }
        return gmName;
      }
    public void doorOpen(string nameDoor){         
       dngDoor = GameObject.Find(nameDoor);
       dngDoor.GetComponent<SpriteRenderer>().enabled = false;              
          //dngInventory.itemCount--;
          //roomTrs.SetActive(true);                 
    }
    void changeDoorsStat(){ 
       if(setHasSignal || setDoorSignal){
          if(setHasSignal){
             doorOneSignal.hasSignal = false;
               setHasSignal = false;
               }else if(setDoorSignal){
               doorTwoSignal.hasSignal = false; 
               setDoorSignal = false;
               }
            /* else{
              countedThreeSignals = 0;
              dngRoomThree.isDefeated = false;
              dngRoomThree.dungLogsSignal.hasSignal = false;
            } */
       }
    }
    public void doorClose(string nameDoor){
       //transform.gameObject.transform.GetChild(0).gameObject.SetActive(false);
       doorOneSignal.hasSignal = false;
       dngDoor = GameObject.Find(nameDoor);
       dngDoor.GetComponent<SpriteRenderer>().enabled = true;
       //GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(false);    
    }
  
}
