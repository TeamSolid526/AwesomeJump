using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenProtect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // destroy object out of screen
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        if (this.transform.position.y < stageDimensions.y) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p)
        {
            p.fallenProtect = true;
            p.ChangeSprite();
            // destroy object after player hit
            Destroy(this.gameObject);
        }
    }
}
