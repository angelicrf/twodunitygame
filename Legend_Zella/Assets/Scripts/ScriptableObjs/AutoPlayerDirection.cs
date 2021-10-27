using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "AutoPlayerDirection", menuName = "PlayerDirection/AutoPlayerDirection")]
public class AutoPlayerDirection : GenericChangeDirection
{
    public float directionForce;
    public override void ChangePlDirection(Vector2 plPosition, Vector2 newPlDirection,
    Animator newAnim, Rigidbody2D newPlRigid)
    {
        if (plMagicValue)
        {
            if (plMagicValue.runTime >= magicCost)
            {
                plMagicValue.runTime -= magicCost;
                if (plMagicValue.runTime < 0)
                {
                    plMagicValue.runTime = 0;
                }
                plMagicSignal.ReadSignals();
            }
            else
            {
                return;
            }
            if (newPlRigid)
            {
                Vector3 newDir = newPlRigid.transform.position + (Vector3)newPlDirection.normalized * directionForce;
                newPlRigid.DOMove(newDir, durationChange);
            }
        }
    }
}
