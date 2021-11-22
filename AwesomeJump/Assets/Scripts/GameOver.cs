using System;
using System.Threading;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public Text scoreText;
    public Transform cameraPos;
    public Transform character;
    public GameOverScene GameOverScene;
    public int score;
    public Score findScore;
    private bool flag = true;
    private bool rebornFlag = false;
    public float maxHealth;
    private bool protect;
    private float JUMPFORCE = 30f;
    private CoinCounter ct;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        protect = character.gameObject.GetComponent<Player>().fallenProtect;
        
        if(protect && character.position.y < cameraPos.position.y - 6f){
                Vector2 velocity = character.gameObject.GetComponent<Rigidbody2D>().velocity;
                velocity.y = JUMPFORCE;
                character.gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
                rebornFlag = true;
                return;
        }
        if(rebornFlag == true && character.position.y > cameraPos.position.y - 6f) {
            character.gameObject.GetComponent<Player>().fallenProtect = false;
            rebornFlag = false;
        }
        if(flag &&( character.position.y < cameraPos.position.y - 6f || character.gameObject.GetComponent<Player>().health <= 0)){
            //scoreText.text = "Game Over.";
        
            score = GameObject.Find("Canvas/Score").GetComponent<Score>().max;
         
           
            
            maxHealth = character.gameObject.GetComponent<Player>().maxHealth;
            ct = GameObject.Find("CoinCounter").GetComponent<CoinCounter>();    
            Debug.Log("maxHealth");
          
            CoinEarned.totalEarnedCoins += ct.totalCoins;
            // AnalyticsEvent.GameOver("saveHeight", new Dictionary<string,object>{{"height",character.position.y}});
            PlayerData.score = score;
            PlayerData.height_score = Math.Max(PlayerData.height_score, score);
            PlayerData.health = maxHealth;
            if(character.position.y < cameraPos.position.y - 6f){
                 PlayerData.failWay = "fall out";
                // GameObject.Find("GameOverScene/GameOverText").GetComponent<Text>().text ="Game Over-Ahhh!";
            }
            else if(character.gameObject.GetComponent<Player>().health <= 0){
                PlayerData.failWay = "negative points";
                // GameObject.Find("GameOverScene/GameOverText").GetComponent<Text>().text = "Game Over-You ran out of Health!";
            }
            // TODO: uncomment this function to upload data to dashboard
            PlayerData.debug();
            PlayerData.UploadData();
            
            GameOverScene.Setup();
            PlayerData.clear();
            flag = false;
        }
    }
}
