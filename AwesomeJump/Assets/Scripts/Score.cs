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
    void Update()
    {
        if(character.position.y > max){
            max = (int)character.position.y;
        }

        scoreText.text = "Score: " + max.ToString("0");

        //Debug.Log(character.position.y);
    }
}
