using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour
{
    public HiderList[] spawnManagerValues;
    public Tilemap targetTilemap;
    public int numberOfSpawnPointsToCreate = 5;

    int instanceNumber = 1;

    void Start()
    {
        SpawnEntities();
    }

    void SpawnEntities()
    {
        List<Vector3> hidingSpots = GenerateSpawnPointsOnTilemap(numberOfSpawnPointsToCreate);

        foreach (var spawnManager in spawnManagerValues)
        {
            for (int i = 0; i < spawnManager.numberOfSpritesToCreate; i++)
            {
                Vector3 spawnPosition = hidingSpots[i % hidingSpots.Count];
                GameObject newObject = Instantiate(spawnManager.objectsToHide, spawnPosition, Quaternion.identity);
                newObject.name = spawnManager.objectsToHide.name + instanceNumber;
                instanceNumber++;
            }
        }
    }

    // Generate unique random spawn points on the tilemap
    List<Vector3> GenerateSpawnPointsOnTilemap(int numberOfPoints)
    {
        List<Vector3> spawnPoints = new List<Vector3>();
        HashSet<Vector3> usedPositions = new HashSet<Vector3>(); 

        int pointsCreated = 0;
        while (pointsCreated < numberOfPoints)
        {
            Vector3Int cellPosition = GetRandomCellPosition(); 

            if (targetTilemap.HasTile(cellPosition))
            {
                Vector3 worldPosition = targetTilemap.GetCellCenterWorld(cellPosition); 

                if (!usedPositions.Contains(worldPosition))
                {
                    spawnPoints.Add(worldPosition);
                    usedPositions.Add(worldPosition); 
                    pointsCreated++;
                }
            }
        }

        return spawnPoints;
    }

    Vector3Int GetRandomCellPosition()
    {
        BoundsInt bounds = targetTilemap.cellBounds;
        int x = Random.Range(bounds.xMin, bounds.xMax);
        int y = Random.Range(bounds.yMin, bounds.yMax);
        return new Vector3Int(x, y, 0);
    }
}
