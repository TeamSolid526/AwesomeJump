using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // destroy when object out of screen
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        if (this.transform.position.y < stageDimensions.y) {
            Destroy(this.gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("enter detected");


        if (other.gameObject.name == "Character")
        {

            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = 40f;
                rb.velocity = velocity;
            }
            // destroy after player hit it
            Destroy(this.gameObject);
        }
    }


    
}
