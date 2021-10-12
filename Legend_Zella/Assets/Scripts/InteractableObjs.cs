using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjs : MonoBehaviour
{
    public Signal textMarkSignal;
    public bool isDialogActive;
    public bool hasSignal = false;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "Player" && !other.isTrigger)
        {
            textMarkSignal.ReadSignals();
            hasSignal = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player" && !other.isTrigger)
        {
            textMarkSignal.ReadSignals();

        }
    }
}
