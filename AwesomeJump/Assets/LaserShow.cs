using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserShow : MonoBehaviour
{
    public Image left;
    public Image mid;
    public Image right;
    private float[] order;
    private float time;
    private int sequence = 0;
    // Start is called before the first frame update
    void Start()
    {
        order = new float[]{323.1f,563.8f,790.6f};
    }

    // Update is called once per frame
    void Update()
    {
        time = GameObject.Find("LaserGenerator").GetComponent<LaserGenerator>().timer;
        sequence = GameObject.Find("LaserGenerator").GetComponent<LaserGenerator>().sequence;
        // Debug.Log("right"+right.transform.position);
        // Debug.Log("Mid"+mid.transform.position);
        // Debug.Log("Left"+left.transform.position);
        if((int) time <= 5){
            left.transform.position = new Vector3(order[(sequence+1)%3], left.transform.position.y, 0);
            mid.transform.position = new Vector3(order[(sequence+2)%3], left.transform.position.y, 0);
            right.transform.position = new Vector3(order[(sequence)%3], left.transform.position.y, 0);
        }
        else{
            left.transform.position = new Vector3(-200, left.transform.position.y, 0);
            mid.transform.position = new Vector3(-200, left.transform.position.y, 0);
            right.transform.position = new Vector3(-200, left.transform.position.y, 0);
        }
        
    }
}
