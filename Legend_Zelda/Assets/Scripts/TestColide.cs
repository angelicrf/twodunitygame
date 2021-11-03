using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColide : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("GameObject2 collided with ");
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
