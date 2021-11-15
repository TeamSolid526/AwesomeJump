using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public int totalCoins;    
    void Start()
    {
        
        DontDestroyOnLoad(this.gameObject);    
        totalCoins = 0;            
    }

    void Update()
    {
       // Debug.Log("totalCoins"+totalCoins);
    }
}
