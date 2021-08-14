using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logs : Oponent
{
    public Transform target;
    public float chaseRad;
    public float attackRad;
    public Transform HomePos;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }
    void Update()
    {
        CheckDistance();
    }
    void CheckDistance(){
        Debug.Log("Distance is " + Vector3.Distance(target.position, transform.position));
        if(Vector3.Distance(target.position, transform.position) <= chaseRad
         & 
        Vector3.Distance(target.position , transform.position) > attackRad){
             Debug.Log("InSide LessNum....");
            transform.position = Vector3.MoveTowards(transform.position,target.position,enmSpeed * Time.deltaTime);
        }
    }
}
