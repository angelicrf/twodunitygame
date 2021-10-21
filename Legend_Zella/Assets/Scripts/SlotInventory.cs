using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SlotInventory : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI itemNumTxt;
    [SerializeField] private Image itemImg;

    public InventoryItem inventoryItem;
    public InventoryManager inventoryManager;

    public void SetMAnager_Inventory(InventoryManager newInvMng, InventoryItem newInvItm)
    {
        inventoryManager = newInvMng;
        inventoryItem = newInvItm;
        if (inventoryItem)
        {
            itemImg.sprite = inventoryItem.itemImg;
            itemNumTxt.text = "" + inventoryItem.numberCount;
        }
    }
    public void OnClickItemsDisplay()
    {
        if (inventoryItem)
        {
            inventoryManager.SetBtn_itemDesc(inventoryItem.itemDescription, inventoryItem.isUsable, inventoryItem);
        }
    }
}
