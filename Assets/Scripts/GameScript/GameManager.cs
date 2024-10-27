using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void OnEnable()
    {
        GameEvents.OnHiderFound += HandleHiderFound;
        GameEvents.OnHiderWon += HandleHiderWon;
    }

    void OnDisable()
    {
        GameEvents.OnHiderFound -= HandleHiderFound; 
        GameEvents.OnHiderWon -= HandleHiderWon;

    }

    void HandleHiderFound()
    {++Player.gameScore;
            Debug.Log("Hider has been found! game state is now: " + Player.gameScore);
        
    }
    void HandleHiderWon() 
    {--Player.gameScore;
        Debug.Log("Hider was get to StagePlayer! game state is now: " + Player.gameScore);
    }
    
}
