using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [CreateAssetMenu]
public class LootTable : ScriptableObject
{
  [System.Serializable]
  public class Loot{
      public GameObject lootObj;
      public int cmCount;
  } 

  public Loot[] loots;
  public GameObject pwH(){
      if(loots != null){
         int probCount = 0;
         int currentProb = Random.Range(0,100);
          for (int i = 0; i < loots.Length; i++)
          {
           probCount += loots[i].cmCount;       
            if(currentProb <= probCount){
                return loots[i].lootObj;
            } 
          }
      }
      return null;
  }

}
