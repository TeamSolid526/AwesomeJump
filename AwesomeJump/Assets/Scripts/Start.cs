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
    private GameObject gameObject;
  


    public void Awake()
    {
        if (GameObject.Find("Buff"))
            bt = GameObject.Find("Buff").GetComponent<BuffType>();  
        
        
        ShieldButtonText = GameObject.Find("Shield/Text").GetComponent<Text>();
        ShieldButton = GameObject.Find("Shield").GetComponent<Button>();
        BoosterButtonText = GameObject.Find("Booster/Text").GetComponent<Text>();
        BoosterButton = GameObject.Find("Booster").GetComponent<Button>();
        RejuvButtonText = GameObject.Find("Rejuvenation/Text").GetComponent<Text>();
        RejuvButton = GameObject.Find("Rejuvenation").GetComponent<Button>();
        FallenProtectButtonText = GameObject.Find("FallenProtect/Text").GetComponent<Text>();
        FallenProtectButton = GameObject.Find("FallenProtect").GetComponent<Button>();
         
    }

    public void StartChoosingBuff()
    {
        SceneManager.LoadScene("ChoosingBuff");
    }

    public void StartGameWithShield()
    {      
        
        if(CoinEarned.totalEarnedCoins >= 50){
            PlayerData.shield++;
      //  SceneManager.LoadScene("SampleScene");
            ShieldButtonText.text ="Bought";
            ShieldButton.enabled = false;
            CoinEarned.totalEarnedCoins -= 50;
            bt.buffTypeNum = 0;
        }
        else{}
        
    }

    public void StartGameWithBooster()
    {      
        
        if(CoinEarned.totalEarnedCoins >= 100){
            PlayerData.booster++;
            BoosterButtonText.text = "Bought";
            BoosterButton.enabled = false;
            CoinEarned.totalEarnedCoins -= 100;
            bt.buffTypeNum = 1;
        }
        else{}
        // SceneManager.LoadScene("SampleScene");
        
    }

    public void StartGameWithRejuvenation()
    {      
        
        if(CoinEarned.totalEarnedCoins >= 80){
            CoinEarned.totalEarnedCoins -= 80;
            PlayerData.rejuvenation++;
            RejuvButtonText.text = "Bought";
            RejuvButton.enabled = false;
            bt.buffTypeNum = 2;
        }else{}
        // SceneManager.LoadScene("SampleScene");
        
    }

    public void StartGameWithFallenProtect()
    {      
       
        if(CoinEarned.totalEarnedCoins >= 70){
             PlayerData.fallenProtect++;
        // SceneManager.LoadScene("SampleScene");
            FallenProtectButtonText.text = "Bought";
            FallenProtectButton.enabled = false;
            CoinEarned.totalEarnedCoins -= 70;
            bt.buffTypeNum = 3;
        }else{}
        
    }
    public void StartGameWithoutBoost()
    {      
        SceneManager.LoadScene("SampleScene");
        ShieldButtonText.text = "Buy";
        BoosterButtonText.text = "Buy";
        RejuvButtonText.text = "Buy";
        FallenProtectButtonText.text = "Buy";
        ShieldButton.enabled = true;
        BoosterButton.enabled = true;
        RejuvButton.enabled = true;
        FallenProtectButton.enabled = true;
        
        bt.buffTypeNum = 4;
    }
}
