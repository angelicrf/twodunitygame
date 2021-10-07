using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove :  MonoBehaviour
{
    public Vector3 playerChange;
    //private CameraMovement cam; 
    public bool textNeeded;
    public string replaceText;
    public Text placeText;
    public GameObject newTextObj;
    //private Rigidbody2D mvRigid;
    private PlayerMouvment playerMouvement;
    public Vector3 dspMins;
    private Camera camera2;
    private Vector2 camPos;
    private int countPool = 0;
    //public Signal roomChangeSignal;
  
    void Start()
    { 
        playerMouvement = GameObject.Find("Player").GetComponent<PlayerMouvment>();        
        //mvRigid = playerMouvement.plRigid;           
    }

     void FixedUpdate()
    {
        ChangeStats();
    } 
    private void ChangeStats(){
     
        camera2 = GameObject.Find("Main Camera").GetComponent<Camera>();
        
    }
    private void OnTriggerEnter2D(Collider2D other){
            if (textNeeded ){
                if(other.CompareTag("Player") && ! other.isTrigger){
                 StartCoroutine (areaChangeMSG());
                }
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
            //roomChangeSignal.ReadSignals();
            //roomChangeSignal.hasSignal = true;
            newTextObj.SetActive(true);
              changeAllPos();
              chooseOptions();
              yield return new WaitForSeconds(4f);
              newTextObj.SetActive(false);
   }
   private void chooseOptions(){
       if(textNeeded){
        placeText.text = replaceText;
          switch(replaceText) {
                case "Pool Area":
                        changeColor(255, 0, 0, 1);
                    break;
                case "Home Area":
                        changeColor(0, 0, 128, 1);
                    break;
                case "HomeStead":
                        changeColor(0, 255, 255, 1);
                    break;
                case "BackYard":
                        changeColor(128, 128, 128, 1);
                    break;       
                default:
                        changeColor(255, 255, 0, 1);
                     break;
                }
         }
            
   }
   private void changeColor(byte a, byte b, byte c, byte d){
        placeText.color = new Color(a,b,c,d);
   }
   private void changeAllPos(){ 
        camera2.transform.position = dspMins;
        playerMouvement.plRigid.transform.position = playerChange; 
   }
    
}
