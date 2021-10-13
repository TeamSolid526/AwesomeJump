using System;
using System.Threading;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
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
            
            if(character.position.y < cameraPos.position.y - 6f){
                 Analytics.CustomEvent("gameOver",new Dictionary<string,object>{{"highest score",score},{"highest health",maxHealth},{"Failways","fall out"}});
            }
            else if(character.gameObject.GetComponent<Player>().health <= 0){
                Analytics.CustomEvent("gameOver",new Dictionary<string,object>{{"highest score",score},{"highest health",maxHealth},{"Failways","negative points"}});
            }
            GameOverScene.Setup();
            flag = false;
        }
    }
}
