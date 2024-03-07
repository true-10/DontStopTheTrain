using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

using DG.Tweening;

public class TrainManager : MonoBehaviour
{
    #region fields
    [SerializeField] private Locomotiv _locomotiv;//локомотив
    [SerializeField] private TrainGUI _trainGUI;//
    [SerializeField] private CinemachineVirtualCamera _droneCam;//
    [SerializeField] private CinemachineVirtualCamera _fpsCam;//
    [SerializeField] private List<CinemachineVirtualCamera> _cams;//
  //  [SerializeField] private TrainDroneCam _DroneCamController;//
    //[SerializeField] private CharMovement _char;//
    private bool _FPSModeOn = false;
    private bool _gameMenuTime = false;
    [SerializeField] private List<Wagon_obsolete> _wagons;//кол-во вагонов
    //
    //private Player _player;
    #endregion
    public void Init()
    {
        _locomotiv.Init();
        _trainGUI.SetLoco(_locomotiv);

    }
    public void OnUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) AnimTest();
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (_FPSModeOn == false)
            {
              //  CameraManager.Singleton.SetMainCamera(_fpsCam);
                _FPSModeOn = true;
            }
            else
            {
                //CameraManager.Singleton.SetMainCamera(_droneCam);
                _FPSModeOn = false;
            }
            
        }

        _locomotiv.OnUpdate();
        _trainGUI.OnUpdate();
        if(_FPSModeOn)
        {
            FPSUpdate();
        }
        else
        {
            NotFPSUpdate();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {//игровое меню
            _gameMenuTime = true;
        }
    }
    void SwitchMode()
    {

    }

    void FPSUpdate()
    {
        //_char.OnUpdate();
    }

    void NotFPSUpdate()
    {
        if (Input.GetKeyDown(KeyCode.V)) NextCam();
        //if (Input.GetKeyDown(KeyCode.F)) CameraManager.Singleton.SetMainCamera(_droneCam);
        //_DroneCamController.OnUpdate();

    }

    void AnimationsUpdate()
    {

    }
    
    public void OnEnter()
    {
        Debug.Log("TrainManager OnEnter");
        Init();
        Cursor.visible = false;
      //      CameraManager.Singleton.SetMainCamera(_droneCam);
        _locomotiv.Depart();
        _trainGUI.gameObject.SetActive(true);

        _gameMenuTime = false;
        //установить камеру поезда
    }

    public void OnExit()
    {
        Debug.Log("TrainManager OnExit");
        Cursor.visible = true;
        _locomotiv.ReSetParams();
        _trainGUI.gameObject.SetActive(false);
        _gameMenuTime = false;
    }


    public bool IsGameMenuTime()
    {
        return _gameMenuTime;
    }

    public void AddWagon(Wagon_obsolete newWagon)
    {

    }

    public void SpeedCalc()
    {
        //расчет скорости в зависимости от кол-ва вагонов и моощности локомотив(двигатель, может еще что)

    }
    #region cams switcher
    private int _currentCamIndex = 0;
    void NextCam()
    {
        if (_cams.Count < 1) return;
        _currentCamIndex++;
        if (_currentCamIndex > _cams.Count - 1) _currentCamIndex = 0;

     //   CameraManager.Singleton.SetMainCamera(_cams[_currentCamIndex]);
       
    }

    #endregion

    #region train controls
    public void SetSpeedBy(float newSpeed, float duration)
    {
        _locomotiv.SetSpeedBy(newSpeed, duration);
    }

    public void SetDefaultSpeed(float duration)
    {
        _locomotiv.SetDefaultSpeed(duration);
    }

    public void StopTrain(float duration)
    {//остановка на станции
        _locomotiv.StopTrain(duration);
    }

    public bool IsStoped()
    {
        return _locomotiv.IsStoped();
    }

    #endregion

    /*
     #region player data controls
  public void SetPlayerRef(ref Player player)
     {
         _player = player;
     }

     public void AddExpo(float expo)
     {
         _player.AddExpo( expo );
     }
     #endregion
     /*
     void SuppliesUpdate()
     {
         //чем больше сотрудников, тем быстрее тратятся
     }

     void FuelUpdate()
     {
         //чем мощнее двигатель, чем больше вагонов, тем быстрее тратится
     }

     void UpdateParams()
     {

     }

     void PartsUpdate()
     {
         //обновление запчастей(износ там и все такое)
     }
     */
}