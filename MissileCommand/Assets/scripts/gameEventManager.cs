using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class gameEventManager : MonoBehaviour
{
    public static event Action OnMissileFired;
    public static event Action OnRoundAchieved;
    public static event Action OnBuildingDestroyed;

    public void missileFired()
    {
        
        OnMissileFired?.Invoke();
    }

    public void roundAchieved()
    {
        OnRoundAchieved?.Invoke();
    }

    public void buildingDestroyed()
    {
        
        OnBuildingDestroyed?.Invoke();
    }
}

