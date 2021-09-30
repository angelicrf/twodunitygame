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
  public LootTable lootTable;
  public Rigidbody2D ptLogRigid;
  private GameObject lootObj;
  public GameObject coindIdle;
  public GameObject heartIdle;
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
        callLootTable(lootObj);
        //after condition
        // destroyAll();
        this.gameObject.SetActive(false);
        
        StartCoroutine(destroyEnemy());
      }
    }
    private void callLootTable(GameObject gy){   
        if(lootTable != null){
         gy = lootTable.pwH();
         Instantiate(gy, transform.position,Quaternion.identity);       
        }
    }
    private IEnumerator destroyEnemy(){
         //yield return new WaitForSeconds(1f);
         deathEffect.SetActive(false);
         heartIdle.SetActive(false);
         coindIdle.SetActive(false);
         lootObj.SetActive(false);
         yield return new WaitForSeconds(2f);
         dungDefeatSignal.ReadSignals();
    }
    private void generateDeathEffect(){
      GameObject dtObj = Instantiate(deathEffect, transform.position , Quaternion.identity);
    }
    private void destroyObjects(GameObject gmO){
      gmO.SetActive(false);
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
