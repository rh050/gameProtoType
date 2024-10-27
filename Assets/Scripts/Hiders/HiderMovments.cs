using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderMovments : MonoBehaviour
{
    public float speed = 3f;
    public static bool isCaught = false;
    public Vector2 startingPosition;
    public List<Vector3> hidingSpots;
    public Transform player;
    public Transform StagePlayer;
    public float distanceHiderStartGoingOut = 15f; 
    public float dificulty = 3f;
    private Coroutine currentCoroutine;
    private Vector2 targetPosition;
    private float distanceHiderToPlayer;
    private float distanceHiderToStagePlayer;
    private float distancePlayerToStagePlayer;
    private bool goingToHideout = true;
    private bool goingToStagePlayer = false;
    private GameObject[] hidingSpotsEr;
    private List<Vector2> availableHidingSpots = new List<Vector2>();


    void Start()
    {
        transform.position = startingPosition + new Vector2(0, -0.5f);
        StartMoveToHidingSpot(0); 
        
        // Find and store all hiding spots at the start
        GameObject[] hidingSpotsEr = GameObject.FindGameObjectsWithTag("ObjectsToHide");
        foreach (GameObject hideSpot in hidingSpotsEr)
        {
            availableHidingSpots.Add(hideSpot.transform.position);
        }
    }

    void Update()
    {
        distanceHiderToPlayer = Vector2.Distance(transform.position, player.position);
        distanceHiderToStagePlayer = Vector2.Distance(transform.position, StagePlayer.position);
        distancePlayerToStagePlayer = Vector2.Distance(player.position, StagePlayer.position);
        if (distanceHiderToPlayer > distanceHiderStartGoingOut)
        {
            if (!goingToHideout)
            {
                StartMoveToStagePlayer();
            }
        }
        
    }

    void StartMoveToHidingSpot(int index)
    {
        goingToHideout = true; // semaphore
        while (hidingSpotsEr==null)
        {
            hidingSpotsEr = GameObject.FindGameObjectsWithTag("ObjectsToHide");
        }
        foreach (GameObject hideSpot in hidingSpotsEr)
        {
            hidingSpots.Add(hideSpot.transform.position);
        }

        targetPosition = hidingSpots[Random.Range(0, hidingSpots.Count)];

        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine); 
        }
        currentCoroutine = StartCoroutine(MoveToPosition(targetPosition));

        while ((Vector2)transform.position == targetPosition)
        {
            goingToHideout = false;
        }
        StartMoveToStagePlayer();
    }

    void StartMoveToStagePlayer()
    {
        if (!goingToHideout)
        {
            waiter(dificulty);
            GoToStagePlayer();
        }
        else
        {
            GoToHideSpot();
        }
    }
    
    void GoToStagePlayer()
    {
        if (!goingToHideout)
        {
            goingToStagePlayer = true;
            if (distanceHiderToStagePlayer < distancePlayerToStagePlayer)
            {
                goingToStagePlayer = true;
                if (currentCoroutine != null)
                {
                    StopCoroutine(currentCoroutine);
                }
                currentCoroutine = StartCoroutine(MoveToPosition(StagePlayer.position));
            }
            goingToStagePlayer = false;
        }
        
    }
    
    
    void GoToHideSpot()
    {
        if (!goingToStagePlayer)
        {
            goingToHideout = true;
            currentCoroutine = StartCoroutine(MoveToPosition(targetPosition));
            while ((Vector2)transform.position == targetPosition)
            {
                goingToHideout = false;
            }
            GoToStagePlayer();
        }
        goingToHideout = false;

    }
    
    

    IEnumerator waiter(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); 
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
        if (other.CompareTag("Player"))
        {
            isCaught = true;
            if (isCaught)
            {
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                ++Player.hiderStopPlay;
                GetComponent<SpriteRenderer>().color = Color.black;
                Debug.Log("Hider caught!");
                //go to the stage player
                if (currentCoroutine != null)
                {
                    StopCoroutine(currentCoroutine);
                }
                //move to starting position
                currentCoroutine = StartCoroutine(MoveToPosition(startingPosition));
                GameEvents.HiderFound();
            }
        }
        if (other.CompareTag("StagePlayer"))
        {
            if (!isCaught)
            {
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                ++Player.hiderStopPlay;
                isCaught = true;
                if (currentCoroutine != null)
                {
                    StopCoroutine(currentCoroutine);
                }
                currentCoroutine = StartCoroutine(MoveToPosition(StagePlayer.position));
                GameEvents.HiderWon();
            }

        }
    }
}