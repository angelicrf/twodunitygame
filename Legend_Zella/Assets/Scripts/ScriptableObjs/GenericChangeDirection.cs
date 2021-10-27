using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Generic Change Direction", menuName = "GenericChangeDirection/New Direction")]
public class GenericChangeDirection : ScriptableObject
{
    public float durationChange;
    public float magicCost;
    public NumValues plMagicValue;
    public Signal plMagicSignal;

    public virtual void ChangePlDirection(Vector2 plPosition, Vector2 newPlDirection,
    Animator newAnim = null, Rigidbody2D newPlRigid = null)
    {

    }
}
