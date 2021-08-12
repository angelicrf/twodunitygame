using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector3 cameraChange;
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
        //Debug.Log("before ChangeStats...");
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
    }
    private void OnTriggerEnter2D(){
            if (textNeeded){
                 StartCoroutine (areaChangeMSG());
            }     
    }
    private IEnumerator displayText(){
        camera2 = GameObject.Find("Main Camera").GetComponent<Camera>();
        camPos = camera2.transform.position;
        newTextObj.SetActive(true);
         if(camPos.x >= 6){
             replaceText = "Pool Area";
             placeText.text = replaceText;
             //if condition
             if(countPool == 0){
             //changeAllPos();
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
   private IEnumerator areaChangeMSG(){
            newTextObj.SetActive(true);
             placeText.text = replaceText;
              if(placeText.text == "Pool Area"){
                  placeText.color = Color.red;
                  changeAllPos();
                  yield return new WaitForSeconds(4f);
                  newTextObj.SetActive(false);
             }
             if(placeText.text == "Home Area"){
                 placeText.color = Color.yellow;
                 changeAllPos();
                 yield return new WaitForSeconds(4f);
                 newTextObj.SetActive(false);
             } 
   }
   private void changeAllPos(){ 
        GameObject.Find("Main Camera").GetComponent<Camera>().transform.position = cameraChange;
        GameObject.Find("Player").GetComponent<PlayerMouvment>().plRigid.transform.position = playerChange; 
   }
 
}
