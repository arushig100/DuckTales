using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    public AudioSource MusicSource, EffectsSource;
    public AudioClip Click;
    public AudioClip Coin;
    public AudioClip Jump;
    public AudioClip AsianMusic;
    public AudioClip ActionMusic;
    public static SoundManager inst;

    public float volume = 1f;

    private void Awake() {
        if(inst != null && inst != this) {
            Destroy(this.gameObject);
            return;
        }

        inst = this;

        StartAsianMusic();

        DontDestroyOnLoad(this);
    }

    void Update() {
        inst.MusicSource.volume = inst.volume;
    }

    public void StartAsianMusic(){
        // Play Asian Music
        inst.MusicSource.Stop();
        inst.MusicSource.loop = true;
        inst.MusicSource.clip = inst.AsianMusic;
        inst.MusicSource.Play();
    }

    public void StartActionMusic(){
        // Play Action Music
        inst.MusicSource.Stop();
        inst.MusicSource.loop = true;
        inst.MusicSource.clip = inst.ActionMusic;
        inst.MusicSource.Play();
    }

    public void PlayClick(){
        inst.EffectsSource.PlayOneShot(inst.Click);
    }

    public void PlayCoin(){
        inst.EffectsSource.PlayOneShot(inst.Coin);
    }

    public void PlayJump(){
        inst.EffectsSource.PlayOneShot(inst.Jump);
    }

    


    
}
