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
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(character.position.y < cameraPos.position.y - 6f){
            scoreText.text = "Game Over.";
        }
    }
}
