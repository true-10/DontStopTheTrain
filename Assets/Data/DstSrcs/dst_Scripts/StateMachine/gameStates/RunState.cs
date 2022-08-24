using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RunState : IState
{
    #region fields
    //readonly 
    private TrainManager _trainManager;
    #endregion

    public RunState(TrainManager trainManager)
    {
        _trainManager = trainManager;
    }

    public void Tick()
    {
        _trainManager.OnUpdate();
    }

    public void OnEnter()
    {
        //отпаузить
        _trainManager.OnEnter();
    }

    public void OnExit()
    {
        //запаузить
        _trainManager.OnExit();
    }
}
