using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserRight : MonoBehaviour
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
        if (col.gameObject.name == "Character"&& flag == 0) {
			if(col.gameObject.GetComponent<Player>().laserBuff <= 0){
                PlayerData.total_laser_damage += col.gameObject.GetComponent<Player>().health - col.gameObject.GetComponent<Player>().health % 100;
				col.gameObject.GetComponent<Player>().health = col.gameObject.GetComponent<Player>().health % 100;
				Debug.Log("Right!!!!!!" + col.gameObject.GetComponent<Player>().health);
				flag = 1;
			}
			else{
				col.gameObject.GetComponent<Player>().laserBuff -= 1;
			}
        }
    }
}
