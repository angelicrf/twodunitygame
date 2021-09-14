using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public int itemCount;
    public bool isItem = false;
    public TresureItem trItem;
    public List<GameObject> itemsList;
    
    public void getItems(){
        if(isItem){       
                itemCount++;
                itemsList.Add(trItem.items);             
        }      
    }

}
