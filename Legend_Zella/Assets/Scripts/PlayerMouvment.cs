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
    void Start()
    {
        
        plRigid = GetComponent<Rigidbody2D>();
    }
    void Update(){
        plChange = Vector3.zero;
        plChange.x = Input.GetAxisRaw("Horizontal");
        plChange.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Debug.Log("plChange is " + plChange );
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

        }else{
            animator.SetBool("waliked", false);
            waliked = false;
        }
    }
    void moveCharacters(){
        plRigid.MovePosition(transform.position + plChange * speed * Time.deltaTime);
    }
   
}
