using UnityEngine;

public class EnemyLog : Logs
{
    public bool isPassed;
    public GameObject ballRidgid2;
    public Vector2 distanceBall;
    public float setTimer;
    private float newSetTimer;
    public NumValues playerHealthValue;
    void Start()
    {
        isPassed = true;
        playerHealthValue.runTime = playerHealthValue.numToUse;
        if (!ballRidgid2.activeSelf)
        {
            ballRidgid2 = GameObject.Find("BouncingBall");
            ballRidgid2.SetActive(true);
        }

    }

    void Update()
    {
        newSetTimer -= Time.deltaTime;
        if (newSetTimer <= 0)
        {
            isPassed = true;
            newSetTimer = setTimer;
        }

    }
    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRad
         &
        Vector3.Distance(target.position, transform.position) > attackRad)
        {
            if (currentEnState == EnemStates.idle || currentEnState == EnemStates.walk && currentEnState != EnemStates.stagger)
            {
                if (isPassed && playerHealthValue.runTime != 0)
                {
                    distanceBall = target.position - transform.position;
                    CalcAnimChange(distanceBall);
                    GameObject instanceBall = Instantiate(ballRidgid2, transform.position, Quaternion.identity);
                    isPassed = false;
                    instanceBall.GetComponent<GeneralProjectile>().CheckBallVelocity(distanceBall);
                    ChangeLgState(EnemStates.walk);

                    SetBoolAnim("isWokeUp", enmAnim, true);
                }
                else if (playerHealthValue.runTime == 0)
                {

                    SetBoolAnim("isWokeUp", enmAnim, false);
                }
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRad)
        {

            SetBoolAnim("isWokeUp", enmAnim, false);
        }
    }
}
