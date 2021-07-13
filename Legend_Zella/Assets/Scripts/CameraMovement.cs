using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 minPos;
    public Vector2 maxPos;
    void Start()
    {
        
    }

    void LateUpdate()
    {
       if(transform.position != target.position){
           Vector3 targetPst = new Vector3(target.position.x, target.position.y, transform.position.z);
           targetPst.x = Mathf.Clamp(targetPst.x, minPos.x, maxPos.x);
           targetPst.y = Mathf.Clamp(targetPst.y, minPos.y, maxPos.y);
           transform.position =  Vector3.Lerp(transform.position,
           targetPst,smoothing);
     
       } 
    }
}
