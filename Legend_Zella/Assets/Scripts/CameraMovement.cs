using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    // = GameObject.Find("Player").transform;
    public Vector3 cameraChange;
    public float smoothing;
    private Vector3 camNewPos;

    public CameraMovement(){}

   public Vector3 ChangeCamPos(){
       return camNewPos = new Vector3(cameraChange.x,cameraChange.y, cameraChange.z);
   }
 
    void LateUpdate()
    { 
        // Camera cam = Camera.main;
       if(transform.position != target.position){
           Vector3 targetPst = new Vector3(target.position.x,
            target.position.y, transform.position.z);
            //targetPst.x = Mathf.Clamp(targetPst.x, minPos.x, maxPos.x);
            //targetPst.y = Mathf.Clamp(targetPst.y, minPos.y, maxPos.y);
            //if(GameObject.Find("Main Camera").GetComponent<Camera>().transform.position.x < 8)
            transform.position = Vector3.Lerp(transform.position,targetPst,smoothing);     
       } 
    }
}
