using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logs : Oponent
{
    public Transform target;
    public float chaseRad;
    public float attackRad;
    public Animator enmAnim;
    public Vector3 originalPos;
    private float newPos;
    public Signal kickSignal;
    void Start()
    {
        if (kickSignal)
        {
            kickSignal.hasSignal = false;
            kickSignal.countSignals = 0;
        }
        enmAnim = GetComponent<Animator>();
        currentEnState = EnemStates.idle;
        enmAnim.SetBool("isWokeUp", true);
    }

    void FixedUpdate()
    {
        newPos = Vector3.Distance(target.transform.position, transform.position);
        CheckDistance();
    }
    public virtual void CheckDistance()
    {
        if (newPos <= chaseRad & newPos > attackRad)
        {
            if (currentEnState == EnemStates.idle || currentEnState == EnemStates.walk && currentEnState != EnemStates.stagger)
            {
                enmAnim.SetBool("isWokeUp", true);
                Vector3 tmpPos = Vector3.MoveTowards(transform.position, target.position, enmSpeed * Time.deltaTime);
                CalcAnimChange(tmpPos - transform.position);
                transform.position = Vector3.MoveTowards(transform.position, target.position, enmSpeed * Time.deltaTime);
                ChangeLgState(EnemStates.walk);
            }
            if (kickSignal)
            {
                if (kickSignal.hasSignal && kickSignal.countSignals > 5)
                {
                    enmAnim.SetBool("isWokeUp", false);
                    ChangeLgState(EnemStates.idle);
                }
            }
        }
        else if (newPos > chaseRad)
        {
            enmAnim.SetBool("isWokeUp", false);
        }
    }
    private void SetAnimPos(Vector2 setPos)
    {
        enmAnim.SetFloat("moveX", setPos.x);
        enmAnim.SetFloat("moveY", setPos.y);
    }
    public void CalcAnimChange(Vector2 tmpRes)
    {
        if (Mathf.Abs(tmpRes.x) > Mathf.Abs(tmpRes.y))
        {
            if (tmpRes.x > 0)
            {
                SetAnimPos(Vector2.right);
            }
            else if (tmpRes.x < 0)
            {
                SetAnimPos(Vector2.left);
            }
        }
        else if (Mathf.Abs(tmpRes.x) < Mathf.Abs(tmpRes.y))
        {

            if (tmpRes.y > 0)
            {
                SetAnimPos(Vector2.up);
            }
            else if (tmpRes.y < 0)
            {
                SetAnimPos(Vector2.down);
            }
        }
    }
    public void ChangeLgState(EnemStates newSt)
    {
        if (currentEnState != newSt)
        {
            currentEnState = newSt;
        }
    }

}
