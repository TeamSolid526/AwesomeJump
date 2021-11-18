using System.Diagnostics;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartGame()
    {
        SceneManager.LoadScene("ChoosingBuff");
        UnityEngine.Debug.Log("sssssssssss");
        print("ssssss");
    }
}
