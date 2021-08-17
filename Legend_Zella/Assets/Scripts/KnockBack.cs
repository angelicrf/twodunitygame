using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float force;
    public float knockTime;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Log")){
            Rigidbody2D enemRgdBody = other.GetComponent<Rigidbody2D>();
            try
            {
                enemRgdBody.isKinematic = false;
                Vector2 getDifference = enemRgdBody.transform.position - transform.position;
                getDifference = getDifference.normalized * force;
                enemRgdBody.AddForce(getDifference,ForceMode2D.Impulse);
                StartCoroutine(KnockStart(enemRgdBody));
            }
            catch (System.Exception e)
            {
                Debug.Log("error from EnemRigidBody " + e);
                throw;
            }
            
        }
    }
    IEnumerator KnockStart(Rigidbody2D enem){
      if(enem != null){
            yield return new WaitForSeconds(knockTime);
            enem.velocity = Vector2.zero;
            enem.isKinematic = true;
      }
        
    }
}
