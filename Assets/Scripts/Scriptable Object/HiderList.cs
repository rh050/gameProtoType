using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HiderList", menuName = "ScriptableObjects/HiderList", order = 1)]
public class HiderList : ScriptableObject
{
    public GameObject objectsToHide;
    public Vector3[] spawnPoints;    
    public int numberOfSpritesToCreate; 
    public int numberOfSpawnPointsToCreate; 
}
