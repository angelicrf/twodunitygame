using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement camera; 
    void Start()
    {
        camera = Camera.main.GetComponent<CameraMovement>();
    }

    void Update()
    {
        Collider2D cl2d = new Collider2D();
        OnTriggerEnter2D(cl2d);
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            camera.minPos += cameraChange;
            camera.maxPos += cameraChange; 
            other.transform.position += playerChange;
        }
    }
}
