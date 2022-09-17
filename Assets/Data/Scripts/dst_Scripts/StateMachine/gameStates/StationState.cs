using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class StationState : IState
{
    #region fields
    //readonly 
    private StationManager _stationManager;
    #endregion

    public StationState(StationManager stationManager)
    {
        _stationManager = stationManager;
    }
    public void Tick()
    {
        _stationManager.OnUpdate();
    }

    public void OnEnter()
    {        
        _stationManager.OnEnter();
        
    }

    public void OnExit()
    {
        _stationManager.OnExit();
    }
}
