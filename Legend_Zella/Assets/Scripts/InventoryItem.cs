using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Items")]
public class InventoryItem : ScriptableObject
{
    public Sprite itemImg;
    public string itemName;
    public string itemDescription;
    public bool isUnique;
    public bool isUsable;
    public int numberCount;
}
