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
    Vector3 lineStartPoint;
    bool hooked = false;
    bool jump = true;
    private int countBlue = 0;

    public float JUMPFORCE = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        Debug.Log(jump);
    }

    // Update is called once per frame
    void Update()
    {
      
        movement = Input.GetAxis("Horizontal") * speed;
            Vector2 velocity = rb.velocity;
            velocity.x = movement;
            rb.velocity = velocity;
       
        if(jump == false){
           
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldMousePosition.x, worldMousePosition.y), Vector2.zero, 0);
            Vector3 storeHitPos = hitData.point;
            if (!hooked) {
                direction = worldMousePosition - transform.position;
                // direction.Normalize();
            }

        //storeHitPos: cannot click to the point below it
            if (hitData && Input.GetMouseButtonDown(0) && storeHitPos.y > transform.position.y) {
                targetBoard = hitData.transform.gameObject;
                float distance = ((Vector2)targetBoard.transform.position - (Vector2)transform.position).magnitude;
                hooked = true;
                // rb.gravityScale = 1;
            
                
                
            }
        }
    }

    void FixedUpdate() {
        if(jump == false){
            lr.positionCount =2;
            lineStartPoint = rb.position;

                lr.SetPosition(0, lineStartPoint);
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
                lr.SetPosition(1, targetBoard.transform.position);            
            }
            else {
                Vector2 velocity = rb.velocity;
                velocity.x = movement;
                rb.velocity = velocity;
                lr.SetPosition(1, lineStartPoint + (Vector3)direction);            
                
            }
        }
        else{
            lr.positionCount = 0;
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        if(jump == false){
            if (other.gameObject == targetBoard) {
                direction = Vector2.zero;
                hooked = false;
                Vector3 p = other.transform.position;
                Vector2 v = rb.velocity;
                
            
                
                
                p.y += 0.5f;
                
                transform.position = p;
                rb.velocity = direction * 0.2f;
            
                // v.x = 0f;
                // v.y = 0f;
                // rb.velocity = v;
            }
        }
        // rb.gravityScale = 0;
       
    }
    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject == targetBoard) {
            hooked = false;
            jump = true;
        }
        if(other.relativeVelocity.y > 0){
                Vector2 v = rb.velocity;
                v.y = JUMPFORCE;
                rb.velocity = v;
                Platform boardScript = (Platform)other.gameObject.GetComponent(typeof(Platform));
              
                if (boardScript.property.type == "debuff"){
                    countBlue+=1;
 Debug.Log(countBlue);
                }
                else{
                    countBlue = 0;
                
                }
                if(countBlue == 3){
                   
                    countBlue = 0;
                    changeMovement();
                }
        }
        // Debug.Log(other.collider.gameObject.name);
        // Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();
        // Debug.Log(rb.velocity.y);
        
        if (other.collider.gameObject.name == "Board(Clone)" && other.relativeVelocity.y > 0)
        {
            health ++;
   //         Debug.Log(health);
        }
      
            
    }
     private void changeMovement(){
        if(jump == true){
            jump = !jump;
        }
    }
}
