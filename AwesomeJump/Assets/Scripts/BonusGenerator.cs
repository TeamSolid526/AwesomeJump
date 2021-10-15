using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGenerator : MonoBehaviour
{
    public GameObject bonusPrefab;
    public Transform cameraPos;
    public float generateTime = 5f;
    
    
    private float timer = 0f;
    private GameObject bonus;
    // Start is called before the first frame update
    void Start()
    {
        
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
            bonus = Instantiate(bonusPrefab, bonusPos, Quaternion.identity);   
            timer = 0f;        
        }
    }
}
