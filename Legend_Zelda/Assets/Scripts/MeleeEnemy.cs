using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Logs
{
    public bool isHitMelee = false;

    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRad
         &
        Vector3.Distance(target.position, transform.position) > attackRad)
        {

            if (currentEnState == EnemStates.idle || currentEnState == EnemStates.walk && currentEnState != EnemStates.stagger)
            {

                Vector3 tmpPos = Vector3.MoveTowards(transform.position, target.position, enmSpeed * Time.deltaTime);
                CalcAnimChange(tmpPos - transform.position);
                transform.position = Vector3.MoveTowards(transform.position, target.position, enmSpeed * Time.deltaTime);

            }
            else if (currentEnState == EnemStates.stagger && (currentEnState != EnemStates.walk || currentEnState != EnemStates.idle))
            {

                StartCoroutine(AttacKAnim());
            }
        }
    }
    IEnumerator AttacKAnim()
    {

        currentEnState = EnemStates.attack;
        enmAnim.SetBool("isAttacked", true);
        yield return new WaitForSeconds(1f);
        currentEnState = EnemStates.walk;
        enmAnim.SetBool("isAttacked", false);
    }
}
