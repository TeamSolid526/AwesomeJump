using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformProperty
{
    public string type;
    public float value;

    public PlatformProperty() {
        type = "buff";
        value = 0f;
    }

    public PlatformProperty(string tp, float val) {
        type = tp;
        value = val;
    }

}


public class Platform : MonoBehaviour
{
    public float JUMPFORCE = 10f;
    public PlatformProperty property;

    private List<string> platformTypes = new List<string>() { "buff", "debuff" };
    private static readonly System.Random getrandom = new System.Random();

    private void Start() {
        // Init the board properties
        string type = platformTypes[getrandom.Next(0, platformTypes.Count)];
        int value = getrandom.Next(2,10);
        property = new PlatformProperty(type, (float)value);

        // Change color if the board is debuff
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (type=="debuff") {
            spriteRenderer.color = Color.red;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.relativeVelocity.y < 0){
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null) {
                Vector2 velocity = rb.velocity;
                velocity.y = JUMPFORCE;
                rb.velocity = velocity;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // If Y coordinate of board is lower than he bottom Y coordinate of the main camera, delete the board.
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        if (this.transform.position.y < stageDimensions.y) {
            Destroy(this.gameObject);
        }
    }
}
