using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColide : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("GameObject2 collided with " + col.name);
    }
}
