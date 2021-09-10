using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungDoor : InteractableObjs
{
    public enum DoorType{ keyDoor, close, open}
    public SpriteRenderer dngDoor;
    public Collider2D dnDoorCld;
    public Inventory dngInventory;
    public Image replaceDoorSprt;
    public GameObject roomTrs;
    public GameObject scriptTrs;
     

    void Update()
    {

      if(Input.GetKeyDown(KeyCode.Space) && hasSignal){
               dngInventory.isItem = true;
               dngInventory.getItems();
                if(isDialogActive && dngInventory.itemCount > 0){
                   doorOpen();
                }}
        
    }
    void doorOpen(){
        transform.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        //Debug.Log("InsideDungean.....");
                    //deactivate current sprite
                    dngDoor.enabled = false;
                    GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
                    //GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
                    //dngDoor.sprite = replaceDoorSprt.sprite;
                    //dngInventory.itemCount--;
                    //roomTrs.SetActive(true);

                    //replace it with another sprite
                    //key number --;
                    //transfer to another room
    }
    void doorClose(){

    }
}
