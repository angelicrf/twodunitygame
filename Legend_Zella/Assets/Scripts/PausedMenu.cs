using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public GameObject pausedPanel;
    public bool isPaused = false;

    void Update()
    {
       putPauseGame();             
    }
    public void putPauseGame(){
        isPaused = !isPaused;
         if(Input.GetButtonDown("pause")){  
            if(isPaused){
            pausedPanel.SetActive(true);
            Time.timeScale = 0f;
            }else{
                pausedPanel.SetActive(false);
                Time.timeScale = 1.5f;
            }
        }  
    }
    public void toQuiteGame(){
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1.5f;
    }

}
