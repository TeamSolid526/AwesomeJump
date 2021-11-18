using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinEarned : MonoBehaviour
{
    public static bool shield = false;
    public static bool booster = false;
    public static bool rejuvenation = false;
    public static bool fallenProtect = false;
    public static int totalEarnedCoins = 0;
    public Text CoinEarnedText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinEarnedText.text = "Coins:"+totalEarnedCoins.ToString();
    }
}
