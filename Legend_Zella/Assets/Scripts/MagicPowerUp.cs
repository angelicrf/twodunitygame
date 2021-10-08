using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPowerUp : PowerUpHeart
{
    public Inventory magicInventory;
    public float magicValue;
    public Signal arrowSignal;
    void Start()
    {
        
    }

  private void OnTriggerEnter2D(Collider2D other){
      if(other.CompareTag("Player") && arrowSignal.hasSignal){
       
        if(magicInventory.currentMagic > 14){
          Destroy(this.gameObject);
        }
        else{
           magicInventory.currentMagic += magicValue;
           powerUpSignal.hasSignal = true;
           powerUpSignal.ReadSignals();
        }
      }
  }
  
}
