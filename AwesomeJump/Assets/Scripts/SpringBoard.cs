using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBoard : MonoBehaviour
{
    // Start is called before the first frame update
    public float JUMPFORCE = 30f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnCollisionEnter2D(Collision2D collision)
    {
 
        
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = JUMPFORCE;
                rb.velocity = velocity;
            }
        
    }
}
