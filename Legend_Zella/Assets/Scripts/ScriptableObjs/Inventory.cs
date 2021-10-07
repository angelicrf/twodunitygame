using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public int itemCount;
    public bool isItem = false;
    public TresureItem trItem;
    public float maxMagic = 10;
    public float currentMagic;
    public List<GameObject> itemsList;
    
    public void OnEnable(){
        currentMagic = maxMagic;
    }
    public void setCurrentMagic(float thisMgc){
        currentMagic -= thisMgc;
    }
    public void getItems(){
        if(isItem){       
                itemCount++;
                itemsList.Add(trItem.items);             
        }      
    }

}
