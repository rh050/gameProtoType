using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CaveDisplayCode : MonoBehaviour
{
   public Tilemap caveTilemap;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         caveTilemap.GetComponent<TilemapRenderer>().enabled = false;
      }
   }
   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         caveTilemap.GetComponent<TilemapRenderer>().enabled = true;
      }
   }
}
