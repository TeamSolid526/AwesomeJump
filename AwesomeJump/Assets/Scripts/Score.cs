using System;
using System.Threading;

using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    public Transform character;
    public Text scoreText;
<<<<<<< HEAD
    //public Text scoreOnly;
    private GameObject character2;
    private Player score;
    public int hookNum = 0;
    public float timeRemain = 30;
    // Start is called before the first frame update
    public int maxScore = 0;
    public int max = 0;
    public float curTimeRemain;

    void Start() {
        curTimeRemain = timeRemain;
        maxScore = 0;
    }
    // Update is called once per frame
=======

    public int max = 0;
>>>>>>> 0b82f82f5816c4d2bcfaed0fcfcbe5ec0619108d
    void Update()
    {
        if(character.position.y > max){
            max = (int)character.position.y;
        }
<<<<<<< HEAD
        //curTimeRemain -= Time.deltaTime;
		curTimeRemain = GameObject.Find("LaserGenerator").GetComponent<LaserGenerator>().timer;
        //if(curTimeRemain < 0){
        //    curTimeRemain = timeRemain;
        //}
        //curTimeRemain -= Time.deltaTime;
        bool flag = false;
        character2 = GameObject.Find("Character");
		score = character2.GetComponent<Player>();
		flag = score.jump;
        //flag = character2.GetComponent(typeof(bool)).hooked;
        if(!flag){
            hookNum = 1;
        }else{
            hookNum = 0;
        }
        // Debug.Log("max"+max);
        //scoreOnly.text = "Score: " + max.ToString("0") + "\n";
        scoreText.text = "Score: " + max.ToString("0") + "\n" +
         "Hooks: " + hookNum.ToString() + "\n" +
         "Laser in " + curTimeRemain.ToString("0") + "s";
        maxScore = max;
        //Debug.Log(character.position.y);gi
=======

        scoreText.text = "Score: " + max.ToString("0");

        //Debug.Log(character.position.y);
>>>>>>> 0b82f82f5816c4d2bcfaed0fcfcbe5ec0619108d
    }
}
