using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
   public string sceneToDisplay;
   public Vector2 plTransit;
   public VectorTransitValue vcTransVal;
   public bool doPass;
   void OnTriggerEnter2D(Collider2D other){
       if(other.CompareTag("Player") && ! other.isTrigger){
            doPass = true;
            vcTransVal.isTransited = doPass;
            vcTransVal.transitionValue = plTransit;
            SceneManager.LoadScene(sceneToDisplay);
            
       }
   }
}
