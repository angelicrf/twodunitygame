using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMouvment : MonoBehaviour
{
    public enum PlayerState{ walk, attack, interact,idle,stagger}
    public float speed;
    public NumValues plHealth;
    public PlayerState currentPlState;
    public Rigidbody2D plRigid;
    private Vector3 plChange;
    private Animator animator;
    public bool waliked; 
    private BoxCollider2D bc;
    public Signal plSignal;
    public VectorTransitValue plStartPos;
    private DialogBoxMsg dlgMsg;
    public Animator enmCameraAnim;
    public Signal kickSignal;
    public GameObject arrowInstance;
    public Inventory magicInventory;
    public Signal magicSignal;
    public Signal arrowSignal;
      void Awake(){
        
        bc = GameObject.Find("Player").AddComponent<BoxCollider2D>() as BoxCollider2D;
        bc.size = new Vector2(0.5f, 0.5f);
        bc.offset = new Vector2(0f,-0.5f);
    }
    void Start()
    {  
       dlgMsg = DialogBoxMsg.Instance(); 
       enmCameraAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
       animator = GetComponent<Animator>();
      //plHealth.numToUse = 6;
       if(plStartPos.isTransited){
           transform.position = plStartPos.transitionValue;
           plStartPos.isTransited = false;
       }
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
                StartCoroutine(AttackStart());
        }
        else if(Input.GetButtonDown("arrow") & currentPlState != PlayerState.attack && currentPlState != PlayerState.stagger && arrowSignal.hasSignal){
                StartCoroutine(arrowAttck());
        }
        else if(currentPlState == PlayerState.walk || currentPlState == PlayerState.idle && currentPlState != PlayerState.interact){
                walikngAnimator();

        }else if(currentPlState == PlayerState.interact){
                StartCoroutine(onHoldHands());
        }
           
    }
    public IEnumerator AttackStart(){
       animator.SetBool("attacking", true);
       currentPlState = PlayerState.attack;
       yield return null;
       animator.SetBool("attacking",false);
       yield return new WaitForSeconds(.3f);
       currentPlState = PlayerState.walk;
    }

    private IEnumerator arrowAttck(){   
       currentPlState = PlayerState.attack;
       yield return null;
       arrowInstanceM();
       yield return new WaitForSeconds(.3f);
       currentPlState = PlayerState.walk;
    }
    private void arrowInstanceM(){
      if(magicInventory != null){
        if(magicInventory.currentMagic > 0){
          Vector2 tmp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
          Arrow ar = Instantiate(arrowInstance,transform.position, Quaternion.identity).GetComponent<Arrow>();
          ar.throwArrow(tmp,createArrowDir());
          if(magicSignal != null){
            magicInventory.setCurrentMagic(ar.magicCost);
            magicSignal.hasSignal = true;
            magicSignal.ReadSignals();
          } 
        }
      }
    }
    private Vector3 createArrowDir(){
       float tempDir = Mathf.Atan2(animator.GetFloat("moveY"),animator.GetFloat("moveX")) * Mathf.Rad2Deg;
       return new Vector3(0,0,tempDir);
    }
      public IEnumerator kickAnimStart(){
      kickSignal.ReadSignals();
     
      if(kickSignal.hasSignal){
        enmCameraAnim.SetBool("isCkicked", true);
        yield return null;
        enmCameraAnim.SetBool("isCkicked", false);
      }
    }
    void walikngAnimator(){
        
        if(plChange != Vector3.zero){
            plChange.x = Mathf.Round(plChange.x);
            plChange.y = Mathf.Round(plChange.y); 
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
    public void callPlayerStart(float timeBack, float dmg){
                 
         plHealth.runTime -=  dmg;
         plSignal.ReadSignals();    
        if(plHealth.runTime > 0){
          StartCoroutine(PlayerStart(timeBack));
        }else{
          this.gameObject.SetActive(false);  
        }
    }
    IEnumerator PlayerStart(float timeBack){
        yield return new WaitForSeconds(timeBack);
        plRigid.velocity = Vector2.zero;
        currentPlState = PlayerState.idle;
        plRigid.velocity = Vector2.zero; 
    }
    private IEnumerator onHoldHands(){
        animator.SetBool("HoldToStop", true);
        animator.SetBool("waliked", false);
        dlgMsg.appearBox();
        yield return new WaitForSeconds(6f);
        animator.SetBool("HoldToStop", false); 
        yield return null;
        animator.SetBool("waliked", true);
        currentPlState = PlayerState.walk;
        dlgMsg.disappearBox();     
    }

}
