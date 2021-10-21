using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public GameObject pausedPanel;
    public GameObject inventoryPanel;
    public bool isPaused = false;

    void Update()
    {
        PutPauseGame();
    }
    public void PutPauseGame()
    {
        isPaused = !isPaused;

        if (Input.GetButtonDown("pause"))
        {
            if (isPaused)
            {
                pausedPanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pausedPanel.SetActive(false);
                Time.timeScale = 1.5f;
            }
        }
        if (Input.GetButtonDown("invPanel"))
        {
            if (isPaused)
            {
                inventoryPanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                inventoryPanel.SetActive(false);
                Time.timeScale = 1.5f;
            }
        }
    }
    public void ToQuiteGame()
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
        Time.timeScale = 1.5f;
    }

}
