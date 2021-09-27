using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    int penalty = 10;
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
            character.health /= 2;
            Debug.Log("headlll!!!!!!" + character.health);
        }
    }
}
