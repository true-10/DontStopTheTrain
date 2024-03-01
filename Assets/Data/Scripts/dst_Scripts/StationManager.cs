using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
/*
public class StationManager : MonoBehaviour
{
    #region fields
    [SerializeField] private GameObject _GUI;
    [SerializeField] private StationPlayerGUI _playerGUI;
    private bool _departureTime = false;
    private bool _gameMenuTime = false;
    [SerializeField] private CinemachineVirtualCamera _camera;
    private Player _player;
    //данные станции. список запчастей, список сервисов

    //покупка запчастей, ремонт, покупка расходников(топливо, еда)
    //отправление
    //добавление вагонов
    #endregion

    public void Init()
    {
        ResetStation();
    }

    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {//игровое меню
            _gameMenuTime = true;
        }
    }

    public void SetPlayerRef(ref Player player)
    {
        _player = player;
        _playerGUI.SetPlayerRef(ref player);
    }

    public void OnEnter()
    {
        Debug.Log("StationState OnEnter");
      //  CameraManager.Singleton.SetMainCamera(_camera);
        SetStationCamera();
        _playerGUI.UpdateGUI();
        ShowGUI(true);
        _gameMenuTime = false;
        
    }

    public void OnExit()
    {
        Debug.Log("StationState OnExit");
        ShowGUI(false);
        ResetStation();
    }

    public void SetStationCamera()
    {

    }

    public void ShowGUI(bool show)
    {
        _GUI?.SetActive(show);
    }

    public bool IsDeparureTime()
    {
        return _departureTime;
    }

    public void TimeToGo()
    {
        _departureTime = true;
    }

    public void ResetStation()
    {
        _departureTime = false;
        _gameMenuTime = false;
    }

    public bool IsGameMenuTime()
    {
        return _gameMenuTime;
    }
}


public class ShopSlot
{
    #region fields
     public enum ShopSlotType { SST_PART = 0, SST_SERVICE,  } //запчасть или сервис

    [SerializeField]
    private ShopSlotType _type;//тип слота


    [SerializeField]
    private TrainPart _partSlot;

    [SerializeField]
    private Service _serviceSlot;
    #endregion
    //условия покупки/доступности? или нафиг усложнять?
}


public class StationService
{
    #region fields

    #endregion
    //ремонт
    public void Repair(Player player, TrainManager tm)
    {

    }
    //услуги
    //какие услуги могут быть? разовые? до след станции например. доп охрана?
    //покупка запчастей
    public void BuyPart()
    {

    }
    //покупка припасов различных (еда, вода, инструменты. обобщенное такое)
    public void BuySupplies()
    {

    }

    public void BuyFuel()
    {

    }
}

public class Service
{//услуга

}

public class Supplies
{//припасы

}
*/