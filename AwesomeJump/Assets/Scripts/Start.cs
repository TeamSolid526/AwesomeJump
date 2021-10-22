using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    // Start is called before the first frame update
    //public BonusGenerator bg;
    public int bufferNum = 0;
    //public Preplay preplay;
    void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }
    public void StartChoosingBuff()
    {
        SceneManager.LoadScene("ChoosingBuff");
    }

    public void StartGame()
    {
        //preplay.param = bufferNum;
        SceneManager.LoadScene("SampleScene");
    }
}
