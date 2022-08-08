using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeVolume : MonoBehaviour
{
    public Slider musicSlider;

    void Awake(){
        musicSlider.value = SoundManager.inst.volume;
    }

    public void UpdateVolume(float vol){
        SoundManager.inst.volume = vol;
    }

}
