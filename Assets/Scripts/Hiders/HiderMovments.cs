using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderMovments : MonoBehaviour
{
    public float speed = 3f;
    public static bool isCaught = false;
    public Vector2 startingPosition;
    public List<Vector3> hidingSpots; 
    

    void Start()
    {
        transform.position = startingPosition;
        MoveToHidingSpot(0); 
    }

    void MoveToHidingSpot(int index)
    {
        if (index < 0 || index >= hidingSpots.Count) return; 

        Vector2 targetPosition = hidingSpots[Random.Range(0, hidingSpots.Count)];

        StartCoroutine(MoveToPosition(targetPosition));
        
    }

    IEnumerator MoveToPosition(Vector2 targetPosition)
    {
        while ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

       
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") )
        {
            GameEvents.HiderFound();
            isCaught = true;
            GetComponent<SpriteRenderer>().color = Color.black;
            StartCoroutine(MoveToPosition( new Vector2(2.7f,-9f)));
            Debug.Log("Hider caught!");
        }
    }
}
