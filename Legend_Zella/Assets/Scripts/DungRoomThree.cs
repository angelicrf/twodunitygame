using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungRoomThree : MonoBehaviour
{
    public Logs[] allDungLogs;
    public bool isDefeated;
    private int countDungLogs;
    public Signal dungLogsSignal;
    public int getAllCounts;
    public static DungRoomThree isDungRoomThreeClass;
    public GameObject virtualCamera;
    public bool isEntered = false;
   
   public static DungRoomThree Instance(){ 
         if (!isDungRoomThreeClass)
         {
             isDungRoomThreeClass = FindObjectOfType(typeof(DungRoomThree)) as DungRoomThree;
         }
         return isDungRoomThreeClass;
         }
   
    void Update()
    {
       if(dungLogsSignal != null){
        if(dungLogsSignal.hasSignal){
        destroyDungLogs();
          }
       }
    }
    private int destroyDungLogs(){    
        getAllCounts = dungLogsSignal.countSignals;   
        if(getAllCounts >= 3){
            isDefeated = true;
            return getAllCounts;
        }else{
            isDefeated = false;
        }
       return getAllCounts;
    }

     private void OnTriggerEnter2D(Collider2D other){
         //isEntered = (other.isTrigger);
        if(other.CompareTag("Player") && other.isTrigger){
            
            virtualCamera.SetActive(true);
            if(allDungLogs != null){
                for (int i = 0; i < allDungLogs.Length ; i++)
                {
                    logsStats(allDungLogs[i], true);
                }
            }         
        }    
    }
    private void OnTriggerExit2D(Collider2D other){
        //isEntered = false;
        if(other.name == "Player" && other.isTrigger){  
             virtualCamera.SetActive(false);
             if(allDungLogs != null){
                for (int i = 0; i < allDungLogs.Length; i++)
                {
                    logsStats(allDungLogs[i], false);      
                }
             }
        }
    }
    private void logsStats(Component allLogs, bool isSet){
      allLogs.gameObject.SetActive(isSet);
    } 

}
