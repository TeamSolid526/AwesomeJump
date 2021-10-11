using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserGenerator : MonoBehaviour
{
    public GameObject Laser;
	public Transform cameraPos;
	public float timer = 30.0f;
	//public Transform text;
	private GameObject time;
	private Score score;
	public int laserNum = 1;
    // Update is called once per frame
	private void Start()
	{
		//InvokeRepeating("generateLaser", 10.0f, 10.0f);
		timer = 30.0f;
	}

	private void generateLaser()
	{
		Vector3 genPosition = new Vector3(0, cameraPos.position.y+6f, 0);
		Instantiate(Laser, genPosition, Quaternion.identity);
		laserNum++;
	}
	
	void Update(){
		//time = GameObject.Find("Text");
		//score = time.GetComponent<Score>();
		//timer = score.curTimeRemain;
		//text = text.timeRemain;
		// Debug.Log((int)timer+1);
		//timer -= Time.deltaTime;
		timer -= Time.deltaTime;
		if((int)timer <= 0 && laserNum == 0){
			generateLaser();
			timer = 30;
		}
	}
}
