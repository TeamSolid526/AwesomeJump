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
        
            score = GameObject.Find("Canvas/Text").GetComponent<Score>().max;
            if (GameObject.Find("Text")!=null){
                Debug.Log("FindText");
                Debug.Log(GameObject.Find("Text"));
            }
            else{
                Debug.Log("Cannot Find Text");
            }
            if (GameObject.Find("Canvas/Text").GetComponent<Score>()!=null){
                Debug.Log("FindScore!!!!");
                Debug.Log(GameObject.Find("Canvas/Text").GetComponent<Score>().max);
            }
            else{
                Debug.Log(GameObject.Find("Canvas/Text").GetComponent<Score>().max);
                Debug.Log("Cannot Find Score!!!!");
            }
            maxHealth = character.gameObject.GetComponent<Player>().maxHealth;
            Debug.Log("maxHealth");
          
      
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
