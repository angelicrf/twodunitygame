using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraChange;
    public float smoothing;
    private Vector3 camNewPos;

    public Vector3 ChangeCamPos()
    {
        return camNewPos = new Vector3(cameraChange.x, cameraChange.y, cameraChange.z);
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Camera cam = Camera.main;
            if (transform.position != target.position)
            {
                Vector3 targetPst = new Vector3(target.position.x,
                target.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPst, smoothing);
            }
        }
    }
}
