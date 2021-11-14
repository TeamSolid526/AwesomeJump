using System.Data;
using System.Runtime.Serialization;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HookBar : MonoBehaviour
{
    public Slider slider;
    private GameObject character;
    public Gradient gradient;
    public Image fill;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        character = GameObject.Find("Character");
		Player player = character.GetComponent<Player>();
        slider.value = player.countSameColor;
        if(!player.jump){
            slider.value = 3;
        }
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
