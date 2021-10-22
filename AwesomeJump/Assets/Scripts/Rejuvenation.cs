using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RejProperty
{
    public string type;
    public float value;
    public float rejBonus;
    public bool fragile;

    public RejProperty() {
        type = "buff";
        value = 20;    
        rejBonus = 1.0f;
        fragile = true;
    }

    public RejProperty(string tp, float val, float rb, bool frg=true){
        type = tp;
        value = val;
        rejBonus = rb;
        fragile = true;
    }

}

public class Rejuvenation : MonoBehaviour
{
    public RejProperty property;
    public string type = "buff";
    public float value = 20.0f;
    public float rejBonus = 1.0f;
    public bool fragile = true;

    // Start is called before the first frame update
    void Start()
    {
        property = new RejProperty("buff", 20, 1, true);
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        // if (this.transform.position.y < stageDimensions.y) {
        //     Destroy(this.gameObject);
        // }
    }

    void OnTriggerEnter2D(Collider2D collision){
        
        if (property.type == "buff") {
            float bonus = property.value * property.rejBonus;
            collision.gameObject.GetComponent<Player>().health += (int) bonus;
            property.rejBonus *= 1.2f;
        }
        
        // if (property.fragile){
        //         Destroy(this.gameObject);
        //         return;
        //     }
    }

}
