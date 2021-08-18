using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oponent : MonoBehaviour
{
  public enum EnemStates{idle,walk,stagger};
  //private Animator anim;
  public int healthOk;
  public int attackBase;
  public float enmSpeed;
  public string enemName;
  public EnemStates currentEnState;

     public void callEnemyStart(Rigidbody2D enmRigid,float timeBack){
        StartCoroutine(EnemyStart(enmRigid,timeBack));
    }
    IEnumerator EnemyStart(Rigidbody2D enmRigid,float timeBack){
      if(enmRigid != null){
        yield return new WaitForSeconds(timeBack);
        enmRigid.velocity = Vector2.zero;
        enmRigid.isKinematic = true;
        currentEnState = EnemStates.idle;
        enmRigid.velocity = Vector2.zero;
      }
    }

}
