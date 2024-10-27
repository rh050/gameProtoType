using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game State Channel " , menuName = "Channels/ Game state " , order =0)]
public class GameStateChannel : ScriptableObject
{
    public Action <StateSo> StateEnter;
    public Action <StateSo> StateExit;
    public Func  <StateSo> GetCurrentState;


    public void StateEntered(StateSo gameState)
    {
        StateEnter?.Invoke(gameState);
    }

    public void StateExited(StateSo gameState)
    {
        StateExit?.Invoke(gameState);
    }


    public StateSo GetCurrentGameState()
    {
        return GetCurrentState?.Invoke();
    }



  
        
    
}
