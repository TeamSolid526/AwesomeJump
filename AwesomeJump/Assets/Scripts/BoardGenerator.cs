using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class BoardGenerator : MonoBehaviour
{
    public GameObject boardPrefab;
    public Transform cameraPos;

    public int numberOfPlatforms = 5;
    public float spawnRange = 10f;
    public float rangeX = 7f;
    public float minY = 0.2f;
    public float maxY = 1.5f;

    private float generatedY = 0;
    private readonly System.Random _random = new System.Random();

    // Attenuation rate of the possibility to generate double board
    public float doubleBoardWeight_P = 1.0f;
    public float doubleBoardWeight_G = 1.0f;
    // The min distance between double boards in the same height
    public float doubleBoardGap = 0.5f;
    // Record the last coordinateY generating double boards
    private float prevDoubleY = 0;
    

    // Calculate the possibility to generate two board with the same height
    private float Probability(int height) {
        return (float)(Exp(-doubleBoardWeight_P*height)*100);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i=0; i<numberOfPlatforms; i++) {
            spawnPosition.y += Random.Range(minY, maxY);
            float flag = _random.Next(100);
            // Generate single board
            if (flag >= Probability((int)spawnPosition.y) && spawnPosition.y-prevDoubleY<=doubleBoardWeight_G*spawnPosition.y) {
                spawnPosition.x = Random.Range(-rangeX, rangeX);
                GameObject board = Instantiate(boardPrefab, spawnPosition, Quaternion.identity);
                Platform p = board.GetComponent<Platform>();
                p.single = true;

            }
            // Generate double boards
            else {
                spawnPosition.x = Random.Range(-rangeX, -doubleBoardGap/2);
                Instantiate(boardPrefab, spawnPosition, Quaternion.identity);
                spawnPosition.x = Random.Range(doubleBoardGap/2, rangeX);
                Instantiate(boardPrefab, spawnPosition, Quaternion.identity);
                // Update prevDoubleY if generating double 
                prevDoubleY = spawnPosition.y;
            }
            generatedY = spawnPosition.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        while(generatedY < cameraPos.position.y+spawnRange) {
            Vector3 spawnPosition = new Vector3();
            spawnPosition.y += (generatedY + Random.Range(minY, maxY));
            float flag = _random.Next(100);
            // Generate single board
            Debug.Log(flag);
            Debug.Log(Probability((int)spawnPosition.y));
            Debug.Log(spawnPosition.y-prevDoubleY);
            Debug.Log(doubleBoardWeight_G*spawnPosition.y);
            if (flag >= Probability((int)spawnPosition.y) && spawnPosition.y-prevDoubleY<=doubleBoardWeight_G*spawnPosition.y) {
                spawnPosition.x = Random.Range(-rangeX, rangeX);
                GameObject board = Instantiate(boardPrefab, spawnPosition, Quaternion.identity);
                Platform p = board.GetComponent<Platform>();
                p.single = true;
            }
            // Generate double boards
            else {
                spawnPosition.x = Random.Range(-rangeX, -doubleBoardGap/2);
                Instantiate(boardPrefab, spawnPosition, Quaternion.identity);
                spawnPosition.x = Random.Range(doubleBoardGap/2, rangeX);
                Instantiate(boardPrefab, spawnPosition, Quaternion.identity);
                // Update prevDoubleY if generating double 
                prevDoubleY = spawnPosition.y;
            }
            generatedY = spawnPosition.y;
        }
    }
}
