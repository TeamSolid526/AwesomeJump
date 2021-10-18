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
    private bool flag = true;
    public float maxHealth;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(flag &&( character.position.y < cameraPos.position.y - 6f || character.gameObject.GetComponent<Player>().health <= 0)){
            //scoreText.text = "Game Over.";
            score = GameObject.Find("Text").GetComponent<Score>().max;
            maxHealth = character.gameObject.GetComponent<Player>().maxHealth;
            Debug.Log(score);
            // AnalyticsEvent.GameOver("saveHeight", new Dictionary<string,object>{{"height",character.position.y}});
            PlayerData.score = score;
            PlayerData.height_score = Math.Max(PlayerData.height_score, score);
            PlayerData.health = maxHealth;
            if(character.position.y < cameraPos.position.y - 6f){
                 PlayerData.failWay = "fall out";
            }
            else if(character.gameObject.GetComponent<Player>().health <= 0){
                PlayerData.failWay = "negative points";
            }
            // TODO: uncomment this function to upload data to dashboard
            PlayerData.debug();
            PlayerData.UploadData();
            PlayerData.clear();
            GameOverScene.Setup();
            flag = false;
        }
    }
}
