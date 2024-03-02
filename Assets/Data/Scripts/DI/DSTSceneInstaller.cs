using DontStopTheTrain;
using DontStopTheTrain.Events;
using DontStopTheTrain.Gameplay;
using System;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

public class DSTSceneInstaller : MonoInstaller
{ 
    [SerializeField] 
    private CameraController _cameraController;
    [SerializeField] 
    private TurnBasedController _turnBasedController;
    [SerializeField] 
    private EventInitDataManager _eventInitDataManager;

    public override void InstallBindings()
    {
        InstallStaticDataManagers();
        InstallManagers();
        InstallControllers();
    }

    private void InstallStaticDataManagers()
    {
        Container.Bind<ItemsStaticManager>().AsSingle();
        Container.Bind<RewardsStaticManager>().AsSingle();
        Container.Bind<EventsStaticManager>().AsSingle();
        Container.Bind<LevelsStaticManager>().AsSingle();
    }

    private void InstallManagers()
    {
        Container.Bind<EventInitDataManager>().FromInstance(_eventInitDataManager).AsSingle();
        Container.Bind<EventsManager>().AsSingle();
        
    }

    private void InstallControllers()
    {
        Container.Bind<Inventory>().AsSingle();
        Container.Bind<TurnBasedController>().FromInstance(_turnBasedController).AsSingle();       
        Container.Bind<ICameraController>().FromInstance(_cameraController).AsSingle();
        Container.Bind<Player>().AsSingle();
    }

}
