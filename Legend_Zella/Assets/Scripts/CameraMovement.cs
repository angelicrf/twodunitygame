using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour, NewInterFace
{
    public Transform target;
    public float smoothing;
    public Vector2 minPos;
    public Vector2 maxPos;
    private string dspText;
    public CameraMovement(){}
    public CameraMovement(Vector2 mnP, Vector2 mxP){
        minPos = mnP;
        maxPos = mxP;
    }
     public Vector2 MinValues
    {
        get { return minPos; }
    } 
    public Vector2 MaxValue { 
        get {return maxPos;}
    }
     public Vector2 GetMins()
    {
        //Debug.Log("DID Min! from CameraMouvement ..." + MinValues);
        return minPos;
    }
    public Vector2 GetMaxs(){
        //Debug.Log("DID Max! from CameraMouvement ... " + MaxValue);
       return maxPos;
    }
    void Start()
    {
         
    }
   public Vector2 TestMethMins(){
       return minPos = new Vector2(10,1);
   }
   public Vector2 TestMethMaxs(){
       return maxPos = new Vector2(3,1);
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
