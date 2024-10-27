using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static event Action OnHiderFound;
    public static event Action OnHiderWon;

    public static void HiderFound()
    {
        if (OnHiderFound != null)
            OnHiderFound.Invoke();
        
    }

    public static void HiderWon()
    {   
        if (OnHiderWon != null)
            OnHiderWon.Invoke();
    }
}