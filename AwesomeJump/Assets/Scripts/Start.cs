using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start : MonoBehaviour
{
    BuffType bt;
    private Text ShieldButtonText;
    private Text BoosterButtonText;
    private Text RejuvButtonText;
    private Text FallenProtectButtonText;
    private Button ShieldButton;
    private Button BoosterButton;
    private Button RejuvButton;
    private Button FallenProtectButton;
    private CoinCounter ct;
    private static bool buy = false;

    public void Awake()
    {
        if (GameObject.Find("Buff"))
            bt = GameObject.Find("Buff").GetComponent<BuffType>();  
      
        if (SceneManager.GetActiveScene().name == "ChoosingBuff"){//not in the mainMenu scene
            ShieldButtonText = GameObject.Find("Shield/Text").GetComponent<Text>();
            ShieldButton = GameObject.Find("Shield").GetComponent<Button>();
            BoosterButtonText = GameObject.Find("Booster/Text").GetComponent<Text>();
            BoosterButton = GameObject.Find("Booster").GetComponent<Button>();
            RejuvButtonText = GameObject.Find("Rejuvenation/Text").GetComponent<Text>();
            RejuvButton = GameObject.Find("Rejuvenation").GetComponent<Button>();
            FallenProtectButtonText = GameObject.Find("FallenProtect/Text").GetComponent<Text>();
            FallenProtectButton = GameObject.Find("FallenProtect").GetComponent<Button>();
        }
        
    }

    public void StartChoosingBuff()
    {
        SceneManager.LoadScene("ChoosingBuff");
    }

    public void StartGameWithShield()
    {      
        
        if(CoinEarned.totalEarnedCoins + CoinEarned.spent >= 50){
            resetButton();
            PlayerData.shield++;
      //  SceneManager.LoadScene("SampleScene");
            ShieldButtonText.text ="Bought";
            ShieldButton.enabled = false;
            CoinEarned.totalEarnedCoins -= 50;
            CoinEarned.spent = 50;
            CoinEarned.shield = true;
            bt.buffTypeNum = 0;
            buy = true;
        }
        else{
            Debug.Log("coins:      " + CoinEarned.spent + " " + CoinEarned.totalEarnedCoins);
        }
        
    }

    public void StartGameWithBooster()
    {      
        
        if(CoinEarned.totalEarnedCoins + CoinEarned.spent >= 100){
            resetButton();
            PlayerData.booster++;
            BoosterButtonText.text = "Bought";
            BoosterButton.enabled = false;
            CoinEarned.totalEarnedCoins -= 100;
            CoinEarned.spent = 100;
            CoinEarned.booster = true;
            bt.buffTypeNum = 1;
            buy = true;
        }
        else{}
        // SceneManager.LoadScene("SampleScene");
        
    }

    public void StartGameWithRejuvenation()
    {      
        
        if(CoinEarned.totalEarnedCoins + CoinEarned.spent >= 80){
            resetButton();
            CoinEarned.totalEarnedCoins -= 80;
            CoinEarned.spent = 80;
            CoinEarned.rejuvenation = true;
            PlayerData.rejuvenation++;
            RejuvButtonText.text = "Bought";
            RejuvButton.enabled = false;
            bt.buffTypeNum = 2;
            buy = true;
        }else{
            Debug.Log("coins:      " + CoinEarned.spent + " " + CoinEarned.totalEarnedCoins);
        }
        // SceneManager.LoadScene("SampleScene");
        
    }

    public void StartGameWithFallenProtect()
    {      
       
        if(CoinEarned.totalEarnedCoins + CoinEarned.spent >= 70){
            resetButton();
             PlayerData.fallenProtect++;
        // SceneManager.LoadScene("SampleScene");
            FallenProtectButtonText.text = "Bought";
            FallenProtectButton.enabled = false;
            CoinEarned.totalEarnedCoins -= 70;
            CoinEarned.spent = 70;
            CoinEarned.fallenProtect = true;
            bt.buffTypeNum = 3;
            buy = true;
        }else{}
        
    }
    public void StartGameWithoutBoost()
    {      
        SceneManager.LoadScene("SampleScene");
        CoinEarned.spent = 0;
        ShieldButtonText.text = "Buy";
        BoosterButtonText.text = "Buy";
        RejuvButtonText.text = "Buy";
        FallenProtectButtonText.text = "Buy";
        ShieldButton.enabled = true;
        BoosterButton.enabled = true;
        RejuvButton.enabled = true;
        FallenProtectButton.enabled = true;
        
        if (buy) {
            buy = false;
        } else {
            bt.buffTypeNum = 4;
        }
    }

    public void resetButton() {
        CoinEarned.totalEarnedCoins += CoinEarned.spent;
        ShieldButtonText.text = "Buy";
        BoosterButtonText.text = "Buy";
        RejuvButtonText.text = "Buy";
        FallenProtectButtonText.text = "Buy";
        ShieldButton.enabled = true;
        BoosterButton.enabled = true;
        RejuvButton.enabled = true;
        FallenProtectButton.enabled = true; 
    }
}
