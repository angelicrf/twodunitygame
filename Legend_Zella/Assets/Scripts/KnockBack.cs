using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float force;
    public float knockTime;

   
    void OnTriggerEnter2D(Collider2D other){
      if(other != null){
          if(other.gameObject.CompareTag("PotBreak")
           //&& other.gameObject.CompareTag("Player")
           ){     
           Debug.Log("PotBreak is called..."); 
           other.GetComponent<Pot>().SmashStart();
         } 
        if(other.gameObject.CompareTag("Log") || other.gameObject.CompareTag("Player")){     
             Rigidbody2D enemRgdBody = other.GetComponent<Rigidbody2D>();
                enemRgdBody.isKinematic = false;
                Vector2 getDifference = enemRgdBody.transform.position - transform.position;
                getDifference = getDifference.normalized * force;
                enemRgdBody.AddForce(getDifference,ForceMode2D.Impulse);
                if(enemRgdBody != null){
                if(other.CompareTag("Log")){
                    Debug.Log("InsideLogTrans....");
                  enemRgdBody.GetComponent<Oponent>().currentEnState = Oponent.EnemStates.stagger;  
                  other.GetComponent<Oponent>().callEnemyStart(enemRgdBody,knockTime);
                }
                if(other.CompareTag("Player")){
                     Debug.Log("InsidePlayerTrans....");
                  other.GetComponent<PlayerMouvment>().currentPlState = PlayerMouvment.PlayerState.stagger;
                  other.GetComponent<PlayerMouvment>().callPlayerStart(knockTime);
                }
                }
           }
        }
    }
  /*   IEnumerator KnockStart(Rigidbody2D enem){
      if(enem != null){
            yield return new WaitForSeconds(knockTime);
            enem.velocity = Vector2.zero;
            enem.isKinematic = true;
            enem.GetComponent<Logs>().currentEnmState = Logs.LogSates.idle;
      }
        
    } */
}
