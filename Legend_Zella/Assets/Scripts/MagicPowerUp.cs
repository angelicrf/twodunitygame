using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPowerUp : PowerUpHeart
{
    public Inventory magicInventory;
    void Start()
    {
        
    }

  private void OnTriggerEnter2D(Collider2D other){
      if(other.CompareTag("Player")){
       
        if(magicInventory.currentMagic > 10){
          Destroy(this.gameObject);
        }
        else{
           powerUpSignal.hasSignal = true;
           powerUpSignal.ReadSignals();
        }
      }
  }
  
}
