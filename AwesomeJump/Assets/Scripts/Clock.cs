using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    private float timeRemain = 5;
    private float curTimeRemain;
    void Start()
    {
        curTimeRemain = timeRemain;
    }

    // Update is called once per frame
    void Update()
    {
        curTimeRemain = GameObject.Find("LaserGenerator").GetComponent<LaserGenerator>().timer;
        scoreText.text = curTimeRemain.ToString("0");
    }
}
