using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speedArrow;
    public Rigidbody2D arrowRgd;
    public bool isDestroyed = false;
    public GameObject deathEffect;
    public Signal magicSignal;
    void Start()
    {
        
    }
    public void throwArrow(Vector2 vlcity, Vector3 dirArrow){
        arrowRgd.velocity =  vlcity.normalized * speedArrow;
        transform.rotation = Quaternion.Euler(dirArrow);
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Log")){
           StartCoroutine(setpsArrow(other));
        }
    }
    private IEnumerator setpsArrow(Collider2D other){
            deathEffect.SetActive(true); 
            deathEffect.transform.position = other.transform.position;
            Instantiate(deathEffect, other.transform.position , Quaternion.identity);
            yield return new WaitForSeconds(1f);
            deathEffect.SetActive(false);
            //call LootTable
            Destroy(other.gameObject); 
            //gain point here
          if(magicSignal != null){
            magicSignal.hasSignal = true;
            magicSignal.ReadSignals();
          }     
    }

}
