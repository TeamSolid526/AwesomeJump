using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed = 2f;
    public float movement = 0f;
    public int health = 100;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * speed;
    }

    void FixedUpdate() {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    // void OnTriggerEnter2D(Collider2D other) {
    //     Debug.Log(other.gameObject.name);
        
    // }

    void OnCollisionEnter2D(Collision2D other) {
        // Debug.Log(other.collider.gameObject.name);
        // Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();
        // Debug.Log(rb.velocity.y);
        
        if (other.collider.gameObject.name == "Board(Clone)" && other.relativeVelocity.y > 0)
        {
            health ++;
            Debug.Log(health);
        }
            
        
    }
}
