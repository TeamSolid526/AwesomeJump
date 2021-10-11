using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformProperty
{
    public string type;
    public float value;
    public bool fragile;

    public PlatformProperty() {
        type = "buff";
        value = 0f;
        fragile = false;
    }

    public PlatformProperty(string tp, float val, bool fgl=false) {
        type = tp;
        value = val;
        fragile = fgl;
    }

}


public class Platform : MonoBehaviour
{
    public float JUMPFORCE = 10f;
    public float fragileWeight = 20f;
    public PlatformProperty property;

    private List<string> platformTypes = new List<string>() { "buff", "debuff" };
    private static readonly System.Random getrandom = new System.Random();

    private void Start() {
        // Init the board properties
        string type = platformTypes[getrandom.Next(0, platformTypes.Count)];
        int value = getrandom.Next(2,10);
        int fragileValue = getrandom.Next(0,100);
        property = new PlatformProperty(type, (float)value, fragileValue<fragileWeight);

        // Change color if the board is debuff
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (type=="debuff") {
            spriteRenderer.color = Color.red;
        }
        // Change color if the board is fragile
        if (fragileValue<fragileWeight) {
            Vector4 newColor = spriteRenderer.color;
            newColor[3] = 0.3f;
            spriteRenderer.color = newColor;
        }
    }

    // Function to reverse the property of board
    void ReverseProperty() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (property.type == "buff") {
            property.type = "debuff";
            spriteRenderer.color = Color.red;
        }
        else {
            property.type = "buff";
            spriteRenderer.color = Color.blue;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.relativeVelocity.y < 0){
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null) {
                Vector2 velocity = rb.velocity;
                velocity.y = JUMPFORCE;
                rb.velocity = velocity;
                
                // // Debug.Log(health);
                if(property.type=="buff"){
                    // Debug.Log(property.value);
                    collision.collider.gameObject.GetComponent<Player>().health += (int) property.value * (1 + (int) collision.collider.gameObject.GetComponent<Player>().highestY / 300) * collision.collider.gameObject.GetComponent<Player>().colortype;
                }
                else{
                    collision.collider.gameObject.GetComponent<Player>().health -= (int) property.value * (1 + (int) collision.collider.gameObject.GetComponent<Player>().highestY / 100) * collision.collider.gameObject.GetComponent<Player>().colortype;
                }
                Debug.Log(collision.collider.gameObject.GetComponent<Player>().health);
            }
            // Destroy board if board is fragile
            if (property.fragile){
                Destroy(this.gameObject);
                return;
            }
            // Reverse board property if colliding with player
            if (property.type=="buff"){
                ReverseProperty();
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
