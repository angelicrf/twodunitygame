using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PotBreak"))
        {
            other.GetComponent<Pot>().SmashStart();
        }
    }
}
