using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungRoomUpTrigger : MonoBehaviour
{
   public GameObject dngRoomTrg;

   public void changeRoomDoorState(){
       dngRoomTrg.GetComponent<DungDoor>().selectDungRoom = DungDoor.DungRoomName.roomOne;
       dngRoomTrg.GetComponent<DungDoor>().dngDoorType = DungDoor.DungDoorName.dungDoorOne;
   }
}
