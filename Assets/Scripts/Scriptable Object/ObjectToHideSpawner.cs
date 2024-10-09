using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public HiderList[] spawnManagerValues; 

    int instanceNumber = 1;

    void Start()
    {
        SpawnEntities();
    }

    void SpawnEntities()
    {
        foreach (var spawnManager in spawnManagerValues)
        {
            int currentSpawnPointIndex = 0;

            for (int i = 0; i < spawnManager.numberOfSpritesToCreate; i++)
            {
                GameObject newObject = Instantiate(spawnManager.objectsToHide, spawnManager.spawnPoints[currentSpawnPointIndex], Quaternion.identity);
                newObject.name = spawnManager.objectsToHide.name + instanceNumber;
                instanceNumber++;

                // Update spawn point index
                currentSpawnPointIndex++;
                if (currentSpawnPointIndex >= spawnManager.spawnPoints.Length)
                {
                    currentSpawnPointIndex = 0; // Loop back to the start
                }
            }
        }
    }
}
