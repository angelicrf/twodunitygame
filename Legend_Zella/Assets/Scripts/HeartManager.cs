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
    private float tmpHealth;
    public void Start()
    {   
       ShowHearts();
    }
    private void ShowHearts(){
        for (int i = 0; i < heartsContainer.numToUse; i++){   
            if(!hearts[i].gameObject.activeSelf){
                hearts[i].gameObject.SetActive(true);
                hearts[i].sprite = fullHeart;
            }        
        }
    }
    private float GetTmpHealth(){
         tmpHealth = heartsContainer.numToUse / 2;  
         return tmpHealth;
    }
    public void UpdateArray(){
        Debug.Log("UpdateArray is called...");
     float getResTmpHealth = GetTmpHealth();
     Debug.Log("TmpHealth is " + getResTmpHealth);
        for (int i = 0; i < heartsContainer.numToUse; i++)
        {
            Debug.Log("InsideUpdate..");
           if(!hearts[i].gameObject.activeSelf){
                hearts[i].gameObject.SetActive(true); 
                if(i <= getResTmpHealth){
                    Debug.Log("FullHeart..");
                    hearts[i].sprite = fullHeart;
                 }
                 else if(i > getResTmpHealth){
                     Debug.Log("EmptyHeart..");
                     hearts[i].sprite = emptyHeart;
                 }else{
                     Debug.Log("HalfHear...");
                     hearts[i].sprite = halfHeart;
                  }
                }
         }    
    }
 
}
