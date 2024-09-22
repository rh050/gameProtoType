using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void OnEnable()
    {
        GameEvents.OnHiderFound += HandleHiderFound;
    }

    void OnDisable()
    {
        GameEvents.OnHiderFound -= HandleHiderFound; 
    }

    void HandleHiderFound()
    {
            Debug.Log("Hider has been found! game state is now: " + Player.gameScore);
        
        
        
    }
}
