using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvment : MonoBehaviour
{
    public float speed;
    public Rigidbody2D plRigid;
    private Vector3 plChange;
    private Animator animator;
    public bool waliked; 
      void Awake(){
        BoxCollider2D bc;
        bc = GameObject.Find("Player").AddComponent<BoxCollider2D>() as BoxCollider2D;
        bc.size = new Vector2(0.9672769f, 0.6574417f);
        bc.offset = new Vector2(0.05468863f,-0.4300305f);
        bc.isTrigger = true;
    }
    void Start()
    {   
        plRigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        plChange = Vector3.zero;
        //Debug.Log("plChange is " + plChange );
        plChange.x = Input.GetAxisRaw("Horizontal");
        plChange.y = Input.GetAxisRaw("Vertical");
        animator = GetComponent<Animator>();
        walikngAnimator();
    
    }
    void walikngAnimator(){
        
        if(plChange != Vector3.zero){
            animator.SetFloat("moveX" , plChange.x);
            animator.SetFloat("moveY", plChange.y);
            animator.SetBool("waliked", true);
            moveCharacters();
            waliked = true;
         }
          else{ 
            animator.SetBool("waliked", false);
            waliked = false;
        }
         
    }
    void moveCharacters(){
        plRigid.MovePosition(transform.position + plChange * speed * Time.deltaTime);
    }
   /*  void OnTriggerEnter2D(Collider2D other){
        Debug.Log("IsEnteredClodiderFromPlayer..." + other.name);
        //if Sign or Collision
    } */
   
}
