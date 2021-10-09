using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeldaPLMovement : MonoBehaviour
{
   public Animator zlAnim;
   public Rigidbody2D zlRgd;
   public Transform zlTransf;
   public float zlSpeed;
   private Vector3 zlDirection;
   public Collider2D boundry;

    void Start()
    {
       zlAnim = GetComponent<Animator>();
       zlRgd = GetComponent<Rigidbody2D>();
       zlAnimMove();
    }

    void Update()
    {
        moveZl();
    }
    private void zlAnimMove(){
        float direction = Random.Range(0,4);
      
        switch (direction)
        {
            case 0: zlDirection = Vector3.left;
            break;
            case 1: zlDirection = Vector3.right;
            break;
            case 2: zlDirection = Vector3.up;
            break;
            case 3: zlDirection = Vector3.down;
            break;
            default:
            break;
        }
        changeAnimDir();
    }
    private void moveZl(){
        Vector3 tempPos = zlTransf.position + zlDirection * zlSpeed * Time.deltaTime;
        if(boundry.bounds.Contains(tempPos)){
          zlRgd.MovePosition(tempPos);
        }else{
            zlAnimMove();
        }
    }
    private void changeAnimDir(){
        zlAnim.SetFloat("moveX", zlDirection.x);
        zlAnim.SetFloat("moveY", zlDirection.y);
    }
    void OnCollisionEnter2D(Collision2D other){   
           Vector3 tempPos = zlDirection;
           zlAnimMove();
           int numChange = 0;
           while (numChange < 20 && tempPos == zlDirection)
           {
              numChange++;
              zlAnimMove();   
           }
        }
}
