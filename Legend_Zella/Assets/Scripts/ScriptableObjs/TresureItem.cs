using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TresureItem : ScriptableObject, ISerializationCallbackReceiver
{
    public GameObject items;
    public bool isOpen;
    public bool initialIsOpen;
    public void OnBeforeSerialize(){
       initialIsOpen = isOpen;
    }
    public void OnAfterDeserialize(){}
  
}
