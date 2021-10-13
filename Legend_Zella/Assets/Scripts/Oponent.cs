using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oponent : MonoBehaviour
{
    public enum EnemStates { idle, walk, stagger, attack };
    public NumValues maxNum;
    public GameObject deathEffect;
    public float healthOk;
    public int attackBase;
    public float enmSpeed;
    public string enemName;
    public Signal dungDefeatSignal;
    public LootTable lootTable;
    public Rigidbody2D ptLogRigid;
    //private GameObject lootObj;
    public GameObject coindIdle;
    public GameObject heartIdle;
    private Vector3 storeTrPos;

    private void Awake()
    {
        if (maxNum != null)
        {
            healthOk = maxNum.numToUse;
        }
    }
    public EnemStates currentEnState;

    public void CallEnemyStart(Rigidbody2D enmRigid, float timeBack, float damage)
    {

        StartCoroutine(EnemyStart(enmRigid, timeBack, damage));
    }
    private void ChangeHealthScore(float damage)
    {
        storeTrPos = transform.position;
        healthOk -= damage;
        if (healthOk <= 0)
        {
            CallStepsToKill(storeTrPos);
        }
    }
    private IEnumerator CallLootTable(Vector3 trF)
    {
        if (lootTable != null)
        {
            coindIdle.SetActive(true);
            heartIdle.SetActive(true);
            GameObject lootObj = lootTable.pwH();
            lootObj.SetActive(true);
            Instantiate(lootObj, trF, Quaternion.identity);
            //promise
            yield return new WaitForSeconds(5f);
            DestroyObjects(lootObj);
        }
    }
    public IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1f);
        // destroy obj of DeatEffect
        yield return new WaitForSeconds(2f);
        // destroy obj of lootTable
        dungDefeatSignal.ReadSignals();
        this.gameObject.SetActive(false);
    }
    public void DestroyDeathEffect()
    {
        deathEffect.SetActive(false);
    }
    public IEnumerator GenerateDeathEffect(Vector3 trP)
    {
        deathEffect.SetActive(true);
        GameObject tfg = Instantiate(deathEffect, trP, Quaternion.identity);
        //promise
        yield return new WaitForSeconds(5f);
        DestroyObjects(tfg);
    }
    private void DestroyObjects(GameObject gmO)
    {
        Destroy(gmO, 3f);
    }
    IEnumerator EnemyStart(Rigidbody2D enmRigid, float timeBack, float damage)
    {
        if (enmRigid != null)
        {

            yield return new WaitForSeconds(timeBack);

            enmRigid.velocity = Vector2.zero;
            enmRigid.isKinematic = true;
            currentEnState = EnemStates.idle;
            enmRigid.velocity = Vector2.zero;
            ChangeHealthScore(damage);

        }
    }
    private void CallStepsToKill(Vector3 storeTrPos)
    {
        this.gameObject.SetActive(false);
        StartCoroutine(GenerateDeathEffect(storeTrPos));
        StartCoroutine(CallLootTable(storeTrPos));
    }
}
