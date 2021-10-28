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
        float calcPos = Mathf.Atan2(plPosition.y, plPosition.x) * Mathf.Rad2Deg;
        GameObject newArrowObj = Instantiate(arrowObject, plPosition, Quaternion.Euler(0f, 0f, calcPos));
    }
}
