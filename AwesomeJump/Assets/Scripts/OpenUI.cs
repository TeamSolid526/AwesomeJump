using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{
    public GameObject scene;
    // Start is called before the first frame update
    public void onclickActive()
    {
        scene.SetActive(true);
    }

    public void onclickDeactive()
    {
        scene.SetActive(false);
    }
    public void onclickDeactiveAndConitue()
    {
        scene.SetActive(false);
        Time.timeScale = 1;
    }
}
