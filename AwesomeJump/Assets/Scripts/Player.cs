using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public Text healthText;
    public float highestY = 0f;
    public float speed = 2f;
    public float movement = 0f;
    public float ropeLength = 10f;
    public int health = 100;
    public int colortype = 1;
    public GameObject laser;
	public bool laserBuff;
    public bool fallenProtect;
    public float rejBooster = 1.2f;
    Rigidbody2D rb;
    Vector3 worldMousePosition;
    Vector2 direction;
    LineRenderer lr;
    GameObject targetBoard;
    Vector3 lineStartPoint;
    public TutorialScene tutorial;
    public static bool boardTutorial = true;
    public bool hooked = false;
    public bool jump = true;
    public int countSameColor = 0;

    private GameObject buffTexture;

    public float JUMPFORCE = 10f;
    public int maxHealth = 0;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public float buttondirection = 0;
    private bool buttonLeft;
    private bool buttonRight;


    public void ChangeSprite() 
    {
        if (laserBuff)
        {
            Sprite sp = buffTexture.GetComponent<ChangeSprite>().shieldSprite;
            buffTexture.GetComponent<SpriteRenderer>().sprite = sp;
            Vector3 localScale = buffTexture.transform.localScale;
            localScale.x = 0.1f;
            localScale.y = 0.1f;
            buffTexture.transform.localScale = localScale;
        } 
        else if (fallenProtect)
        {
            Sprite sp = buffTexture.GetComponent<ChangeSprite>().fallenProtectSprite;
            buffTexture.GetComponent<SpriteRenderer>().sprite = sp;
            Vector3 localScale = buffTexture.transform.localScale;
            localScale.x = 1.6f;
            localScale.y = 0.4f;
            buffTexture.transform.localScale = localScale;
        }
    }
    //Left and Right button actions
    public void PointerDownLeft(){
        buttonLeft = true;
    }
    public void PointerUpLeft(){
        buttonLeft = false;
    }
    public void PointerDownRight(){
        buttonRight = true;
    }
    public void PointerUpRight(){
        buttonRight = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        //Texture2D RGBA32Texture = ChangeFormat(cursorTexture, TextureFormat.RGBA32);
        //cursorTexture.Resize(100,100);
        Debug.Log(jump);
        // Debug.Log(rejBooster);
        rejBooster = 1.2f;
        // Debug.Log(rejBooster);
		laserBuff = false;
        fallenProtect = false;

        buffTexture = transform.Find("buffTexture").gameObject;
        buttonLeft = false;
        buttonRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position.x > 7.5f){
            Vector2 position = rb.position;
            position.x = -7.5f;
            rb.position = position;
        }
        if(rb.position.x < -7.5f){
            Vector2 position = rb.position;
            position.x = 7.5f;
            rb.position = position;
        }
        movement = Input.GetAxis("Horizontal") * speed;
        if(buttonLeft && movement >= 0){
            movement -= speed;
        }
        else if (buttonRight && movement <= 0){
            movement += speed;
        }
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
            if (hitData) {
                if (hitData.transform.gameObject.GetComponent<Platform>() && 
                    storeHitPos.y > transform.position.y &&
                    Input.GetMouseButtonDown(0)) {
                    targetBoard = hitData.transform.gameObject;
                    hooked = true;
                    
                    //float distance = ((Vector2)targetBoard.transform.position - (Vector2)transform.position).magnitude;                   
                }
            }
        }
        if(transform.position.y > highestY){
            highestY = transform.position.y;
        }
        healthText.text = "Health: " + health.ToString();
        if(health > maxHealth){
            
            maxHealth = health;
        }

        if (!laserBuff && !fallenProtect)
        {
            buffTexture.GetComponent<SpriteRenderer>().sprite = null;
            
        }

    }

    void FixedUpdate() {
        if(jump == false){
            //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            Color c1 = new Color(0.54f, 0.31f, 0.21f, 1);
            //Color c2 = new Color(1, 1, 1, 0);
            lr.material = new Material(Shader.Find("Sprites/Default"));
            lr.startColor = c1;
            lr.endColor = c1;
            lr.positionCount =2;
            lineStartPoint = rb.position;
            lr.SetPosition(0, lineStartPoint);
            if(rb.position.x > 7.5f){
                Vector2 position = rb.position;
                position.x = -7.5f;
                rb.position = position;
            }
            if(rb.position.x < -7.5f){
                Vector2 position = rb.position;
                position.x = 7.5f;
                rb.position = position;
            }
        
            if (hooked) {
                if (rb.position.y >= targetBoard.transform.position.y) {
                    hooked = false;
                    rb.velocity = Vector2.zero;
                } else {
                    rb.velocity = direction * 5f;
                    lr.SetPosition(1, targetBoard.transform.position);
                }            
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
            //Cursor.SetCursor(null, Vector2.zero, cursorMode);
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
            }
        }
       
    }
    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject == targetBoard) {
            hooked = false;
            PlayerData.hooks++;
            jump = true;
        }
        if(other.relativeVelocity.y > 0){
                Vector2 v = rb.velocity;
                v.y = JUMPFORCE;
                rb.velocity = v;
                //Platform boardScript = (Platform)other.gameObject.GetComponent(typeof(Platform));
                if (jump)
                {
                    Platform board = other.gameObject.GetComponent<Platform>();                
                    SpriteRenderer sr = GetComponent<SpriteRenderer>();
                    Vector3 playerColor = new Vector3(sr.color[0], sr.color[1], sr.color[2]);
                    if (board.color == playerColor) {
                        countSameColor++;
                        if (countSameColor == 3) {
                            if (boardTutorial){
                                Time.timeScale = 0;
                                jump = false;
                                countSameColor = 0;
                                tutorial.Setup();
                                boardTutorial = false;
                            }
                            else{
                            jump = false;
                            countSameColor = 0;
                            }
                        }
                    } else {
                        countSameColor = 0;
                    }
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

    // private Texture2D ChangeFormat(Texture2D oldTexture, TextureFormat newFormat)
    // {
    //     //Create new empty Texture
    //     Texture2D newTex = new Texture2D(2, 2, newFormat, false);
    //     //Copy old texture pixels into new one
    //     newTex.SetPixels(oldTexture.GetPixels());
    //     //Apply
    //     newTex.Apply();

    //     return newTex;
    // }
}
