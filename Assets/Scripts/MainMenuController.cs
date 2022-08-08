using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
 



    // Called when player selects the play buton 
    public void PlayGame(){
        // Load gameplay scene
        SceneManager.LoadScene("Gameplay");


        // Action Music + Sound Effects
        SoundManager.inst.StartActionMusic();
        SoundManager.inst.PlayClick();
        
    }

    // Called when player selects the settings button
    public void ViewSettings(){
        SceneManager.LoadScene("SettingsScene");
        SoundManager.inst.PlayClick();
    }

    // Called when player selects the store buton
    public void ViewStore(){
        SceneManager.LoadScene("StoreScreen");
        SoundManager.inst.PlayClick();
    }

    public void BackToMainMenu(){
        SceneManager.LoadScene("StartScreen");
        SoundManager.inst.PlayClick();
    }
}
