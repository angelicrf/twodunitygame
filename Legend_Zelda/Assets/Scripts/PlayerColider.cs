using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColider : MonoBehaviour
{
    public Rigidbody2D plRigid;

    void Start()
    {

        plRigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        TryCamera();
    }
    void TryCamera()
    {
        Debug.Log("col happened..");

    }
}
