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
        scoreText.text = "Your Score:" + score.max.ToString()+"\n"+"Your coins:"+ct.totalCoins.ToString();
    }
}
