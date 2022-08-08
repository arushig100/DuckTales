using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public static GameManager game;
    public int totalMoney;
    public float duckSpeed;
    public float obstacleSpeed;
    public float cloudSpeed;
    public int curLevel;
    public GameObject[] characters;
    public int[] prices;
    public bool[] purchased;
    public int equipDuckInd;


    // Stores current instance of GameManager as a static variable
    void Awake()
    {
        if(game != null){
            Destroy(gameObject);
            return;
        }

        // Initialize everything
        game = this;
        game.totalMoney = 0;
        game.duckSpeed = 7.5f;
        game.obstacleSpeed = 8.5f;
        game.cloudSpeed = 0.5f;
        game.curLevel = 1;
        game.purchased = new bool[] {true,false,false,false,false};
        game.equipDuckInd = 0;
        DontDestroyOnLoad(gameObject);
    }
    
    /*
    void Start(){
        curDuckInd = PlayerPrefs.GetInt("SelectedDuck",0);
        foreach (GameObject duck in characters){
            duck.SetActive(false);
        }
        characters[curDuckInd].SetActive(true);
        priceText.SetText(prices[curDuckInd].ToString());
        curAmountText.SetText("Coins: " + totalMoney.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Functions for controlling Shop

    public void PurchaseDuck(){
        if(prices[curDuckInd] > totalMoney){
            print("NOT ENOUGH MONEY");
            return;
        }
        else if(!purchased[curDuckInd]){
            totalMoney-= prices[curDuckInd];
            purchased[curDuckInd] = true;
            curAmountText.SetText("Coins: " + totalMoney.ToString());
        }
    }

    public void EquipDuck(){
        if(purchased[curDuckInd]){
            equipDuckInd = curDuckInd;
        }
    }

    public void NextDuck(){
        characters[curDuckInd].SetActive(false);
        curDuckInd++;
        if(curDuckInd==characters.Length) curDuckInd=0;


        characters[curDuckInd].SetActive(true);
        priceText.SetText(prices[curDuckInd].ToString());
        PlayerPrefs.SetInt("SelectedDuck", curDuckInd);
    }

    public void PreviousDuck(){
        characters[curDuckInd].SetActive(false);
        curDuckInd--;
        if(curDuckInd==-1) curDuckInd=characters.Length-1;

        characters[curDuckInd].SetActive(true);
        priceText.SetText(prices[curDuckInd].ToString());
        PlayerPrefs.SetInt("SelectedDuck", curDuckInd);
    }*/


}
