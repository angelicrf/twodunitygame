using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
   
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void clickNewGameBtn(){
      SceneManager.LoadScene("MainScene");
    }
    public void clickQuitGameBtn(){
        Application.Quit();
    }
}
