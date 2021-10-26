using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : PowerUpHeart
{
    public NumValues heartValue;
    public float maxHearts;
    public NumValues plHealthValue;
    private bool isEntered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isEntered && other.CompareTag("Player") && !other.isTrigger)
        {
            isEntered = true;
            if (powerUpSignal)
            {
                powerUpSignal.ReadSignals();
                if (powerUpSignal.hasSignal)
                {
                    if (heartValue)
                    {
                        heartValue.runTime += maxHearts;
                        if (heartValue.numToUse > heartValue.runTime * 2f)
                        {
                            plHealthValue.numToUse = heartValue.runTime * 2f;
                        }
                    }
                    this.gameObject.SetActive(false);
                    Destroy(this.gameObject);

                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            isEntered = false;
        }
    }
}
