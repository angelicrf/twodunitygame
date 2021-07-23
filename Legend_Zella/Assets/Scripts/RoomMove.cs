using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam; 
    public bool textNeeded;
    public string replaceText;
    public Text placeText;
    public GameObject newTextObj;
    private PlayerMouvment rig2d;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
        //rig2d = GetComponent<PlayerMouvment>();
    
    }

    void FixedUpdate()
    {
        OnTriggerEnter2D();
    }
    private void OnTriggerEnter2D(){
      
            Debug.Log("collision happened..");
            cam.minPos += cameraChange;
            cam.maxPos += cameraChange; 
            //plrMvn.transform.position += playerChange;
            if (textNeeded){
                 StartCoroutine (displayText());
            }
        
    }
    private IEnumerator displayText(){
        newTextObj.SetActive(true);
        placeText.text = replaceText;
        yield return new WaitForSeconds(4f);
        newTextObj.SetActive(false);

    }
}
