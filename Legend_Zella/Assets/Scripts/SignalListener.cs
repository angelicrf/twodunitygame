using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    public Signal signal;
    public UnityEvent eve;

     public void  OnRaiseSignal(){
        eve.Invoke();
     }
     private void OnEnable(){
         signal.AddSignals(this);
     }
     private void OnDisable(){
         signal.DeleteSignal(this);
     }
}
