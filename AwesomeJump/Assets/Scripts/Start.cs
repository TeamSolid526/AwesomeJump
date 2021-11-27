using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start : MonoBehaviour
{
    BuffType bt;
    public CoinEarned CoinEarned;
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
      
        if(CoinEarned.totalEarnedCoins + CoinEarned.spent >= 15){
            
            resetButton();
            // Debug.Log("shield"+PlayerData.shield);
            PlayerData.shield++;
      //  SceneManager.LoadScene("SampleScene");
            Debug.Log("SieldButtonText"+ShieldButtonText.text );
            ShieldButtonText.text ="Bought";
            Debug.Log("SieldButtonText"+ShieldButtonText.text );
            ShieldButton.enabled = false;
            CoinEarned.totalEarnedCoins -= 15;
            CoinEarned.spent = 15;
            CoinEarned.shield = true;
            bt.buffTypeNum = 1;
            buy = true;
        }
        else{
            Debug.Log("coins:      " + CoinEarned.spent + " " + CoinEarned.totalEarnedCoins);
        }
        
    }

    public void StartGameWithBooster()
    {      
        
        if(CoinEarned.totalEarnedCoins + CoinEarned.spent >= 30){
            resetButton();
            PlayerData.booster++;
            BoosterButtonText.text = "Bought";
            BoosterButton.enabled = false;
            CoinEarned.totalEarnedCoins -= 30;
            CoinEarned.spent = 30;
            CoinEarned.booster = true;
            bt.buffTypeNum = 2;
            buy = true;
        }
        else{}
        // SceneManager.LoadScene("SampleScene");
        
    }

    public void StartGameWithRejuvenation()
    {      
        
        if(CoinEarned.totalEarnedCoins + CoinEarned.spent >= 25){
            resetButton();
            CoinEarned.totalEarnedCoins -= 25;
            CoinEarned.spent = 25;
            CoinEarned.rejuvenation = true;
            PlayerData.rejuvenation++;
            RejuvButtonText.text = "Bought";
            RejuvButton.enabled = false;
            bt.buffTypeNum = 3;
            buy = true;
        }else{
            Debug.Log("coins:      " + CoinEarned.spent + " " + CoinEarned.totalEarnedCoins);
        }
        // SceneManager.LoadScene("SampleScene");
        
    }

    public void StartGameWithFallenProtect()
    {      
       
        if(CoinEarned.totalEarnedCoins + CoinEarned.spent >= 35){
            resetButton();
             PlayerData.fallenProtect++;
        // SceneManager.LoadScene("SampleScene");
            FallenProtectButtonText.text = "Bought";
            FallenProtectButton.enabled = false;
            CoinEarned.totalEarnedCoins -= 35;
            CoinEarned.spent = 35;
            CoinEarned.fallenProtect = true;
            bt.buffTypeNum = 4;
            buy = true;
        }else{}
        
    }
    public void StartGameWithoutBoost()
    {      
        SceneManager.LoadScene("SampleScene");
        resetButton();
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
            bt.buffTypeNum = 0;
        }
    }

    public void resetButton() {
        CoinEarned.totalEarnedCoins += CoinEarned.spent;
        
        ShieldButtonText.text = "Buy";
        BoosterButtonText.text = "Buy";
        RejuvButtonText.text = "Buy";
        FallenProtectButtonText.text = "Buy";
        Debug.Log("ShieldButton"+ShieldButton);
        ShieldButton.enabled = true;
        BoosterButton.enabled = true;
        RejuvButton.enabled = true;
        FallenProtectButton.enabled = true; 
    }
}
