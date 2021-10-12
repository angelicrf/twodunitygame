using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : PowerUpHeart
{
    public NumValues heartValue;
    public float maxHearts;
    public NumValues plHealthValue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            powerUpSignal.ReadSignals();
            if (powerUpSignal.hasSignal)
            {
                heartValue.runTime += maxHearts;
                if (heartValue.numToUse > heartValue.runTime * 2f)
                {
                    plHealthValue.numToUse = heartValue.runTime * 2f;
                }
                this.gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    }
}
