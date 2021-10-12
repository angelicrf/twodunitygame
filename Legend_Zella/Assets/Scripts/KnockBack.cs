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
    private Oponent oponent;
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
        if (other != null)
        {
            if (other.gameObject.CompareTag("PotBreak"))
            {
                other.GetComponent<Pot>().SmashStart();
            }

            if (other.gameObject.CompareTag("Log") || other.gameObject.CompareTag("Player"))
            {
                enemRgdBody = other.GetComponent<Rigidbody2D>();
                if (enemRgdBody == null || !enemRgdBody.gameObject.CompareTag("Log"))
                {
                    enemRgdBody = playerMouvement.plRigid;
                }
                if (enemRgdBody.gameObject.CompareTag("Log") || enemRgdBody.gameObject.CompareTag("Player"))
                {

                    enemRgdBody.isKinematic = false;
                    Vector2 getDifference = enemRgdBody.transform.position - transform.position;

                    getDifference = getDifference.normalized * force;

                    enemRgdBody.AddForce(getDifference, ForceMode2D.Impulse);
                    StartCoroutine(ChangeVelocity(enemRgdBody));

                    if (enemRgdBody != null)
                    {
                        if (other.CompareTag("Log") && other.isTrigger)
                        {
                            Debug.Log("PlayerkillLog....");
                            enemRgdBody.GetComponent<Oponent>().currentEnState = Oponent.EnemStates.stagger;
                            if (other.gameObject.name != "Ogre")
                            {
                                other.GetComponent<Oponent>().CallEnemyStart(enemRgdBody, knockTime, lossScore);
                            }
                        }
                        if (other.CompareTag("Player") && playerMouvement.currentPlState != PlayerMouvment.PlayerState.stagger)
                        {
                            Debug.Log("LogKillPlayer...");
                            playerMouvement.currentPlState = PlayerMouvment.PlayerState.stagger;
                            playerMouvement.CallPlayerStart(knockTime, lossScore);
                            StartCoroutine(playerMouvement.KickAnimStart());

                        }
                    }
                }
            }
        }
    }
}
