using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logs : Oponent
{
    public Transform target;
    public float chaseRad;
    public float attackRad;
    public Animator enmAnim;
    public EnemStates currentEnmState;
    
   

    void Start()
    {
        enmAnim = GetComponent<Animator>();
        currentEnmState = EnemStates.idle;
        enmAnim.SetBool("isWokeUp", true);
        //target = GameObject.Find("Player").transform;
    }
    void FixedUpdate()
    {
        CheckDistance();
    }
    public virtual void CheckDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaseRad
         & 
        Vector3.Distance(target.position , transform.position) > attackRad){
           if(currentEnmState == EnemStates.idle || currentEnmState == EnemStates.walk && currentEnmState != EnemStates.stagger){ 
            Vector3 tmpPos = Vector3.MoveTowards(transform.position,target.position,enmSpeed * Time.deltaTime);
            CalcAnimChange(tmpPos -  transform.position);
            transform.position = Vector3.MoveTowards(transform.position,target.position,enmSpeed * Time.deltaTime);     
            ChangeLgState(EnemStates.walk); 
            enmAnim.SetBool("isWokeUp", true);        
           }
            //enmRigid.MovePosition(tmpPos);
        }else if(Vector3.Distance(target.position, transform.position) > chaseRad){
               enmAnim.SetBool("isWokeUp", false);
           }
    }
    private void SetAnimPos(Vector2 setPos){
        enmAnim.SetFloat("moveX" , setPos.x);
        enmAnim.SetFloat("moveY", setPos.y);
    }
    public void CalcAnimChange(Vector2 tmpRes){
        if(Mathf.Abs(tmpRes.x) > Mathf.Abs(tmpRes.y)){
            //Debug.Log("X is greater...");
            if(tmpRes.x > 0){
             SetAnimPos(Vector2.right); 
            }else if(tmpRes.x < 0){
             SetAnimPos(Vector2.left);
            }
        }else if(Mathf.Abs(tmpRes.x) < Mathf.Abs(tmpRes.y)){
            //Debug.Log("X is smaller..");
            if(tmpRes.y > 0){
              SetAnimPos(Vector2.up);
            }else if(tmpRes.y < 0){
              SetAnimPos(Vector2.down);   
            }
        }
    }
    void ChangeLgState(EnemStates newSt){
        if(currentEnmState != newSt){
            currentEnmState = newSt;
        }
    }

}
