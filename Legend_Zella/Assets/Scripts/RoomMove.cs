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
    public Rigidbody2D mvRigid;
    private PlayerMouvment playerMouvement;
    private Vector2 dspMins;
    private Vector2 dspMaxs;
    private Camera camera2;
    private Vector2 camPos;
    private int countPool = 0;
    void Start()
    { 
        playerMouvement = GetComponent<PlayerMouvment>();
        
        mvRigid = playerMouvement.plRigid;
        //GetComponent<Rigidbody2D>();            
    }

    void FixedUpdate()
    {
        ChangeStats();
    }
    private void ChangeStats(){
        Debug.Log("before ChangeStats...");
        camera2 = GameObject.Find("Main Camera").GetComponent<Camera>();
        //CameraMovement cv = new CameraMovement(new Vector2(5,3),new Vector2(10,1));
        //dspMins += cv.MinValues;
        //dspMaxs += cv.MinValues;
        CameraMovement vb = new CameraMovement();
        dspMins = vb.TestMethMins();
        dspMaxs = vb.TestMethMaxs();
        //Debug.Log("Constructor Called2..." + dspMins);
        //Debug.Log("constructor called.." +  dspMaxs);
        //set camera position
        OnTriggerEnter2D();
    }
    private void OnTriggerEnter2D(){
            Debug.Log("collision happened...");
             //playerMouvement.transform.position += playerChange;
            if (textNeeded){
                 StartCoroutine (displayText());
            }
    }
    private IEnumerator displayText(){
        camPos = camera2.transform.position;
        newTextObj.SetActive(true);
         Debug.Log("CamposX-Y is " + camPos);
         if(camPos.x >= 8){
             replaceText = "Pool Area";
             placeText.text = replaceText;
             //if condition
             if(countPool == 0){
             changeAllPos();
             yield return new WaitForSeconds(4f);
             newTextObj.SetActive(false);
             textNeeded = true;
             }else{
              textNeeded = true;
              yield return new WaitForSeconds(4f);
              newTextObj.SetActive(false);
             }             

        }else{
            placeText.text = "Home Area";
            yield return new WaitForSeconds(4f);
            newTextObj.SetActive(false);
        } 
   }
   private void changeAllPos(){ 
        GameObject.Find("Main Camera").GetComponent<Camera>().enabled = false;
        GameObject.Find("Player").GetComponent<PlayerMouvment>().enabled = false;
        GameObject.Find("Main Camera").GetComponent<Camera>().transform.position = new Vector3(12 , 6, -10);
        GameObject.Find("Player").GetComponent<PlayerMouvment>().plRigid.transform.position = new Vector3(12, 6, -6);
        GameObject.Find("Player").GetComponent<PlayerMouvment>().enabled = true;
        GameObject.Find("Main Camera").GetComponent<Camera>().enabled = true;
        textNeeded = false;
        countPool++;
   }
}
