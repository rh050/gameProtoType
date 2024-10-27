using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Security.Cryptography.X509Certificates;

public class GameState : MonoBehaviour
{
    public StateSo stateSo;
    public bool isCurrentState = false;
    public GameState nextState = null;
    public GameState previousState = null;
    private GameStateChannel gameStateChannel;
    public bool wasTranistionInto = false;
    public bool inTransition = false;
    private List<TransitionBase> transitionBase = new();
    public string stateName;

    void Start()
    {
      
        gameStateChannel = FindObjectOfType<Beacon>().gameStateChannel;

        gameStateChannel.StateEnter += StateEnter;

        foreach (var transition in GetComponentsInChildren<TransitionBase>())
        {
            transitionBase.Add(transition);

        }

    }


    void Update()
    {
        if (!isCurrentState)
            return;

        nextState = null;
        foreach( var transition in transitionBase.Where(x=>x.ShouldTransition()) )
        {
            if(transition.TargetState!=null)
            {
                nextState = transition.TargetState;
                break;
            }
        }


        if(!inTransition && nextState!=null)
        {
            inTransition = true;
            StateExit(nextState);
            inTransition = false;
        }

        if(wasTranistionInto)
        {
            wasTranistionInto = false;
        }

    }

    public virtual void StateEnter(StateSo previous)
    {

        isCurrentState = true;           
        wasTranistionInto = true;
    }

    public virtual void StateExit(GameState next)
    {
        isCurrentState = false;
        gameStateChannel.StateExited(this.stateSo);
        next.StateEnter(this.stateSo);
    }

    void OnDestroy()
    {
        if (gameStateChannel != null)
        {
            gameStateChannel.StateEnter -= StateEnter;
        }
    }


}
