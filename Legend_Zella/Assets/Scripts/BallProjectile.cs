using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallProjectile : MonoBehaviour
{
   public Rigidbody2D ballRidgid;
   public Vector2 ballDirection;
   public float timeSpeed;
   public float durationTime;
  

    void Start()
    {
        ballRidgid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        Destroy(this.gameObject);
    }
}
