using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Text scoreText;
    public Transform cameraPos;
    public Transform character;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(character.position.y < cameraPos.position.y - 6f, 0){
            scoreText.text = "Game Over.";
        }
    }
}
