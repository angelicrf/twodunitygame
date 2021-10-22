using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/PlayerItem")]
public class PlayerInventory : ScriptableObject
{
    public List<InventoryItem> plInventory = new List<InventoryItem>();

}
