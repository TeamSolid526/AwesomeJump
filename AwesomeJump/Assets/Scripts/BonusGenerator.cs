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
    public Transform cameraPos;
    public float generateTime = 60f;
    
    private BuffType bt;
    private float timer = 0f;
    private GameObject bonus;
    // Start is called before the first frame update
    void Start()
    {
        bt = GameObject.Find("Buff").GetComponent<BuffType>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= generateTime && bonus == null)
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
            else if(bt.buffTypeNum==4){
                
            }
            else
            {
                bonus = Instantiate(bonusPrefab, bonusPos, Quaternion.identity);   
            }
            timer = 0f;        
        }
    }
}
