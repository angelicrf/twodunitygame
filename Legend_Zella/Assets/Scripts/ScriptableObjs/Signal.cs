using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal : ScriptableObject
{
   public List<SignalListener> allSignals = new List<SignalListener>();

   public void ReadSignals(){
       for (int i = allSignals.Count -1; i >= 0; i--){
           allSignals[i].OnRaiseSignal();
       }
   }
   public void AddSignals(SignalListener listener){
       allSignals.Add(listener);
   }
   public void DeleteSignal(SignalListener listener){
      allSignals.Remove(listener);
   }
}
