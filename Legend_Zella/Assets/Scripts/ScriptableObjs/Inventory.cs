using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Inventory : ScriptableObject
{
    public int itemCount;
    public bool isItem = false;
    public TresureItem trItem;
    public float maxMagic = 10;
    public float currentMagic;
    public List<GameObject> itemsList;

    public void OnEnable()
    {
        currentMagic = maxMagic;
    }
    public void SetCurrentMagic(float thisMgc)
    {
        currentMagic -= thisMgc;
    }
    public void GetItems()
    {
        if (isItem)
        {
            itemCount++;
            itemsList.Add(trItem.items);
        }
    }

}
