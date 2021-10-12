using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speedArrow;
    public Rigidbody2D arrowRgd;
    public bool isDestroyed = false;
    public GameObject deathEffect;
    public Signal magicSignal;
    public float lifeTime;
    private float lifeTimeCopy;
    public float magicCost;

    void Start()
    {
        lifeTimeCopy = lifeTime;
    }
    void Update()
    {
        lifeTimeCopy -= Time.deltaTime;
        //set timer to have more-less time destroy arrows
        if (lifeTimeCopy <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void ThrowArrow(Vector2 vlcity, Vector3 dirArrow)
    {
        arrowRgd.velocity = vlcity.normalized * speedArrow;
        transform.rotation = Quaternion.Euler(dirArrow);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Log"))
        {
            SetpsArrow(other);
        }
    }
    private void SetpsArrow(Collider2D other)
    {
        Destroy(other.gameObject);
        deathEffect.SetActive(true);
        deathEffect.transform.position = other.transform.position;
        Instantiate(deathEffect, other.transform.position, Quaternion.identity);

        deathEffect.SetActive(false);
        if (magicSignal != null)
        {
            magicSignal.hasSignal = true;
            magicSignal.ReadSignals();
        }
    }

}
