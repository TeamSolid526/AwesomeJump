using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserLeft : MonoBehaviour
{
    // Start is called before the first frame update
	private int flag;
	public Player character;
    void Start()
    {
        flag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Character" && flag == 0) {
			if(col.gameObject.GetComponent<Player>().laserBuff == false){
				col.gameObject.GetComponent<Player>().health -= 100;
				Debug.Log("Left!!!!!!" + col.gameObject.GetComponent<Player>().laserBuff);
				flag = 1;
			}
        }
    }
}
