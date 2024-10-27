using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HiderSpawner : MonoBehaviour
{
    public GameObject hiderPrefab;
    [FormerlySerializedAs("hiderCount")]
    public int hidersToCreate = 1;
    public float spawnRangeXMin = 9f;
    public float spawnRangeXMax = 20f;
    public float spawnRangeYMin = 20f;
    public float spawnRangeYMax = 0f;
    public static int hidersThatCreate;


    void Start()
    {
        for (int i = 0; i < hidersToCreate; i++)
        {
            Vector2 randomPosition = new Vector2(Random.Range(-spawnRangeXMin, spawnRangeXMax), Random.Range(-spawnRangeYMin, spawnRangeYMax));
            Instantiate(hiderPrefab, randomPosition, Quaternion.identity);
        }
        hidersThatCreate=hidersToCreate;
    }
}
