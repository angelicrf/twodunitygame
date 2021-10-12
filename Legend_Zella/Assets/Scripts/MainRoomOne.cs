using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoomOne : MonoBehaviour
{
    public Logs[] allOponents;
    public Pot[] allPots;
    public bool insidePolygon = false;

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !other.isTrigger)
        {
            insidePolygon = true;

            for (int i = 0; i < allOponents.Length; i++)
            {
                ChangeGameObjectStat(allOponents[i], true);
            }
            for (int i = 0; i < allPots.Length; i++)
            {
                ChangeGameObjectStat(allPots[i], true);
            }
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            insidePolygon = false;
            for (int i = 0; i < allOponents.Length; i++)
            {
                ChangeGameObjectStat(allOponents[i], false);
            }
            for (int i = 0; i < allPots.Length; i++)
            {
                ChangeGameObjectStat(allPots[i], false);
            }
        }
    }
    public void ChangeGameObjectStat(Component comps, bool isSet)
    {
        comps.gameObject.SetActive(isSet);
    }

}
