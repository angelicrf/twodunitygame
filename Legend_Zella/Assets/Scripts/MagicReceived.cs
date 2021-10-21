using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicReceived : MonoBehaviour
{
    public NumValues addValue;
    public Signal magicSignal;
    public void SetMagigValue(int addVal)
    {
        addValue.runTime += addVal;
        magicSignal.hasSignal = true;
        magicSignal.ReadSignals();
    }
}
