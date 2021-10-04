using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRemove : MonoBehaviour
{
	private GameObject laser;
	public int laserNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		laser = GameObject.Find("LaserGenerator");
		laserNum = laser.GetComponent<LaserGenerator>().laserNum;
		
		Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        if (this.transform.position.y < stageDimensions.y) {
            Destroy(this.gameObject);
			laser.GetComponent<LaserGenerator>().laserNum -= 1;
        }
    }
}
