using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static event Action OnHiderFound;

    public static void HiderFound()
    {
        if (OnHiderFound != null)
            OnHiderFound.Invoke();
        
    }
    
}