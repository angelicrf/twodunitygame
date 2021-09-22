using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class ConditionalRoomMove : MonoBehaviour
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
    public Rigidbody2D mvRigid;
    public Signal roomChangeSignal;
    private DungRoomThree dngThree;
    private DungDoor dngGeneral;
    public bool firstStep = false;
    private bool isInRoomThree;
    void Start()
    { 
        playerMouvement = GameObject.Find("Player").GetComponent<PlayerMouvment>();        
        mvRigid = playerMouvement.plRigid; 
        dngThree = DungRoomThree.Instance();
        dngGeneral = DungDoor.Instance(); 
    }

     void FixedUpdate()
    {
        isInRoomThree = dngThree.isDefeated;
        ChangeStats();
    } 
    private void ChangeStats(){
     
        camera2 = GameObject.Find("Main Camera").GetComponent<Camera>();
        
    }
    private void OnTriggerEnter2D(Collider2D other){
        //check some conditions
            if (textNeeded){
                StartCoroutine(lastStep());
            }     
    }
  
   private void execSomeConds(){     
       //get approval from different rooms
      bool roomThreeApproved = isInRoomThree;
      bool roomTwoApproval = dngGeneral.getChangeDoorSignal.hasSignal;
      bool roomOneApproval = dngGeneral.dungDoorSignal.hasSignal;

       if(roomOneApproval || roomTwoApproval || roomThreeApproved ){
             partTwoSteps();
       }             
   }
  private void partTwoSteps(){  
       newTextObj.SetActive(true);  
       changeAllPos();
       chooseOptions();
  } 
  private bool areaChangeRooms(){
       bool hlSignal = false;
            roomChangeSignal.ReadSignals();
            roomChangeSignal.hasSignal = true;
            hlSignal = roomChangeSignal.hasSignal;
            return hlSignal;
  }
  private IEnumerator lastStep(){ 
      bool resultSignalConds = areaChangeRooms();
      //bool resultSignalNoConds = !areaChangeRooms();

      if(resultSignalConds){
        execSomeConds();
        yield return new WaitForSeconds(2f);
        newTextObj.SetActive(false); 
        //change signal to off
        roomChangeSignal.hasSignal = false;
        roomChangeSignal.countSignals = 0;
        
        dngThree.dungLogsSignal.hasSignal = false;
        dngThree.getAllCounts = 0;
      }
     /*  if(resultSignalNoConds){
         partTwoSteps();
         yield return new WaitForSeconds(2f);
         newTextObj.SetActive(false);
      } */
           
   } 
/*    private async void stepsTask(){
        //await Task.Run(() => areaChangeMSG());
        areaChangeMSG();
        await Task.Run(() => execSomeConds());
        StartCoroutine(lastStep());
        //await Task.Run(() => StartCoroutine(lastStep()));
   } */
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
        GameObject.Find("Main Camera").GetComponent<Camera>().transform.position = dspMins;       
        GameObject.Find("Player").GetComponent<PlayerMouvment>().plRigid.transform.position = playerChange; 
   }
}
