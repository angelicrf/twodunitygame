using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speedArrow;
    public Rigidbody2D arrowRgd;
    public bool isDestroyed = false;
    void Start()
    {
        
    }
    public void throwArrow(Vector2 vlcity, Vector3 dirArrow){
        arrowRgd.velocity =  vlcity.normalized * speedArrow;
        transform.rotation = Quaternion.Euler(dirArrow);
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Log")){
            Destroy(other.gameObject);
        }
    }
}
