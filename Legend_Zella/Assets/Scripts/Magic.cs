using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magic : MonoBehaviour
{
    public Slider magicSlider;
    public Inventory invMagic;
    void Start()
    {
        magicSlider.maxValue = invMagic.maxMagic;
        magicSlider.minValue = 0;
        magicSlider.value = invMagic.maxMagic;
        invMagic.currentMagic = invMagic.maxMagic;
    }
    void FixedUpdate(){
         magicSlider.value = invMagic.currentMagic;
    }

    public void decreaseMagic(){
        if(magicSlider.value > magicSlider.maxValue){
            magicSlider.value = magicSlider.maxValue;
            invMagic.currentMagic = invMagic.maxMagic;
        }
    }
    public void increaseMagic(){
      if(magicSlider.value < magicSlider.minValue){
          magicSlider.value = magicSlider.minValue;
          invMagic.currentMagic = 0;
      }
    }
}