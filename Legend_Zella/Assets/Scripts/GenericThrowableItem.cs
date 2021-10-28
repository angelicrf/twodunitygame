using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericThrowableItem : MonoBehaviour
{
    [SerializeField] private float throwSpeed;
    [SerializeField] private Rigidbody2D throwItem;

    void Start()
    {
        throwItem = gameObject.GetComponent<Rigidbody2D>();
    }
    public void ThrowItem(Vector2 itemDir, Vector3 itmPos)
    {
        if (throwItem)
        {
            throwItem.velocity = (itemDir.normalized * throwSpeed);
            //add
            throwItem.transform.rotation = Quaternion.Euler(itmPos);
        }
    }
}
