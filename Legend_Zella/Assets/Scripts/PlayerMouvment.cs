using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMouvment : MonoBehaviour
{
    public enum PlayerState{ walk, attack, interact,idle,stagger}
    public float speed;
    public PlayerState currentPlState;
    public Rigidbody2D plRigid;
    private Vector3 plChange;
    private Animator animator;
    public bool waliked; 
    private BoxCollider2D bc;
    //private string replacePlText;
    //public Text placePlText;
    //public GameObject newPlTextObj;
      void Awake(){
        
        bc = GameObject.Find("Player").AddComponent<BoxCollider2D>() as BoxCollider2D;
        bc.size = new Vector2(0.9672769f, 0.6574417f);
        bc.offset = new Vector2(0.05468863f,-0.4300305f);
        //plRigid.bodyType = RigidbodyType2D.Dynamic;
        //if isKinematic
        //bc.isTrigger = true;
    }
    void Start()
    {   
        currentPlState = PlayerState.walk;
        plRigid = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX" , 0);
        animator.SetFloat("moveY", -1);
    }

    void FixedUpdate()
    {
        plChange = Vector3.zero;
        plChange.x = Input.GetAxisRaw("Horizontal");
        plChange.y = Input.GetAxisRaw("Vertical");
        animator = GetComponent<Animator>();
        if(Input.GetButtonDown("attack") & currentPlState != PlayerState.attack && currentPlState != PlayerState.stagger){
           // use space button to attack
                StartCoroutine(AttackStart());
        }
        else if(currentPlState == PlayerState.walk || currentPlState == PlayerState.idle){
        walikngAnimator();
        }
        //StartCoroutine(areaPlChangeMSG("Home Area"));
    
    }
    public IEnumerator AttackStart(){
       animator.SetBool("attacking", true);
       currentPlState = PlayerState.attack;
       yield return null;
       animator.SetBool("attacking",false);
       yield return new WaitForSeconds(.3f);
       currentPlState = PlayerState.walk;
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
        plChange.Normalize();
        plRigid.MovePosition(transform.position + plChange * speed * Time.deltaTime);
    }
   /*  void OnTriggerEnter2D(Collider2D other){
        Debug.Log("IsEnteredClodiderFromPlayer..." + other.name);
        //if Sign or Collision
    } */
 /*    private IEnumerator areaPlChangeMSG(string dspText){
             newPlTextObj.SetActive(true);
             placePlText.text = dspText;
             placePlText.color = Color.green;
             yield return new WaitForSeconds(4f);
             newPlTextObj.SetActive(false);
   } */
 
  /*   void OnCollisionEnter2D(Collision2D col){
         Debug.Log("Player is collisioned with ");
    }
    void OnTriggerEnter2D(Collider2D other){
         
         Debug.Log("Player is collided with ");
    } */
    public void callPlayerStart(float timeBack){
        StartCoroutine(PlayerStart(timeBack));
    }
    IEnumerator PlayerStart(float timeBack){
        yield return new WaitForSeconds(timeBack);
        plRigid.velocity = Vector2.zero;
        currentPlState = PlayerState.idle;
        plRigid.velocity = Vector2.zero; 
    }
}
