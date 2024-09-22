using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float timeLimit = 30f; 
    private float timer;

    void Start()
    {
        Debug.Log("Time's Start!");
        timer = timeLimit;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        { Debug.Log("Time's up!");
          Application.Quit();      
          UnityEditor.EditorApplication.isPlaying = false;   
        }
    }
}
