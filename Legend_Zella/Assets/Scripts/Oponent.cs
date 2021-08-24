using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oponent : MonoBehaviour
{
  public enum EnemStates{idle,walk,stagger};
  public NumValues maxNum;
  public float healthOk;
  public int attackBase;
  public float enmSpeed;
  public string enemName;

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
        this.gameObject.SetActive(false);
        Rigidbody2D tg = this.gameObject.GetComponent<Rigidbody2D>();
        Destroy(tg);
      }
    }
    IEnumerator EnemyStart(Rigidbody2D enmRigid,float timeBack,float damage){
      if(enmRigid != null){
        yield return new WaitForSeconds(timeBack);
        enmRigid.velocity = Vector2.zero;
        enmRigid.isKinematic = true;
        currentEnState = EnemStates.idle;
        enmRigid.velocity = Vector2.zero;
        ChangeHealthScore(damage);
      }
    }

}
