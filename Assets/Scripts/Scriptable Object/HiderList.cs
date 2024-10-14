using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HiderList", menuName = "ScriptableObjects/HiderList", order = 1)]
public class HiderList : ScriptableObject
{
    public GameObject objectsToHide; // The object to instantiate for hiding
    public Vector3[] spawnPoints;    // List of spawn points
    public int numberOfSpritesToCreate; // How many objects to spawn
    public int numberOfSpawnPointsToCreate; // New public number for spawn points
}
