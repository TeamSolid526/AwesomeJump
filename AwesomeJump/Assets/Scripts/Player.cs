using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed = 2f;
    public float movement = 0f;
    public float ropeLength = 10f;
    public int health = 100;
    public GameObject laser;
    Rigidbody2D rb;
    Vector3 worldMousePosition;
    Vector2 direction;
    LineRenderer lr;
    GameObject targetBoard;
    bool hooked = false;

    public float JUMPFORCE = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * speed;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldMousePosition.x, worldMousePosition.y), Vector2.zero, 0);
        Vector3 storeHitPos = hitData.point;
        if (!hooked) {
            direction = worldMousePosition - transform.position;
            // direction.Normalize();
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.position + (Vector3)direction);
        }

       //storeHitPos: cannot click to the point below it
        if (hitData && Input.GetMouseButtonDown(0) && storeHitPos.y > transform.position.y) {
            targetBoard = hitData.transform.gameObject;
            float distance = ((Vector2)targetBoard.transform.position - (Vector2)transform.position).magnitude;
            hooked = true;
            // rb.gravityScale = 1;
          
            
            
        }
    }

    void FixedUpdate() {
         if(rb.position.x > 4.0f){
             Vector2 position = rb.position;
             position.x = -4.0f;
             rb.position = position;
         }
         if(rb.position.x < -4.0f){
             Vector2 position = rb.position;
             position.x = 4.0f;
             rb.position = position;
         }
    
        if (hooked) {
 
            rb.velocity = direction * 2f;
            
        }
        else{
            Vector2 velocity = rb.velocity;
            velocity.x = movement;
        
            rb.velocity = velocity;
            
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        direction = Vector2.zero;
        hooked = false;
        Vector3 p = other.transform.position;
        Vector2 v = rb.velocity;
        
       
        
        
        p.y += 0.1f;
        
        transform.position = p;
        v.x = 0f;
        v.y = 0f;
        rb.velocity = v;
        // rb.gravityScale = 0;
       
    }
    void OnCollisionEnter2D(Collision2D other) {

        hooked = false;
        Debug.Log(rb.velocity);
      
        Vector2 v = rb.velocity;
        v.y = JUMPFORCE;
        rb.velocity = v;
    
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
