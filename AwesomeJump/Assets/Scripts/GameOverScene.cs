using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    public Score score;
    public Player player;
    private CoinCounter ct;
    public void Setup() {
        ct = GameObject.Find("CoinCounter").GetComponent<CoinCounter>();  
        player.enabled = false;
        gameObject.SetActive(true);
        Debug.Log("failway"+PlayerData.failWay);
        if(PlayerData.failWay == "fall out"){
           
            GameObject.Find("GameOverText").GetComponent<Text>().text = "Game Over\nAhhh! You fell to death!";
            
        }else if (PlayerData.failWay == "negative points"){
            GameObject.Find("GameOverText").GetComponent<Text>().text = "Game Over\nYou ran out of Health!";
            
        }
        scoreText.text = "Your Score:" + score.max.ToString()+"\n"+"Your Coins:"+ct.totalCoins.ToString();
    }
}
