using DontStopTheTrain;
using DontStopTheTrain.Events;
using DontStopTheTrain.Gameplay;
using DontStopTheTrain.Train;
using DontStopTheTrain.UI;
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
    private Train _train;
    [SerializeField] 
    private UIController _uiController;

    public override void InstallBindings()
    {
        InstallStaticDataManagers();
        InstallManagers();
        InstallControllers(); 
        InstallFabrics();
        InstallServices();
        InstallTrain();
    }

    private void InstallStaticDataManagers()
    {
        Container.Bind<ItemsStaticManager>().AsSingle();
        Container.Bind<RewardsStaticManager>().AsSingle();
        Container.Bind<EventsStaticManager>().AsSingle();
        Container.Bind<LevelsStaticManager>().AsSingle();
        Container.Bind<PerkStaticManager>().AsSingle();
    }

    private void InstallManagers()
    {
        Container.Bind<EventsManager>().AsSingle();
        Container.Bind<EventViewersManager>().AsSingle();
        Container.Bind<PerkManager>().AsSingle();
        
    }

    private void InstallControllers()
    {
        Container.Bind<Inventory>().AsSingle();
        Container.Bind<TurnBasedController>().FromInstance(_turnBasedController).AsSingle();       
        Container.Bind<ICameraController>().FromInstance(_cameraController).AsSingle();
        Container.Bind<UIController>().FromInstance(_uiController).AsSingle();
        Container.Bind<Player>().AsSingle();
        Container.Bind<EventController>().AsSingle();
        Container.Bind<RewardController>().AsSingle();
        Container.Bind<EventStarter>().AsSingle();
        Container.Bind<EventGenerator>().AsSingle();
        Container.Bind<PerkController>().AsSingle();
    }

    private void InstallFabrics()
    {
        Container.Bind<ConditionFabric>().AsSingle();
        Container.Bind<EventFabric>().AsSingle();
        Container.Bind<PerksFabric>().AsSingle();
    }

    private void InstallServices()
    {
        Container.Bind<EventsService>().AsSingle();
    }

    private void InstallTrain()
    {
        Container.Bind<Train>().FromInstance(_train).AsSingle();
    }

}
