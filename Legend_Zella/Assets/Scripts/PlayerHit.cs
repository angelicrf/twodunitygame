using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
         Debug.Log("SmashedOut...");
       if(other.CompareTag("PotBreak")){
          
           other.GetComponent<Pot>().SmashStart();
       }
    }
}
