using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransitionBase : MonoBehaviour
{
    protected GameState sourceState;
    [SerializeField] protected GameState targetState; 
    public GameState TargetState { get { return targetState; } }
    

    protected virtual void Awake()
    {
        sourceState = GetComponentInParent<GameState>();
        if(sourceState == null)
        {
            Debug.Log(" Unable to find source state");
        }
    }

    public virtual bool ShouldTransition()
    {
        return sourceState.isCurrentState && !sourceState.wasTranistionInto;
    }


}
