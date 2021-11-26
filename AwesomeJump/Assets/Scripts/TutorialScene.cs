using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Text TutorialText;
    public void Setup() {
        // player.enabled = false;
        gameObject.SetActive(true);
        TutorialText.text = "When you continuously touch three board with the same color as your body's, you will get the hook.\n Now try click the left mouse botton to try your new item";
    }

    
    public void Continue(){
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
