using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Items")]
public class InventoryItem : ScriptableObject
{
    public Sprite itemImg;
    public string itemName;
    public string itemDescription;
    public bool isUnique;
    public bool isUsable;
    public int numberCount;
    public UnityEvent ev;
    public void UseEvent()
    {
        ev.Invoke();
    }
    public void DecreaseInvItem(int numToDecrease)
    {
        if (numberCount != 0)
        {
            numberCount -= numToDecrease;
        }
        else
        {
            numberCount = 0;
        }
    }
}
