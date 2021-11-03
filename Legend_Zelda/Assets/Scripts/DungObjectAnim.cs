using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungObjectAnim : MonoBehaviour
{
    public Animator dungAnim;
    public bool isFDoorOpen = false;
    public Inventory dngInventory;
    public Rigidbody2D plRigid;
    public Signal changeDungStates;
    private DialogBoxMsg msgBoxAnim;
    private bool isPlayed = false;
    public static DungObjectAnim isDoorDungClass;

    public static DungObjectAnim Instance()
    {
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isFDoorOpen)
            {
                StartCoroutine(DungObjChange());
                //add item
                dngInventory.isItem = true;
                dngInventory.GetItems();
            }
            else if (isPlayed && isFDoorOpen)
            {
                //display abox msg
                msgBoxAnim.AppearBox();
            }
        }
    }
    public IEnumerator DungObjChange()
    {
        plRigid.GetComponent<PlayerMouvment>().currentPlState = PlayerMouvment.PlayerState.idle;
        dungAnim.SetBool("isDungObj", true);
        isFDoorOpen = true;
        yield return new WaitForSeconds(4f);
        plRigid.GetComponent<PlayerMouvment>().currentPlState = PlayerMouvment.PlayerState.walk;
        isPlayed = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DungObjStart());
            msgBoxAnim.DisappearBox();
            // doorClose();
        }
    }
    public IEnumerator DungObjStart()
    {
        yield return null;
        dungAnim.SetBool("isDungObj", false);
    }
}
