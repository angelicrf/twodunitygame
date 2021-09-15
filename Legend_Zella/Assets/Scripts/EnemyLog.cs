using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLog : Logs
{
    public bool isPassed;
    public GameObject ballRidgid2;
    public Vector2 distanceBall;
    public float setTimer;
    private float newSetTimer;
    void Start()
    {
        isPassed = true;
        if(!ballRidgid2.activeSelf){
            ballRidgid2.SetActive(true);
        ballRidgid2 = GameObject.Find("BouncingBall");
        }
        
    }

    void Update()
    {
       newSetTimer -= Time.deltaTime;
       if(newSetTimer <= 0){
           isPassed = true;
           newSetTimer = setTimer;
       }
   
    }
    public override void CheckDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaseRad
         & 
        Vector3.Distance(target.position , transform.position) > attackRad){
           if(currentEnmState == EnemStates.idle || currentEnmState == EnemStates.walk && currentEnmState != EnemStates.stagger){ 
            if(isPassed){
                distanceBall = target.position - transform.position;
                CalcAnimChange(distanceBall);
                GameObject instanceBall = Instantiate(ballRidgid2, transform.position , Quaternion.identity);
                isPassed = false; 
                instanceBall.GetComponent<GeneralProjectile>().checkBallVelocity(distanceBall);
                ChangeLgState(EnemStates.walk); 
                enmAnim.SetBool("isWokeUp", true);   
               }     
           }
        }else if(Vector3.Distance(target.position, transform.position) > chaseRad){
               enmAnim.SetBool("isWokeUp", false);
           }
    }
}
