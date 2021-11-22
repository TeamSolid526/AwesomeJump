using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    private CoinCounter ct;
    public Text coin;
    // Start is called before the first frame update
    void Start()
    {
     ct = GameObject.Find("CoinCounter").GetComponent<CoinCounter>();    
     ct.totalCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
     coin.text = "Coins:"+ct.totalCoins.ToString();    
    }
}
