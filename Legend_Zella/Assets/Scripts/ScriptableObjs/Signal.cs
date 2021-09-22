using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal : ScriptableObject
{
  
   public List<SignalListener> allSignals = new List<SignalListener>();
   public bool hasSignal = false;
   public int countSignals = 0;
   public void ReadSignals(){
       Debug.Log("ReadSignal Called...");
       countSignals++;
       for (int i = allSignals.Count -1; i >= 0; i--){
           allSignals[i].OnRaiseSignal();
       }
       hasSignal = true;
   }
   public void AddSignals(SignalListener listener){
       allSignals.Add(listener);
   }
   public void DeleteSignal(SignalListener listener){
      allSignals.Remove(listener);
   }
 
}
