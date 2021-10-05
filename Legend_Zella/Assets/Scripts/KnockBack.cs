using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float force;
    public float knockTime;
    public float lossScore;
    private Rigidbody2D enemRgdBody;
     
    private IEnumerator changeVelocity(Rigidbody2D nRg){
      yield return new WaitForSeconds(2f);
      nRg.velocity = Vector2.zero;
      nRg.isKinematic = true;
    }  
   
    void OnTriggerEnter2D(Collider2D other){
      if(other != null){
          if(other.gameObject.CompareTag("PotBreak")
           //&& other.gameObject.CompareTag("Player")
           ){     
           other.GetComponent<Pot>().SmashStart();
         } 
        if(other.gameObject.CompareTag("Log") || other.gameObject.CompareTag("Player")){     
             enemRgdBody = other.GetComponent<Rigidbody2D>();
             if(enemRgdBody.gameObject.CompareTag("Log") || enemRgdBody.gameObject.CompareTag("Player")){    
                enemRgdBody.isKinematic = false;
                Vector2 getDifference = enemRgdBody.transform.position - transform.position;
                getDifference = getDifference.normalized * force;
                enemRgdBody.AddForce(getDifference,ForceMode2D.Impulse);
                 //call a func
                StartCoroutine(changeVelocity(enemRgdBody));
                if(enemRgdBody != null){
                if(other.CompareTag("Log") && other.isTrigger){
                  enemRgdBody.GetComponent<Oponent>().currentEnState = Oponent.EnemStates.stagger;  
                  //add more conditions
                  if(other.gameObject.name != "Ogre"){
                    other.GetComponent<Oponent>().callEnemyStart(enemRgdBody,knockTime, lossScore);
                  }
                }
                if(other.CompareTag("Player") && other.GetComponent<PlayerMouvment>().currentPlState != PlayerMouvment.PlayerState.stagger ){
                  
                  other.GetComponent<PlayerMouvment>().currentPlState = PlayerMouvment.PlayerState.stagger;
                  other.GetComponent<PlayerMouvment>().callPlayerStart(knockTime, lossScore);
                  StartCoroutine( other.GetComponent<PlayerMouvment>().kickAnimStart()); 
                 
                  }
                }
             }
           }
        }
    }

}
