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
    public int hookNum = 0;
    public float timeRemain = 30;
    // Start is called before the first frame update

    public int max = 0;
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
        //curTimeRemain -= Time.deltaTime;
		curTimeRemain = GameObject.Find("LaserGenerator").GetComponent<LaserGenerator>().timer;
        //if(curTimeRemain < 0){
        //    curTimeRemain = timeRemain;
        //}

        //scoreOnly.text = "Score: " + max.ToString("0") + "\n";
        scoreText.text = "Score: " + max.ToString("0") + "\n" +
         "Hooks: " + hookNum.ToString() + "\n" +
         "Laser in " + curTimeRemain.ToString("0") + "s";

        //Debug.Log(character.position.y);
    }
}
