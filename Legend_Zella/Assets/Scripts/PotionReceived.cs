using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionReceived : MonoBehaviour
{
    public NumValues addValue;
    public Signal potionSignal;
    public void SetPotionValue(int addVal)
    {
        addValue.runTime += addVal;
        potionSignal.hasSignal = true;
        potionSignal.ReadSignals();
    }
}

