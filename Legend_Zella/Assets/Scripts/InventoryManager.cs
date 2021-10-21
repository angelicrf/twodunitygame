using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] public GameObject specificSlot;
    [SerializeField] public GameObject inventoryConent;
    [SerializeField] public TextMeshProUGUI itemDescript;
    [SerializeField] public GameObject buttonUse;
    public PlayerInventory playerInventory;
    public InventoryItem currentItem;

    public void SetBtn_itemDesc(string newTxt, bool isActive, InventoryItem newItem)
    {
        itemDescript.text = newTxt;
        currentItem = newItem;
        if (isActive)
        {
            buttonUse.SetActive(true);
        }
        else
        {
            buttonUse.SetActive(false);
        }
    }
    public void CallUseBtn()
    {
        if (currentItem)
        {
            Debug.Log("there is newItem");
            currentItem.UseEvent();
        }
    }
    void Start()
    {
        SetBtn_itemDesc("", false, null);
        CreateNewSlots();
    }

    public void CreateNewSlots()
    {
        for (int i = 0; i < playerInventory.plInventory.Count; i++)
        {
            GameObject tempItem = Instantiate(specificSlot, inventoryConent.transform.position, Quaternion.identity);
            if (tempItem)

            {
                tempItem.transform.SetParent(inventoryConent.transform);
                SlotInventory newSlot = tempItem.GetComponent<SlotInventory>();

                if (newSlot)
                {
                    newSlot.SetMAnager_Inventory(this, playerInventory.plInventory[i]);
                }
            }
        }

    }
}
