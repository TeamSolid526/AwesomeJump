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
        PlayerData.shield++;
        SceneManager.LoadScene("SampleScene");
        bt.buffTypeNum = 0;
    }

    public void StartGameWithBooster()
    {      
        PlayerData.booster++;
        SceneManager.LoadScene("SampleScene");
        bt.buffTypeNum = 1;
    }

    public void StartGameWithRejuvenation()
    {      
        PlayerData.rejuvenation++;
        SceneManager.LoadScene("SampleScene");
        bt.buffTypeNum = 2;
    }

    public void StartGameWithFallenProtect()
    {      
        PlayerData.fallenProtect++;
        SceneManager.LoadScene("SampleScene");
        bt.buffTypeNum = 3;
    }
}
