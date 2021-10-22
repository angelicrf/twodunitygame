using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryActualItems : MonoBehaviour
{
    [SerializeField] private InventoryItem inventoryItem;
    [SerializeField] private PlayerInventory playerInventory;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddItemInventory();
            Debug.Log("item added to inventory");
            this.gameObject.SetActive(false);
        }
    }
    void AddItemInventory()
    {
        if (inventoryItem && playerInventory)
        {
            if (playerInventory.plInventory.Contains(inventoryItem))
            {
                inventoryItem.numberCount++;
            }
            else
            {
                playerInventory.plInventory.Add(inventoryItem);
                inventoryItem.numberCount++;

            }
        }
    }
}
