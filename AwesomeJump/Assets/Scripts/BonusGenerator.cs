using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGenerator : MonoBehaviour
{
    public GameObject bonusPrefab;
    public GameObject shieldPrefab;    
    public GameObject boosterPrefab;
    public GameObject rejuvenationPrefab;    
    public GameObject fallenProtectPrefab;
    public GameObject CoinPrefab;
    public Transform cameraPos;
    public float generateTime = 60f;
    public float coinGenerateTime = 8f;
    public float rangeX = 4f;
    
    private BuffType bt;
    private float bonusTimer = 0f;
    private float coinTimer = 0f;
    private GameObject bonus;
    // Start is called before the first frame update
    void Start()
    {
        bt = GameObject.Find("Buff").GetComponent<BuffType>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinUpdate();
        BonusUpdate();
    }

    void CoinUpdate()
    {
        coinTimer += Time.deltaTime;
        if (coinTimer >= coinGenerateTime)
        {
            int numCoin = Random.Range(3, 6);
            Vector3 coinPos = cameraPos.position;      
            coinPos.x = Random.Range(-rangeX, rangeX);
            coinPos.y += 8f;
            coinPos.z = 0;  
            Vector3 center = coinPos;
            center.y += 0.5f;
            float angle = 360 / numCoin;            
            int type = Random.Range(0, 4);         
            for (int i = 0; i < numCoin; i++)
            {
                if (type == 0) {
                    coinPos.y += 0.6f;               
                    Instantiate(CoinPrefab, coinPos, Quaternion.identity);
                } else if (type == 1) {
                    coinPos.y += 0.6f;  
                    coinPos.x += 0.6f;             
                    Instantiate(CoinPrefab, coinPos, Quaternion.identity);            
                } else if (type == 2) {
                    coinPos.y -= 0.6f;  
                    coinPos.x -= 0.6f;             
                    Instantiate(CoinPrefab, coinPos, Quaternion.identity); 
                } else {
                    GameObject coin = Instantiate(CoinPrefab, coinPos, Quaternion.identity);
                    coin.transform.RotateAround(center, Vector3.forward, angle * i);                                               
                }
            }
            coinTimer = 0;
        }
    }

    void BonusUpdate()
        {
            bonusTimer += Time.deltaTime;
            if (bonusTimer >= generateTime && bonus == null)
            {
                Vector3 bonusPos = cameraPos.position;
                bonusPos.z = 0;
                bonusPos.y += 8f;
                if (bt.buffTypeNum == 0)
                {
                    bonus = Instantiate(shieldPrefab, bonusPos, Quaternion.identity);                                   
                }
                else if (bt.buffTypeNum == 1) 
                {
                    bonus = Instantiate(boosterPrefab, bonusPos, Quaternion.identity);                   
                } 
                else if (bt.buffTypeNum == 2)
                {
                    bonus = Instantiate(rejuvenationPrefab, bonusPos, Quaternion.identity);                   
                }
                else if (bt.buffTypeNum == 3)
                {
                    bonus = Instantiate(fallenProtectPrefab, bonusPos, Quaternion.identity);                                   
                }
                 else 
                {
                 }
                // else
                // {
                //     bonus = Instantiate(bonusPrefab, bonusPos, Quaternion.identity);   
                // }
                bonusTimer = 0f;        
            }
        }
}
