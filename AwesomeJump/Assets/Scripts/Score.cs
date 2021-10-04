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
    public int hookNum = 0;
    public float timeRemain = 60;
    // Start is called before the first frame update

    private int max = 0;
    public float curTimeRemain;

    void Start() {
        curTimeRemain = timeRemain;
    }
    // Update is called once per frame
    void Update()
    {
        if(character.position.y > max){
            max = (int)character.position.y;
        }
        curTimeRemain -= Time.deltaTime;
        if(curTimeRemain < 0){
            curTimeRemain = timeRemain;
        }
        scoreText.text = "Score: " + max.ToString("0") + "\n" +
         "Hooks: " + hookNum.ToString() + "\n" +
         "Laser in " + curTimeRemain.ToString("0") + "s";

        //Debug.Log(character.position.y);
    }
}
