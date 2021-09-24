using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungRoomThree : MonoBehaviour
{
    //public Logs[] allDungLogs;
    public bool isDefeated;
    private int countDungLogs;
    public Signal dungLogsSignal;
    public int getAllCounts;
    public static DungRoomThree isDungRoomThreeClass;
    public GameObject virtualCamera;
    public bool isEntered = false;
    public List<Logs> allDungLogs;
    public List<Logs> TempAllDungLogs;
    public bool cameBackThree = false;
   public static DungRoomThree Instance(){ 
         if (!isDungRoomThreeClass)
         {
             isDungRoomThreeClass = FindObjectOfType(typeof(DungRoomThree)) as DungRoomThree;
         }
         return isDungRoomThreeClass;
         }
   void Start(){ 
     addElements(TempAllDungLogs);
   }      
    void Update()
    {
       if(dungLogsSignal != null){
            isEntered = true;
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
        if(other.CompareTag("Player") && other.isTrigger){
            
            virtualCamera.SetActive(true);
            if(TempAllDungLogs != null){
                if(dungLogsSignal != null){
                  removeElementPerSignal(TempAllDungLogs,dungLogsSignal.countSignals);
                }//new WaitForSeconds(2f);
                //activateLogs(TempAllDungLogs,true);
            } 
            if(cameBackThree && TempAllDungLogs.Count == 0){            
                 activateLogs(allDungLogs,true);
                 cameBackThree = false;
            }        
        }    
    }
    private void activateLogs(List<Logs> lgs, bool isActive){
        for (int i = 0; i < lgs.Count ; i++)
                {
                    logsStats(lgs[i], isActive);
                }
    }
    private void removeElementPerSignal(List<Logs> lgsT,int numSignal){
           for (int i = 0; i < numSignal; i++)
                {
                    lgsT.RemoveAt(i);
                }
    }
    private void addElements(List<Logs> lsLogs){
         for (int i = 0; i < 3; i++)
      {

           lsLogs.Add(new Logs());
           //TempAllDungLogs[i] = GameObject.Find($"LogDung{i}").AddComponent<Logs>();
      }
      if(lsLogs.Count > 0){
         for (int i = 0; i < lsLogs.Count; i++)
        {
          lsLogs[i] = GameObject.Find($"LogDung{i}").AddComponent<Logs>();  
        } 
      }
    }
    private void OnTriggerExit2D(Collider2D other){
        cameBackThree = true;
        if(other.name == "Player" && other.isTrigger){  
             virtualCamera.SetActive(false);
             if(allDungLogs != null){
                for (int i = 0; i < allDungLogs.Count; i++)
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
