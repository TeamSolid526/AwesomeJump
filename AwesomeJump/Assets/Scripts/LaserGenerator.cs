using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGenerator : MonoBehaviour
{
    public GameObject Laser;
	public Transform cameraPos;
	public float timer = 10.0f;
    // Update is called once per frame
	private void Start()
	{
		//InvokeRepeating("generateLaser", 10.0f, 10.0f);
	}

	private void generateLaser()
	{
		Vector3 genPosition = new Vector3(0, cameraPos.position.y+6f, 0);
		Instantiate(Laser, genPosition, Quaternion.identity);
		
	}
	
	void Update(){
		Debug.Log((int)timer+1);
		timer -= Time.deltaTime;
		if(timer <= 0){
			generateLaser();
			timer = 10.0f;
		}
	}
	
}
