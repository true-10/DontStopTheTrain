using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuState : IState
{
    #region fields
    private GameMenuManager _gmManager;
    #endregion

    public GameMenuState(GameMenuManager gmManager)
    {
        _gmManager = gmManager;
    }

    public void Tick()
    {
        _gmManager.OnUpdate();
    }

    public void OnEnter()
    {
        _gmManager.OnEnter();
        //показать меню
    }

    public void OnExit()
    {
        _gmManager.OnExit();
        //скрыть меню
    }
}
