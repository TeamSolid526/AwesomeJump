using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed = 2f;
    public float movement = 0f;
    public float ropeLength = 10f;
    Rigidbody2D rb;
    Vector3 worldMousePosition;
    Vector2 direction;
    LineRenderer lr;
    GameObject targetBoard;
    bool hooked = false;

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
        if (!hooked) {
            direction = worldMousePosition - transform.position;
            direction.Normalize();
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.position + (Vector3)direction * ropeLength);
        }

        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldMousePosition.x, worldMousePosition.y), Vector2.zero, 0);

        if (hitData && Input.GetMouseButtonDown(0)) {
            targetBoard = hitData.transform.gameObject;
            float distance = ((Vector2)targetBoard.transform.position - (Vector2)transform.position).magnitude;
            hooked = distance < ropeLength;
            
            
        }
    }

    void FixedUpdate() {
        // Vector2 velocity = rb.velocity;
        // velocity.x = movement;
        // rb.velocity = velocity;
        if (hooked) {
            rb.velocity = direction * speed;
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        direction = Vector2.zero;
        hooked = false;
        Vector3 p = other.transform.position;
        p.y += 0.5f;
        transform.position = p;
        Vector2 v = rb.velocity;
        v.x = 0f;
        rb.velocity = v;
        
    }
}
