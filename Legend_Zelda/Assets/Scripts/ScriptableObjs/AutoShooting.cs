using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AutoShooting", menuName = "PlayerDirection/AutoShooting")]
public class AutoShooting : GenericChangeDirection
{
    [SerializeField] private GameObject ballObject;
    [SerializeField] private int numberShoot;
    [SerializeField] private float angleshoot;
    public override void ChangePlDirection(Vector2 plPosition, Vector2 newPlDirection,
    Animator newAnim = null, Rigidbody2D newPlRigid = null)
    {

        Vector2 animPos = new Vector2(newAnim.GetFloat("moveX"), newAnim.GetFloat("moveY"));

        float calcPos = Mathf.Atan2(newAnim.GetFloat("moveY"), newAnim.GetFloat("moveX")) * Mathf.Rad2Deg;
        float startItemRot = ((calcPos + angleshoot) / 2f);
        float angleIncrease = (calcPos / (numberShoot - 1f));

        for (int i = 0; i < numberShoot; i++)
        {
            GameObject newBallObj = Instantiate(ballObject, plPosition, Quaternion.identity);
            GenericThrowableItem thrItm = newBallObj.GetComponent<GenericThrowableItem>();
            if (thrItm)
            {
                float tempRot = (startItemRot - angleIncrease) * i;
                Vector3 tmpDirection = new Vector3(0f, 0f, tempRot);
                thrItm.ThrowItem(new Vector2(Mathf.Cos(tempRot * Mathf.Deg2Rad), Mathf.Sin(tempRot * Mathf.Deg2Rad)), tmpDirection);
            }

        }
    }
}
