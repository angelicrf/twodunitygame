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
   public GameObject fadedEffect;
   public float fadeWaiteDur;

    public void Awake(){
        if(fadedEffect != null){
            GameObject fdEffect = Instantiate(fadedEffect, Vector2.zero , Quaternion.identity);
            Destroy(fdEffect , 1);
        }
    }
   void OnTriggerEnter2D(Collider2D other){
       if(other.CompareTag("Player") && ! other.isTrigger){
            doPass = true;
            vcTransVal.isTransited = doPass;
            vcTransVal.transitionValue = plTransit;
            StartCoroutine(FadeOut());         
       }
   }
   private IEnumerator FadeOut(){
      if(fadedEffect != null){
          Instantiate(fadedEffect, Vector2.zero, Quaternion.identity);
          yield return new WaitForSeconds(fadeWaiteDur);
          AsyncOperation asyncOpt = SceneManager.LoadSceneAsync(sceneToDisplay);
          while(! asyncOpt.isDone){
              yield return null;
          }
      }
   }
}
