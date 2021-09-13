using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class NumValues : ScriptableObject, ISerializationCallbackReceiver
{
   public float numToUse;
   //[HideInInspector]
   public float runTime;
   //For each time the project runs the value resets to 6
    public void OnAfterDeserialize(){
       runTime = numToUse;
    }
    public void OnBeforeSerialize(){}
}
