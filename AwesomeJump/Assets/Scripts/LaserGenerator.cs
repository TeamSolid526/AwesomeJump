using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserGenerator : MonoBehaviour
{
	public static int judge = 0;
    public GameObject LaserLeft;
	public GameObject LaserMid;
	public GameObject LaserRight;
	public Transform cameraPos;
	public float timer = 30.0f;
	public GameObject tutorial;
	//public Transform text;
	private GameObject time;
	private Score score;

	public int laserNum = 0;
	public int sequence = 0;
	private float[] order;
    // Update is called once per frame
	private void Start()
	{
		//InvokeRepeating("generateLaser", 10.0f, 10.0f);
		timer = 30.0f;
		order = new float[]{-0.0063f*Screen.width,0f,0.0063f*Screen.width};
		// order = new float[]{-7f, 0f, 7f};
		Vector3 genPosition = new Vector3(240f, cameraPos.position.y+6f, 0);
		Instantiate(LaserLeft, genPosition, Quaternion.identity);
		LaserLeft.transform.localScale = new Vector3(0.0068f*Screen.width, 0.3f, 0.0f);
		genPosition = new Vector3(240f, cameraPos.position.y+6f, 0);
		Instantiate(LaserMid, genPosition, Quaternion.identity);
		LaserMid.transform.localScale = new Vector3(0.0068f*Screen.width, 0.3f, 0.0f);
		genPosition = new Vector3(240f, cameraPos.position.y+6f, 0);
		Instantiate(LaserRight, genPosition, Quaternion.identity);
		LaserRight.transform.localScale = new Vector3(0.0068f*Screen.width, 0.3f, 0.0f);
		// Vector3 genPosition = new Vector3(200f, cameraPos.position.y+6f, 0);
		// Instantiate(LaserLeft, genPosition, Quaternion.identity);
		// LaserLeft.transform.localScale = new Vector3(5f, 0.3f, 0.0f);
		// genPosition = new Vector3(200f, cameraPos.position.y+6f, 0);
		// Instantiate(LaserMid, genPosition, Quaternion.identity);
		// LaserMid.transform.localScale = new Vector3(5f, 0.3f, 0.0f);
		// genPosition = new Vector3(200f, cameraPos.position.y+6f, 0);
		// Instantiate(LaserRight, genPosition, Quaternion.identity);
		// LaserRight.transform.localScale = new Vector3(5f, 0.3f, 0.0f);
	}
	private void generateLaser()
	{	
		if(judge == 0){
			Time.timeScale = 0;
			LaserTutorialScene t = tutorial.GetComponent<LaserTutorialScene>();
			t.Setup();
			judge = 1;
		}
		
		sequence ++;
		if(sequence >= 3){
			sequence = 0;
		}
		Vector3 genPosition = new Vector3(order[sequence], cameraPos.position.y+6f, 0);
		Instantiate(LaserLeft, genPosition, Quaternion.identity);
		LaserLeft.transform.localScale = new Vector3(0.0068f*Screen.width, 0.3f, 0.0f);
		genPosition = new Vector3(order[(sequence+1)%3], cameraPos.position.y+6f, 0);
		Instantiate(LaserMid, genPosition, Quaternion.identity);
		LaserMid.transform.localScale = new Vector3(0.0068f*Screen.width, 0.3f, 0.0f);
		genPosition = new Vector3(order[(sequence+2)%3], cameraPos.position.y+6f, 0);
		Instantiate(LaserRight, genPosition, Quaternion.identity);
		LaserRight.transform.localScale = new Vector3(0.0068f*Screen.width, 0.3f, 0.0f);
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
