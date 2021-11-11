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

    public int max = 0;
    void Update()
    {
        if(character.position.y > max){
            max = (int)character.position.y;
        }

        scoreText.text = "Score: " + max.ToString("0");

        //Debug.Log(character.position.y);
    }
}
