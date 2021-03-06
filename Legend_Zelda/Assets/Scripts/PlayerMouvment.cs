using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMouvment : MonoBehaviour
{
    public enum PlayerState { walk, attack, interact, idle, stagger, move, arrow, shoot }
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
    public Collider2D opColider;
    public Color plChangeCl;
    public Color plOriginalCl;
    public float flashDuration;
    public int flashNumbers;
    public SpriteRenderer trgSprtRend;
    [SerializeField] private AutoPlayerDirection autoPlayerDirection;
    [SerializeField] private AutoArrowThrowing autoArrowThrowing;
    [SerializeField] private AutoShooting autoShooting;
    private Vector2 changeAnimDir;

    void Awake()
    {

        bc = GameObject.Find("Player").AddComponent<BoxCollider2D>() as BoxCollider2D;
        bc.size = new Vector2(0.5f, 0.5f);
        bc.offset = new Vector2(0f, -0.5f);
    }
    void Start()
    {

        dlgMsg = DialogBoxMsg.Instance();
        enmCameraAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        animator = GetComponent<Animator>();
        trgSprtRend = GetComponent<SpriteRenderer>();

        if (plStartPos.isTransited)
        {
            transform.position = plStartPos.transitionValue;
            plStartPos.isTransited = false;
        }
        currentPlState = PlayerState.walk;
        plRigid = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    void FixedUpdate()
    {

        plChange = Vector3.zero;
        plChange.x = Input.GetAxisRaw("Horizontal");
        plChange.y = Input.GetAxisRaw("Vertical");
        animator = GetComponent<Animator>();

        if (Input.GetButtonDown("attack") & currentPlState != PlayerState.attack && currentPlState != PlayerState.stagger)
        {
            StartCoroutine(AttackStart());
        }
        else if (Input.GetButtonDown("arrow") & currentPlState != PlayerState.attack && currentPlState != PlayerState.stagger && arrowSignal && arrowSignal.hasSignal)
        {
            StartCoroutine(ArrowAttck());
        }
        else if (Input.GetButtonDown("AutoMove") & currentPlState != PlayerState.attack && currentPlState != PlayerState.stagger)
        {
            if (autoPlayerDirection)
            {
                StartCoroutine(RunMove(autoPlayerDirection.durationChange));
            }
        }
        else if (Input.GetButtonDown("AutoArrow") & currentPlState != PlayerState.attack && currentPlState != PlayerState.stagger)
        {
            if (autoArrowThrowing)
            {
                StartCoroutine(ThrowArrow(autoArrowThrowing.durationChange));
            }
        }
        else if (Input.GetButtonDown("AutoShoot") & currentPlState != PlayerState.attack && currentPlState != PlayerState.stagger)
        {
            if (autoShooting)
            {
                StartCoroutine(AutoShoot(autoShooting.durationChange));
            }
        }
        else if (currentPlState == PlayerState.walk || currentPlState == PlayerState.idle && currentPlState != PlayerState.interact)
        {
            WalikngAnimator();

        }
        else if (currentPlState == PlayerState.interact)
        {
            StartCoroutine(OnHoldHands());
        }

    }
    public IEnumerator AttackStart()
    {
        animator.SetBool("attacking", true);
        currentPlState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentPlState = PlayerState.walk;
    }

    private IEnumerator ArrowAttck()
    {
        currentPlState = PlayerState.attack;
        yield return null;
        ArrowInstanceM();
        yield return new WaitForSeconds(.3f);
        currentPlState = PlayerState.walk;
    }
    private void ArrowInstanceM()
    {
        if (magicInventory != null)
        {
            if (magicInventory.currentMagic > 0)
            {
                Vector2 tmp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
                Arrow ar = Instantiate(arrowInstance, transform.position, Quaternion.identity).GetComponent<Arrow>();
                ar.ThrowArrow(tmp, CreateArrowDir());
                if (magicSignal != null)
                {
                    magicInventory.SetCurrentMagic(ar.magicCost);
                    magicSignal.hasSignal = true;
                    magicSignal.ReadSignals();
                }
            }
        }
    }
    private Vector3 CreateArrowDir()
    {
        float tempDir = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, tempDir);
    }
    public IEnumerator KickAnimStart()
    {
        kickSignal.ReadSignals();

        if (kickSignal.hasSignal)
        {
            StartCoroutine(FlashEffect());
            enmCameraAnim.SetBool("isCkicked", true);
            yield return null;
            enmCameraAnim.SetBool("isCkicked", false);
        }
    }
    void WalikngAnimator()
    {

        if (plChange != Vector3.zero && currentPlState != PlayerState.move && currentPlState != PlayerState.arrow && currentPlState != PlayerState.shoot)
        {
            plChange.x = Mathf.Round(plChange.x);
            plChange.y = Mathf.Round(plChange.y);
            animator.SetFloat("moveX", plChange.x);
            animator.SetFloat("moveY", plChange.y);
            animator.SetBool("waliked", true);
            MoveCharacters();
            waliked = true;

        }
        else if (currentPlState == PlayerState.move)
        {
            changeAnimDir = Vector2.down;
            animator.SetFloat("moveX", changeAnimDir.x);
            animator.SetFloat("moveY", changeAnimDir.y);
            animator.SetBool("waliked", true);
            autoPlayerDirection.ChangePlDirection(transform.position, changeAnimDir, animator, plRigid);
            waliked = true;
        }
        else if (currentPlState == PlayerState.arrow)
        {

            autoArrowThrowing.ChangePlDirection(transform.position, transform.position, animator, plRigid);
        }
        else if (currentPlState == PlayerState.shoot)
        {

            autoShooting.ChangePlDirection(transform.position, transform.position, animator, plRigid);
        }
        else
        {
            animator.SetBool("waliked", false);
            waliked = false;
        }

    }
    void MoveCharacters()
    {
        plChange.Normalize();
        plRigid.MovePosition(transform.position + plChange * speed * Time.deltaTime);
    }
    public void CallPlayerStart(float timeBack, float dmg, Collider2D other)
    {

        plHealth.runTime -= dmg;
        if (plSignal)
        {
            plSignal.ReadSignals();
        }

        if (plHealth.runTime > 0)
        {
            StartCoroutine(PlayerStart(timeBack));
        }
        else
        {
            other.gameObject.SetActive(false);

        }
    }
    IEnumerator PlayerStart(float timeBack)
    {

        yield return new WaitForSeconds(timeBack);
        plRigid.velocity = Vector2.zero;
        currentPlState = PlayerState.idle;
        plRigid.velocity = Vector2.zero;
    }
    IEnumerator OnHoldHands()
    {
        animator.SetBool("HoldToStop", true);
        animator.SetBool("waliked", false);
        dlgMsg.AppearBox();
        yield return new WaitForSeconds(6f);
        animator.SetBool("HoldToStop", false);
        yield return null;
        animator.SetBool("waliked", true);
        currentPlState = PlayerState.walk;
        dlgMsg.DisappearBox();
    }
    public IEnumerator FlashEffect()
    {
        int counttFl = 0;
        opColider.enabled = false;
        while (counttFl < flashNumbers)
        {

            trgSprtRend.color = plChangeCl;
            yield return new WaitForSeconds(flashDuration);
            trgSprtRend.color = plOriginalCl;
            yield return new WaitForSeconds(flashDuration);
            counttFl++;
        }
        opColider.enabled = true;
    }
    public IEnumerator RunMove(float durationMv)
    {
        if (currentPlState != PlayerState.move)
        {
            currentPlState = PlayerState.move;
            magicInventory.currentMagic--;
            WalikngAnimator();
        }

        yield return new WaitForSeconds(durationMv);
        currentPlState = PlayerState.idle;
    }
    public IEnumerator ThrowArrow(float durationMv)
    {
        if (currentPlState != PlayerState.arrow)
        {
            currentPlState = PlayerState.arrow;
            magicInventory.currentMagic--;
            WalikngAnimator();
        }

        yield return new WaitForSeconds(durationMv);
        currentPlState = PlayerState.idle;
    }
    private IEnumerator AutoShoot(float durationMv)
    {
        if (currentPlState != PlayerState.shoot)
        {
            currentPlState = PlayerState.shoot;
            magicInventory.currentMagic--;
            WalikngAnimator();
        }

        yield return new WaitForSeconds(durationMv);
        currentPlState = PlayerState.idle;
    }
}
