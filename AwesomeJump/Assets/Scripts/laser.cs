using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class laser : MonoBehaviour
{
	
    public Player character;
    // Start is called before the first frame update
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
            //col.gameObject.GetComponent<Player>().health /= 2;
            SpriteRenderer spriteRenderer = col.gameObject.GetComponent<SpriteRenderer>();
            if (col.gameObject.GetComponent<Player>().colortype == 1){
                col.gameObject.GetComponent<Player>().colortype = -1;
                spriteRenderer.color = Color.red;
            }
            else{
                col.gameObject.GetComponent<Player>().colortype = 1;
                spriteRenderer.color = Color.blue;
            }

            // Debug.Log("headlll!!!!!!" + col.gameObject.GetComponent<Player>().health);
        }
    }
}
