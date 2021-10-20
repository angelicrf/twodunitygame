using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float force;
    public float knockTime;
    public float lossScore;
    private Rigidbody2D enemRgdBody;
    private PlayerMouvment playerMouvement;

    void Start()
    {
        playerMouvement = GameObject.Find("Player").GetComponent<PlayerMouvment>();
    }
    private IEnumerator ChangeVelocity(Rigidbody2D nRg)
    {
        yield return new WaitForSeconds(2f);
        nRg.velocity = Vector2.zero;
        nRg.isKinematic = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.gameObject.activeSelf)
        {
            if (other.gameObject.CompareTag("PotBreak"))
            {
                other.GetComponent<Pot>().SmashStart();
            }

            if (other.gameObject.CompareTag("Log") || other.gameObject.CompareTag("Player"))
            {
                enemRgdBody = other.GetComponent<Rigidbody2D>();
                if (enemRgdBody == null && !enemRgdBody.gameObject.CompareTag("Log"))
                {
                    enemRgdBody = playerMouvement.plRigid;
                }
                if (enemRgdBody.gameObject.CompareTag("Log") || enemRgdBody.gameObject.CompareTag("Player"))
                {

                    enemRgdBody.isKinematic = false;
                    Vector2 getDifference = enemRgdBody.transform.position - transform.position;

                    getDifference = getDifference.normalized * force;

                    enemRgdBody.AddForce(getDifference, ForceMode2D.Impulse);
                    if (other != null)
                    {
                        GameObject newPlayerObj = GameObject.Find("Player");
                        if (newPlayerObj != null)
                        {
                            if (newPlayerObj.activeSelf)
                            {
                                StartCoroutine(ChangeVelocity(enemRgdBody));
                            }
                        }
                    }

                    if (enemRgdBody != null && other.gameObject.activeSelf)
                    {

                        /*  if (other.gameObject.CompareTag("Log") && other.isTrigger && playerMouvement.currentPlState != PlayerMouvment.PlayerState.stagger && playerMouvement.currentPlState == PlayerMouvment.PlayerState.attack)
                         {
                             //Debug.Log("PlayerKillLog...");
                             playerMouvement.FlashEffect();
                             enemRgdBody.GetComponent<Oponent>().currentEnState = Oponent.EnemStates.stagger;
                             if (other.gameObject.name != "Ogre")
                             {
                                 other.GetComponent<Oponent>().CallEnemyStart(enemRgdBody, knockTime, lossScore, other);
                             }

                         } */
                        if (other.gameObject.CompareTag("Player") && !other.isTrigger && playerMouvement.currentPlState != PlayerMouvment.PlayerState.attack)
                        {
                            //Debug.Log("LogKillPlayer...");
                            playerMouvement.FlashEffect();
                            playerMouvement.currentPlState = PlayerMouvment.PlayerState.stagger;
                            playerMouvement.CallPlayerStart(knockTime, lossScore, other);
                            StartCoroutine(playerMouvement.KickAnimStart());

                        }
                    }
                }
            }
        }
    }
}
