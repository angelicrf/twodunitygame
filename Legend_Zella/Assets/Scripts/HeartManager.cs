using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public NumValues heartsContainer;
    public NumValues playerHealth;
    private float tmpHealth;
    public void Start()
    {
        ShowHearts();
    }
    public void FixedUpdate()
    {
        UpdateArray();
    }
    private void ShowHearts()
    {
        if (heartsContainer)
        {
            for (int i = 0; i < heartsContainer.numToUse; i++)
            {
                if (hearts != null)
                {
                    if (!hearts[i].gameObject.activeSelf)
                    {
                        if (i < hearts.Length)
                        {
                            hearts[i].gameObject.SetActive(true);
                            hearts[i].sprite = fullHeart;
                        }
                    }
                }
            }
        }
    }
    private float GetTmpHealth()
    {
        if (playerHealth)
        {
            tmpHealth = playerHealth.runTime / 2;
        }
        return tmpHealth;

    }
    public void UpdateArray()
    {
        float getResTmpHealth = GetTmpHealth();
        if (heartsContainer)
        {
            for (int i = 0; i < heartsContainer.numToUse; i++)
            {
                if (hearts != null)
                {
                    if (i <= hearts.Length)
                    {
                        hearts[i].gameObject.SetActive(true);
                        if (i <= getResTmpHealth - 1)
                        {
                            hearts[i].sprite = fullHeart;
                        }
                        else if (i > getResTmpHealth || getResTmpHealth == 0)
                        {
                            hearts[i].sprite = emptyHeart;
                        }
                        else if (getResTmpHealth != 0)
                        {
                            hearts[i].sprite = halfHeart;
                        }
                    }
                }
            }
        }
    }

}
