using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "HiderObjects", menuName = "HiderObjects/NewHiderObject")]
public class HiderList : ScriptableObject
{
   public GameObject  objectsToHide; 
   public int numberOfSpritesToCreate;
   public Vector3[] spawnPoints;
}

