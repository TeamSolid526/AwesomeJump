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
        TutorialText.text = "When you continuously jump on three boards with the same color as your character’s, you will get a hook.\n Now try to click the left mouse button on the board to hook your character on it";
    }

    
    public void Continue(){
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
