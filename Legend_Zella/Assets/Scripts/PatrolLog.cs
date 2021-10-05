using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : Logs
{
    public Transform[] allPaths;
    public Transform currentGoal;
    public float accurateDistance;
    public int currentPoint;
    private int  updatedPoint;
    private GameObject pOne;
    private GameObject pTwo;
    
    public override void CheckDistance(){
       
        //visibleObjs();
        if(Vector3.Distance(target.position, transform.position) <= chaseRad
         & 
        Vector3.Distance(target.position , transform.position) > attackRad){
           if(currentEnState == EnemStates.idle || currentEnState == EnemStates.walk && currentEnState != EnemStates.stagger){ 
            Vector3 tmpPos = Vector3.MoveTowards(transform.position,target.position,enmSpeed * Time.deltaTime);
            CalcAnimChange(tmpPos -  transform.position);
            transform.position = Vector3.MoveTowards(transform.position,target.position,enmSpeed * Time.deltaTime);     
            //ChangeLgState(EnemStates.walk); 
            enmAnim.SetBool("isWokeUp", true);        
           }
            //enmRigid.MovePosition(tmpPos);
        }else 
        if(Vector3.Distance(target.position, transform.position) > chaseRad){
     
            if(Vector3.Distance(transform.position, allPaths[currentPoint].position) > accurateDistance){
               regMoveptLog();
            }
           else{
                identifyPoint();
            } 
      
           }
    }
    private void visibleObjs(){
        pOne = GameObject.Find("PointOne");
        pTwo = GameObject.Find("PointTwo");
 
        if(!pOne.GetComponent<Renderer>().enabled || !pTwo.GetComponent<Renderer>().enabled ){
            pOne.GetComponent<Renderer>().enabled = true;
            pTwo.GetComponent<Renderer>().enabled = true;
            pOne.SetActive(true);
            pTwo.SetActive(true);
        }
    }
    private  void regMoveptLog(){
         Vector3 tmpPos = Vector3.MoveTowards(transform.position,allPaths[currentPoint].position, enmSpeed * Time.deltaTime);
             CalcAnimChange(tmpPos -  transform.position);
             ptLogRigid.MovePosition(tmpPos);
    }
    private void identifyPoint(){
        
         if(currentPoint == allPaths.Length -1){
            currentPoint = 0;
            currentGoal = allPaths[0];
        }else{
           updatedPoint = currentPoint ++;
           currentGoal = allPaths[updatedPoint];
        } 

    }
}
