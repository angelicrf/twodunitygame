using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvment : MonoBehaviour
{
    public float speed;
    private Rigidbody2D plRigid;
    private Vector3 plChange;
    private Animator animator;
    
    void Start()
    {
     
        plRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        plChange = Vector3.zero;
        plChange.x = Input.GetAxisRaw("Horizontal");
        plChange.y = Input.GetAxisRaw("Vertical");
        Debug.Log("plChange is " + plChange);
        animator = GetComponent<Animator>();
        walikngAnimator();
    }
    void walikngAnimator(){

        if(plChange != Vector3.zero){
            moveCharacters();
            animator.SetFloat("moveX" , plChange.x);
            animator.SetFloat("moveY", plChange.y);
            animator.SetBool("walked", true);

        }else{
            animator.SetBool("walked", false);
        }
    }
    void moveCharacters(){
        plRigid.MovePosition(transform.position + plChange * speed * Time.deltaTime);
    }
}
