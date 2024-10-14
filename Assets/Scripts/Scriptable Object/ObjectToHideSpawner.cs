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
                GameObject newObject = Instantiate(spawnManager.objectsToHide, hidingSpots[i % hidingSpots.Count], Quaternion.identity);
                newObject.name = spawnManager.objectsToHide.name + instanceNumber;
                instanceNumber++;
            }
        }
    }

    // Generate random valid spawn points on the tilemap
    List<Vector3> GenerateSpawnPointsOnTilemap(int numberOfPoints)
    {
        List<Vector3> spawnPoints = new List<Vector3>();
        BoundsInt bounds = targetTilemap.cellBounds;

        int pointsCreated = 0;
        while (pointsCreated < numberOfPoints)
        {
            int x = Random.Range(bounds.xMin, bounds.xMax);
            int y = Random.Range(bounds.yMin, bounds.yMax);
            Vector3Int cellPosition = new Vector3Int(x, y, 0);

            if (targetTilemap.HasTile(cellPosition)) // Check if the tilemap has a tile at this position
            {
                Vector3 worldPosition = targetTilemap.CellToWorld(cellPosition) + targetTilemap.cellSize / 2;
                spawnPoints.Add(worldPosition);
                pointsCreated++;
            }
        }

        return spawnPoints;
    }
}
