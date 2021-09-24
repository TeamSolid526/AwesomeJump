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
    // Update is called once per frame
    void Update()
    {
        if(character.position.y > max){
            max = (int)character.position.y;
        }
        timeRemain -= Time.deltaTime;
        if(timeRemain < 0){
            timeRemain = 60;
        }
        scoreText.text = "Score: " + max.ToString("0") + "\n" +
         "Hooks: " + hookNum.ToString() + "\n" +
         "Laser in " + timeRemain.ToString("0") + "s";

        //Debug.Log(character.position.y);
    }
}
