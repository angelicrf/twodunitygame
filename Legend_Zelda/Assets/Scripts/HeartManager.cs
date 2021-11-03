using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    //public Image[] hearts;
    public Image oneHeart;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public NumValues heartsContainer;
    public NumValues playerHealth;
    private float tmpHealth;
    public List<Image> hearts = new List<Image>();
    public GameObject mainHeartContainer;
    public GameObject addChildObject;
    public void Start()
    {
        //ShowHearts();
    }
    public void FixedUpdate()
    {
        UpdateArray();
    }
    private void ShowHearts()
    {
        if (heartsContainer)
        {
            for (int i = 0; i < hearts.Count; i++)
            {
                if (hearts != null)
                {
                    if (!hearts[i].gameObject.activeSelf)
                    {

                        hearts[i].gameObject.SetActive(true);
                        hearts[i].sprite = fullHeart;
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
            if (hearts != null)
            {
                for (int i = 0; i < heartsContainer.runTime; i++)
                {

                    if (i <= hearts.Count - 1)
                    {
                        hearts[i].gameObject.SetActive(true);
                        /* if (i <= getResTmpHealth - 1)
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
                        } */
                    }
                    else
                    {
                        AddHearts();
                        hearts[i].gameObject.SetActive(true);
                    }

                }
            }
        }
    }
    private void AddHearts()
    {
        GameObject duplicateHeart = Instantiate(addChildObject);
        duplicateHeart.transform.SetParent(mainHeartContainer.transform);
        hearts.Add(oneHeart);
    }
}
