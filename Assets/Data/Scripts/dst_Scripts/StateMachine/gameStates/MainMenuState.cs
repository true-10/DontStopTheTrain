using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : IState
{
    #region fields
    private MainMenuManager _maiMenuManager;
    #endregion

    public MainMenuState(MainMenuManager maiMenuManager)
    {
        _maiMenuManager = maiMenuManager;
    }
    public void Tick()
    {
        _maiMenuManager.OnUpdate();
    }

    public void OnEnter()
    {
        //показать меню
        _maiMenuManager.OnEnter();
    }

    public void OnExit()
    {
        //скрыть меню
        _maiMenuManager.OnExit();
    }
}
