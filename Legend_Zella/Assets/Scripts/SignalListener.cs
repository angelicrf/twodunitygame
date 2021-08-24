using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    public Signal signal;
    public UnityEvent eve;
     public void OnRaiseSignal(){
        eve.Invoke();
     }
     private void ActiveEvent(){
         signal.AddSignals(this);
     }
     private void DeactiveEvent(){
         signal.DeleteSignal(this);
     }
}
