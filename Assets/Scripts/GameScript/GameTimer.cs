using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timeLimit = 30f; 
    private float timer;
    private string finalScene = "ExitScene";
    public StateSo exitStateSo;
    public GameStateChannel gameStateChannel;
  

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
            GameOver();
        }
        if (Player.hiderStopPlay==HiderSpawner.hidersThatCreate+1)
        {
            if (Player.gameScore==HiderSpawner.hidersThatCreate+1)
            {   
                Debug.Log("Seeker has won!");
                GameOver();
            }
            else
            {
                Debug.Log("Hider has won!");
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        if (gameStateChannel != null && exitStateSo != null)
        {
            gameStateChannel.StateEntered(exitStateSo);

            Debug.Log("Transitioning to ExitStateSo");
        }
        else
        {
            Debug.Log("GameStateChannel or ExitStateSo is not set!");
        }

        SceneManager.LoadScene(finalScene);

        Application.Quit();

    }



}
