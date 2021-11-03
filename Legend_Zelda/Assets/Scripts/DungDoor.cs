using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungDoor : InteractableObjs
{
    public enum DungRoomName { roomOne, roomTwo, roomThree, roomFour, NoRoom }
    public enum DungDoorName { dungDoorOne, dungDoorTwo, dungDoorThree, dungDoorFour, NoDoor }
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


    public static DungDoor Instance()
    {
        if (!isDungDoorClass)
        {
            isDungDoorClass = FindObjectOfType(typeof(DungDoor)) as DungDoor;
        }
        return isDungDoorClass;
    }
    void LateUpdate()
    {
        dngRoomThree = DungRoomThree.Instance();
        if (doorThreeSignal != null)
        {
            setDoorThree = doorThreeSignal.hasSignal;
        }
        if (doorFourSignal != null)
        {
            setDoorFour = doorFourSignal.hasSignal;
        }
        setHasSignal = doorOneSignal.hasSignal;
        setDoorSignal = doorTwoSignal.hasSignal;

        DungObjectAnim gt = DungObjectAnim.Instance();
        testIsOpen = gt.isFDoorOpen;
        if (setHasSignal || setDoorSignal || setDoorThree || setDoorFour)
        {
            StartCoroutine(DoChanges());
        }
    }
    public IEnumerator DoChanges()
    {
        ChangeStatesByname();
        yield return null;

    }
    bool UseFunc() { return true; }
    string StrFunc(string strF) { return strF; }
    private void ChangeStatesByname()
    {
        bool newFunc = UseFunc();
        string useStrFunc = StrFunc("rfe");
        (dngDoorType, selectDungRoom, useStrFunc) = (setDoorSignal && testIsOpen) ? (DungDoorName.dungDoorThree, DungRoomName.roomThree, CasesMethod("DungenDoorRight")) :
                     (setHasSignal) ? (DungDoorName.dungDoorOne, DungRoomName.roomOne, CasesMethod("DungenDoor")) :
                     (setDoorThree) ? (DungDoorName.dungDoorTwo, DungRoomName.roomTwo, CasesMethod("DungenDoorDown")) :
                     (setDoorFour) ? (DungDoorName.dungDoorFour, DungRoomName.roomFour, CasesMethod("DungenDoorBtn")) :
                     (DungDoorName.NoDoor, DungRoomName.NoRoom, CasesMethod(""));

        if (!setDoorThree)
        {
            DoorClose("DungenDoorDown");
        }
    }
    private string CasesMethod(string gmName)
    {
        if (gmName != null || gmName != "")
        {

            DoorOpen(gmName);

        }
        return gmName;
    }
    public void DoorOpen(string nameDoor)
    {
        dngDoor = GameObject.Find(nameDoor);
        dngDoor.GetComponent<SpriteRenderer>().enabled = false;

    }
    void ChangeDoorsStat()
    {
        if (setHasSignal || setDoorSignal)
        {
            if (setHasSignal)
            {
                doorOneSignal.hasSignal = false;
                setHasSignal = false;
            }
            else if (setDoorSignal)
            {
                doorTwoSignal.hasSignal = false;
                setDoorSignal = false;
            }

        }
    }
    public void DoorClose(string nameDoor)
    {

        doorOneSignal.hasSignal = false;
        dngDoor = GameObject.Find(nameDoor);
        dngDoor.GetComponent<SpriteRenderer>().enabled = true;

    }

}
