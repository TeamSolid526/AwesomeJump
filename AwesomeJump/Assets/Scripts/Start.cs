using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    BuffType bt;

    public void Awake()
    {
        if (GameObject.Find("Buff"))
            bt = GameObject.Find("Buff").GetComponent<BuffType>();        
    }

    public void StartChoosingBuff()
    {
        SceneManager.LoadScene("ChoosingBuff");
    }

    public void StartGameWithShield()
    {      
        SceneManager.LoadScene("SampleScene");
        bt.buffTypeNum = 0;
    }

    public void StartGameWithBooster()
    {      
        SceneManager.LoadScene("SampleScene");
        bt.buffTypeNum = 1;
    }

    public void StartGameWithRejuvenation()
    {      
        SceneManager.LoadScene("SampleScene");
        bt.buffTypeNum = 2;
    }

    public void StartGameWithFallenProtect()
    {      
        SceneManager.LoadScene("SampleScene");
        bt.buffTypeNum = 3;
    }
}
