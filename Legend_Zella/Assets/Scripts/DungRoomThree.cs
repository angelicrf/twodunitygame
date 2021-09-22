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
   
   public static DungRoomThree Instance(){ 
         if (!isDungRoomThreeClass)
         {
             isDungRoomThreeClass = FindObjectOfType(typeof(DungRoomThree)) as DungRoomThree;
         }
         return isDungRoomThreeClass;
         }
   
    void Update()
    {
        destroyDungLogs();
    }
    private int destroyDungLogs(){
       if(dungLogsSignal.hasSignal){
         getAllCounts = dungLogsSignal.countSignals;   
        if(getAllCounts >= 3){
            isDefeated = true;
            return getAllCounts;
        }else{
            isDefeated = false;
        }
       }
       return getAllCounts;
    }

     private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") && ! other.isTrigger){
            for (int i = 0; i < allDungLogs.Length ; i++)
            {
                logsStats(allDungLogs[i], true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.name == "Player" && ! other.isTrigger){
          for (int i = 0; i < allDungLogs.Length; i++)
          {
              logsStats(allDungLogs[i], false);      
          }
        }
    }
    private void logsStats(Component allLogs, bool isSet){
      allLogs.gameObject.SetActive(isSet);
    } 

}
