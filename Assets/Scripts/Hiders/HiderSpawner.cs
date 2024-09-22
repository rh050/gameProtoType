using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderSpawner : MonoBehaviour
{
    public GameObject hiderPrefab;
    public int hiderCount = 1;
    public float spawnRangeXMin = 9f;
    public float spawnRangeXMax = 20f;
    public float spawnRangeYMin = 20f;
    public float spawnRangeYMax = 0f;


    void Start()
    {
        for (int i = 0; i < hiderCount; i++)
        {
            Vector2 randomPosition = new Vector2(Random.Range(-spawnRangeXMin, spawnRangeXMax), Random.Range(-spawnRangeYMin, spawnRangeYMax));
            Instantiate(hiderPrefab, randomPosition, Quaternion.identity);
        }
    }
}
