using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralProjectile : BallProjectile
{
    private float extendedTime;
    // Start is called before the first frame update
    void Start()
    {
        extendedTime = durationTime;
    }
    void Update()
    {
        extendedTime -= Time.deltaTime;
        if(extendedTime <= 0){
            Destroy(this.gameObject);
        }
        
    }
    public void checkBallVelocity(Vector2 newVelocity){
        ballRidgid.velocity = newVelocity * timeSpeed;
    }
}
