using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    private List<GameState> states = new();
    [SerializeField] GameState currentState;
    [SerializeField] GameState defaultState;
    public GameStateChannel gameStateChannel; 

    

    void Start()
    {
        var beacon = FindObjectOfType<Beacon>();
        gameStateChannel = beacon.gameStateChannel;
       
        gameStateChannel.StateEnter += StateEnter;
      
        foreach(var state in GetComponentsInChildren<GameState>())
        {
            states.Add(state);
        }

        if(currentState == null)
        {

            gameStateChannel.StateEntered(defaultState.stateSo);
        }

        SceneManager.sceneLoaded += AnnounceStateOnSceneLoades;

    }

    private void AnnounceStateOnSceneLoades(Scene arg0, LoadSceneMode arg1)
    {
        var state = currentState;
        if (state == null)
        {

            state = states.FirstOrDefault(x => x.isCurrentState);
        }
        gameStateChannel.StateEntered(state.stateSo);
    }

    private void StateEnter(StateSo state)
    {
        currentState = states.FirstOrDefault(x=>x.stateSo==state);
        Debug.Log(state.name);


    }

    private void OnDestroy()
    {
        gameStateChannel.StateEnter -= StateEnter;
        SceneManager.sceneLoaded -= AnnounceStateOnSceneLoades;

    }




}
