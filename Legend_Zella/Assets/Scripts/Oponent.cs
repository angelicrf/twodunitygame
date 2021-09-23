using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oponent : MonoBehaviour
{
  public enum EnemStates{idle,walk,stagger};
  public NumValues maxNum;
  public GameObject deathEffect;
  public float healthOk;
  public int attackBase;
  public float enmSpeed;
  public string enemName;
  public Signal dungDefeatSignal;

  public Rigidbody2D ptLogRigid;
 
  private void Awake(){
    healthOk = maxNum.numToUse;
  }
  public EnemStates currentEnState;

     public void callEnemyStart(Rigidbody2D enmRigid,float timeBack, float damage){
      
        StartCoroutine(EnemyStart(enmRigid,timeBack,damage));
        //ChangeHealthScore(damage);
    }
    private void ChangeHealthScore(float damage){
      healthOk -= damage;
      if(healthOk <= 0){
        generateDeathEffect();
        this.gameObject.SetActive(false);
        destroyDeathEffect();
      }
    }
    private void generateDeathEffect(){
      GameObject dtObj = Instantiate(deathEffect, transform.position , Quaternion.identity);
    }
    private void destroyDeathEffect(){
         Destroy(deathEffect,1f);
         dungDefeatSignal.ReadSignals();
    }
    IEnumerator EnemyStart(Rigidbody2D enmRigid,float timeBack,float damage){
      if(enmRigid != null){
        yield return new WaitForSeconds(timeBack);
        enmRigid.velocity = Vector2.zero;
        enmRigid.isKinematic = true;
        currentEnState = EnemStates.idle;
        enmRigid.velocity = Vector2.zero;
        //call kickFunc
        //StartCoroutine(kickAnimStart());
        ChangeHealthScore(damage);
      }
    }
  

}
