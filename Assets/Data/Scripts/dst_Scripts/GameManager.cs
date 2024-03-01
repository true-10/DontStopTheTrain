using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    #region fields
    [SerializeField] private TrainManager   _trainManager;
   // [SerializeField] private StationManager _stationManager;
    [SerializeField] private MainMenuManager _mainMenuManager;
    [SerializeField] private GameMenuManager _gameMenuManager;
    private StateMachine _stateMachine;
    
    #endregion

    void InitStateMachine()
    {
        Debug.Log("GameManager InitStateMachine");
        _stateMachine = new StateMachine();

        var RunState = new RunState(_trainManager);
      //  var StationState = new StationState(_stationManager);
        var MMenuState = new MainMenuState(_mainMenuManager);
        var GMenuState = new GameMenuState(_gameMenuManager);


        //_stateMachine.AddTransition(StationState, RunState, ItsDepartureTime() );   //из станции в путь
        //_stateMachine.AddTransition(RunState, StationState, ItsStationTime() );     //остановка с дороги на станции
        //_stateMachine.AddTransition(MMenuState, StationState, ItsTimeToPlay() );    //из главного меню на станцию
        _stateMachine.AddTransition(GMenuState, MMenuState, BackToMainMenu() );     //из игрового меню в главное
       // _stateMachine.AddTransition(StationState, GMenuState, GameMenuFromStation() );//из станции в игровое меню
        //_stateMachine.AddTransition(RunState, GMenuState, GameMenuFromRun() );      //из дороги в игровое меню
        //  _stateMachine.AddTransition(GMenuState, MMenuState, ItsTimeToPlay() );

        //_stateMachine.AddAnyTransition(GMenuState, () => _stationManager.IsGameMenuTime() || _trainManager.IsGameMenuTime());

        // _stateMachine.SetState(StationState);
        _stateMachine.SetState(MMenuState);

        Debug.Log("GameManager InitStateMachine complete");
      //  Func<bool> ItsDepartureTime() => () => _stationManager.IsDeparureTime();//время отправляться
        Func<bool> ItsStationTime() => () => _trainManager.IsStoped();          //время остановки на станции
        Func<bool> ItsTimeToPlay() => () => _mainMenuManager.IsReadyToPlay();   //время остановки на станции
        Func<bool> BackToMainMenu() => () => _gameMenuManager.IsReadyToGoToMainMenu();  //идем в главное меню
      //  Func<bool> GameMenuFromStation() => () => _gameMenuManager.IsReadyToResume();   //игровое меню из станции
       // Func<bool> GameMenuFromRun() => () => _gameMenuManager.IsReadyToResume();       //игровое меню из дороги

    }

    private void Start()
    {
        Debug.Log("GameManager Start");
        _trainManager.Init();
        //_trainManager.SetPlayerRef(ref _player);
        //_trainManager.OnExit();
     //   _stationManager.Init();
        //_stationManager.SetPlayerRef(ref _player);
        //_stationManager.OnExit();
        //  _gameMenuManager.OnExit();
        //  _mainMenuManager.OnExit();

        InitStateMachine();

        Debug.Log("GameManager Start complete");
    }

    private void Update()
    {
        _stateMachine.Tick();
    }
}
