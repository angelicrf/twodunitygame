using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTextClue : MonoBehaviour
{
    public GameObject textToAsk;
    
    public void Enable(){
        textToAsk.SetActive(true);
    }
    public void Disable(){
        textToAsk.SetActive(false);
    }
}
