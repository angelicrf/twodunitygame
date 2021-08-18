using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logs : Oponent
{
    public Transform target;
    public float chaseRad;
    public float attackRad;
    public Transform HomePos;
    //private Rigidbody2D enmRigid;
    public EnemStates currentEnmState;

    void Start()
    {
        currentEnmState = EnemStates.idle;
        target = GameObject.Find("Player").transform;
        //enmRigid = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        CheckDistance();
    }
    void CheckDistance(){
        //Debug.Log("Distance is " + Vector3.Distance(target.position, transform.position));
        if(Vector3.Distance(target.position, transform.position) <= chaseRad
         & 
        Vector3.Distance(target.position , transform.position) > attackRad){
           if(currentEnmState == EnemStates.idle || currentEnmState == EnemStates.walk && currentEnmState != EnemStates.stagger){
            //Debug.Log("InSide LessNum....");
            //Vector3 tmpPos = 
            transform.position = Vector3.MoveTowards(transform.position,target.position,enmSpeed * Time.deltaTime);
            //if(currentEnmState == EnemStates.idle){
              ChangeLgState(EnemStates.walk); 
            //}
           }
            //enmRigid.MovePosition(tmpPos);
        }
    }
    void ChangeLgState(EnemStates newSt){
        if(currentEnmState != newSt){
            currentEnmState = newSt;
        }
    }
   /*   void OnTriggerEnter2D(Collider2D other){
         Debug.Log("Log is collided with ");
    } */
}
