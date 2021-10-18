using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserMid : MonoBehaviour
{
    // Start is called before the first frame update
	public Player character;
	private int flag;
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
			if(col.gameObject.GetComponent<Player>().laserBuff <= 0){
				col.gameObject.GetComponent<Player>().health /= 2;
                PlayerData.total_laser_damage += col.gameObject.GetComponent<Player>().health;
				Debug.Log("MID!!!!!!" + col.gameObject.GetComponent<Player>().laserBuff);
				flag = 1;
			}
			else{
				col.gameObject.GetComponent<Player>().laserBuff -= 1;
			}
        }
    }
}
