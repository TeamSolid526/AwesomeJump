using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    private CoinCounter ct;
    void Start()
    {
        ct = GameObject.Find("CoinCounter").GetComponent<CoinCounter>(); 
        ct.totalCoins = 0;       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        if (this.transform.position.y < stageDimensions.y) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p)
        {
            // destroy object after player hit
            ct.totalCoins++;
            Destroy(this.gameObject);
        }
    }
}
