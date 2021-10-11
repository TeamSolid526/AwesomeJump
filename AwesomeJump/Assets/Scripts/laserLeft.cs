using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserLeft : MonoBehaviour
{
    // Start is called before the first frame update
	public Player character;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Character") {
            col.gameObject.GetComponent<Player>().health += 100;
            // Debug.Log("headlll!!!!!!" + col.gameObject.GetComponent<Player>().health);
        }
    }
}
