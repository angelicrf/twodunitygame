using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Auto Arrow Throwing", menuName = "GenericChangeDirection/AutoArrow")]
public class AutoArrowThrowing : GenericChangeDirection
{
    [SerializeField] private GameObject arrowObject;
    public override void ChangePlDirection(Vector2 plPosition, Vector2 newPlDirection,
    Animator newAnim = null, Rigidbody2D newPlRigid = null)
    {
        Vector2 animPos = new Vector2(newAnim.GetFloat("moveX"), newAnim.GetFloat("moveY"));
        GameObject newArrowObj = Instantiate(arrowObject, plPosition, Quaternion.identity);
        GenericThrowableItem thrItm = newArrowObj.GetComponent<GenericThrowableItem>();
        if (thrItm)
        {
            Debug.Log("throwItem..");
            float calcPos = Mathf.Atan2(newAnim.GetFloat("moveY"), newAnim.GetFloat("moveX")) * Mathf.Rad2Deg;
            Vector3 tmpDirection = new Vector3(0f, 0f, calcPos);
            thrItm.ThrowItem(animPos, tmpDirection);
        }
    }
}
