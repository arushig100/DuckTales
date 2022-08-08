using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI curAmountText;
    public GameObject[] shopDucks;
    public int curDuckInd = 0;

    void Start(){
        curDuckInd = PlayerPrefs.GetInt("SelectedDuck",0);
        foreach (GameObject duck in shopDucks){
            duck.SetActive(false);
        }
        shopDucks[curDuckInd].SetActive(true);
        priceText.SetText(GameManager.game.prices[curDuckInd].ToString());
        curAmountText.SetText("Coins: " + GameManager.game.totalMoney.ToString());
    }
    

    public void PurchaseDuck(){
        SoundManager.inst.EffectsSource.PlayOneShot(SoundManager.inst.Click);
        if(GameManager.game.prices[curDuckInd] > GameManager.game.totalMoney){
            print("NOT ENOUGH MONEY");
            return;
        }
        else if(!GameManager.game.purchased[curDuckInd]){
            GameManager.game.totalMoney-= GameManager.game.prices[curDuckInd];
            GameManager.game.purchased[curDuckInd] = true;
            curAmountText.SetText("Coins: " + GameManager.game.totalMoney.ToString());
        }
        
    }

    public void EquipDuck(){
        if(GameManager.game.purchased[curDuckInd]){
            GameManager.game.equipDuckInd = curDuckInd;
        }
        SoundManager.inst.EffectsSource.PlayOneShot(SoundManager.inst.Click);
    }

    public void NextDuck(){
        shopDucks[curDuckInd].SetActive(false);
        curDuckInd++;
        if(curDuckInd==shopDucks.Length) curDuckInd=0;


        shopDucks[curDuckInd].SetActive(true);
        priceText.SetText(GameManager.game.prices[curDuckInd].ToString());
        PlayerPrefs.SetInt("SelectedDuck", curDuckInd);
        SoundManager.inst.EffectsSource.PlayOneShot(SoundManager.inst.Click);
    }

    public void PreviousDuck(){
        shopDucks[curDuckInd].SetActive(false);
        curDuckInd--;
        if(curDuckInd==-1) curDuckInd=shopDucks.Length-1;

        shopDucks[curDuckInd].SetActive(true);
        priceText.SetText(GameManager.game.prices[curDuckInd].ToString());
        PlayerPrefs.SetInt("SelectedDuck", curDuckInd);
        SoundManager.inst.EffectsSource.PlayOneShot(SoundManager.inst.Click);
    }
}
