using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserGenerator : MonoBehaviour
{
    public GameObject LaserLeft;
	public GameObject LaserMid;
	public GameObject LaserRight;
	public Transform cameraPos;
	public float timer = 30.0f;
	//public Transform text;
	private GameObject time;
	private Score score;

	public int laserNum = 0;
	private int sequence = 0;
	private float[] order;
    // Update is called once per frame
	private void Start()
	{
		//InvokeRepeating("generateLaser", 10.0f, 10.0f);
		timer = 30.0f;
		order = new float[]{-5f,0f,5f};
	}

	private void generateLaser()
	{
		sequence ++;
		if(sequence >= 3){
			sequence = 0;
		}
		Vector3 genPosition = new Vector3(order[sequence], cameraPos.position.y+6f, 0);
		Instantiate(LaserLeft, genPosition, Quaternion.identity);
		genPosition = new Vector3(order[(sequence+1)%3], cameraPos.position.y+6f, 0);
		Instantiate(LaserMid, genPosition, Quaternion.identity);
		genPosition = new Vector3(order[(sequence+2)%3], cameraPos.position.y+6f, 0);
		Instantiate(LaserRight, genPosition, Quaternion.identity);
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
		if((int)timer <= 0 && laserNum <= 0){
			generateLaser();
			timer = 30f;
		}
	}
}
