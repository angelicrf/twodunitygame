using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float force;
    public float knockTime;
    public float lossScore;
    public Rigidbody2D enemRgdBody;
   
    void OnTriggerEnter2D(Collider2D other){
      if(other != null){
          if(other.gameObject.CompareTag("PotBreak")
           //&& other.gameObject.CompareTag("Player")
           ){     
           other.GetComponent<Pot>().SmashStart();
         } 
        if(other.gameObject.CompareTag("Log") || other.gameObject.CompareTag("Player")){     
             enemRgdBody = other.GetComponent<Rigidbody2D>();
             if(enemRgdBody.gameObject.name == "Log"){    
                enemRgdBody.isKinematic = false;
                Vector2 getDifference = enemRgdBody.transform.position - transform.position;
                getDifference = getDifference.normalized * force;
                enemRgdBody.AddForce(getDifference,ForceMode2D.Impulse);
             
                if(enemRgdBody != null){
                if(other.CompareTag("Log") && other.isTrigger){
                  enemRgdBody.GetComponent<Oponent>().currentEnState = Oponent.EnemStates.stagger;  
                  other.GetComponent<Oponent>().callEnemyStart(enemRgdBody,knockTime, lossScore);
                }
                if(other.CompareTag("Player") && other.GetComponent<PlayerMouvment>().currentPlState != PlayerMouvment.PlayerState.stagger ){
                  other.GetComponent<PlayerMouvment>().currentPlState = PlayerMouvment.PlayerState.stagger;
                  other.GetComponent<PlayerMouvment>().callPlayerStart(knockTime, lossScore);
                }
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
