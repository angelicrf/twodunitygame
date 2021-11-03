using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{

    public void ClickNewGameBtn()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "MainScene")
        {
            SceneManager.LoadScene("StartMenu");
        }
        else if (currentScene.name == "StartMenu")
        {
            SceneManager.LoadScene("MainScene");
        }
    }
    public void ClickQuitGameBtn()
    {
        Application.Quit();
    }
}
