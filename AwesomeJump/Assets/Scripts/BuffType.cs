using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffType : MonoBehaviour
{
    /*
        0 : Laser Shield
        1 : Jump Booster
        2 : Rejuvenation
        3 : Fallen Protection
     */
    public int buffTypeNum;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
