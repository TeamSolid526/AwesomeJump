using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    public GameObject boardPrefab;
    public Transform cameraPos;

    public int numberOfPlatforms = 10;
    public float spawnRange = 10f;
    public float rangeX = 1f;
    public float minY = 0.2f;
    public float maxY = 1f;

    private float generatedY;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = Vector3.zero;

        for (int i=0; i<numberOfPlatforms; i++) {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-rangeX, rangeX);
            Instantiate(boardPrefab, spawnPosition, Quaternion.identity);
        }

        generatedY = spawnPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        while(generatedY < cameraPos.position.y+spawnRange) {
            Vector3 spawnPosition = new Vector3();
            spawnPosition.y += (generatedY + Random.Range(minY, maxY));
            spawnPosition.x = Random.Range(-rangeX, rangeX);
            Instantiate(boardPrefab, spawnPosition, Quaternion.identity);
            generatedY = spawnPosition.y;
        }
    }
}
