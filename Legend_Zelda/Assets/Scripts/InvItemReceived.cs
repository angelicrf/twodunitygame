using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvItemReceived : MonoBehaviour
{
    public NumValues addValue;
    public Signal invItemSignal;
    public void SetInvItemValue(int addVal)
    {
        addValue.runTime += addVal;
        invItemSignal.hasSignal = true;
        invItemSignal.ReadSignals();
    }
}

