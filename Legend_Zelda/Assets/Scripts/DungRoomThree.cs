using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungRoomThree : MonoBehaviour
{

    public bool isDefeated;
    public Signal dungLogsSignal;
    public int getAllCounts;
    public static DungRoomThree isDungRoomThreeClass;
    public GameObject virtualCamera;
    public bool isEntered = false;
    public List<Logs> allDungLogs;
    public List<Logs> TempAllDungLogs;
    public static DungRoomThree Instance()
    {
        if (!isDungRoomThreeClass)
        {
            isDungRoomThreeClass = FindObjectOfType(typeof(DungRoomThree)) as DungRoomThree;
        }
        return isDungRoomThreeClass;
    }
    void Start()
    {
        AddElements(TempAllDungLogs);
    }
    void Update()
    {
        if (dungLogsSignal != null)
        {
            isEntered = true;
            if (dungLogsSignal.hasSignal)
            {
                DestroyDungLogs();
            }
        }
    }
    private int DestroyDungLogs()
    {
        getAllCounts = dungLogsSignal.countSignals;
        if (getAllCounts >= 3)
        {
            isDefeated = true;
            return getAllCounts;
        }
        else
        {
            isDefeated = false;
        }
        return getAllCounts;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.isTrigger)
        {

            virtualCamera.SetActive(true);
            if (TempAllDungLogs != null)
            {
                if (dungLogsSignal != null)
                {
                    if (dungLogsSignal.hasSignal)
                    {
                        RemoveElementPerSignal(TempAllDungLogs, dungLogsSignal.countSignals);
                        //call func
                        //deactivateLootTable();
                    }
                    else
                    {
                        ActivateLogs(allDungLogs, true);
                    }
                }
            }
        }
    }
    private void DeactivateLootTable()
    {
        var ft = gameObject.GetComponent<Oponent>().DestroyEnemy();
    }
    private void ActivateLogs(List<Logs> lgs, bool isActive)
    {
        for (int i = 0; i < lgs.Count; i++)
        {
            LogsStats(lgs[i], isActive);
        }
    }
    private void RemoveElementPerSignal(List<Logs> lgsT, int numSignal)
    {

        for (int i = 0; i < numSignal; i++)
        {
            lgsT[i].gameObject.SetActive(false);
            lgsT.RemoveAt(i);

        }
    }
    private void AddElements(List<Logs> lsLogs)
    {
        for (int i = 0; i < 3; i++)
        {

            lsLogs.Add(new Logs());

        }
        if (lsLogs.Count > 0)
        {
            for (int i = 0; i < lsLogs.Count; i++)
            {
                lsLogs[i] = GameObject.Find($"LogDung{i}").AddComponent<Logs>();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player" && other.isTrigger)
        {
            virtualCamera.SetActive(false);
            dungLogsSignal.hasSignal = false;
            dungLogsSignal.countSignals = 0;
            if (allDungLogs != null)
            {
                for (int i = 0; i < allDungLogs.Count; i++)
                {
                    LogsStats(allDungLogs[i], false);
                    if (TempAllDungLogs != null)
                    {
                        if (TempAllDungLogs.Count > 0)
                        {
                            ActivateLogs(TempAllDungLogs, false);
                            //destroy animation       
                        }
                    }

                }
            }
        }
    }
    private void LogsStats(Component allLogs, bool isSet)
    {
        allLogs.gameObject.SetActive(isSet);
    }

}
