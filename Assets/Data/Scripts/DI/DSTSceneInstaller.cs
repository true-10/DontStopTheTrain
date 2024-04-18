using DontStopTheTrain;
using DontStopTheTrain.Events;
using DontStopTheTrain.Train;
using DontStopTheTrain.UI;
using System;
using True10.CameraSystem;
using True10.LevelScrollSystem;
using UnityEngine;
using Zenject;
public class DSTSceneInstaller : MonoInstaller
{ 
    [SerializeField] 
    private TurnBasedController _turnBasedController;
    [SerializeField] 
    private UIController _uiController;
    [SerializeField]
    private ConditionsStaticStorage _conditionsStaticStorage;
    [SerializeField]
    private QuestsStaticStorage _questsStaticStorage;
    [SerializeField]
    private LevelScrollController _levelScrollController;

    public override void InstallBindings()
    {
        InstallStaticDataManagers();
        InstallManagers();
        InstallControllers(); 
        InstallFabrics();
        InstallServices();
    }

    private void InstallStaticDataManagers()
    {
        Container.Bind<ConditionsStaticStorage>().FromScriptableObject(_conditionsStaticStorage).AsSingle();
        Container.Bind<QuestsStaticStorage>().FromScriptableObject(_questsStaticStorage).AsSingle();
    }

    private void InstallManagers()
    {
        Container.Bind<ConditionsManager>().AsSingle();
        Container.Bind<QuestsManager>().AsSingle();        
    }

    private void InstallControllers()
    {
        Container.Bind<TurnBasedController>().FromInstance(_turnBasedController).AsSingle();    
        Container.Bind<LevelScrollController>().FromInstance(_levelScrollController).AsSingle();    
        Container.Bind<UIController>().FromInstance(_uiController).AsSingle();
        Container.Bind<QuestController>().AsSingle();    
    }

    private void InstallFabrics()
    {
        Container.Bind<ConditionFabric>().AsSingle();
        Container.Bind<QuestsFabric>().AsSingle();
    }

    private void InstallServices()
    {
        Container.Bind<BuffAndPerksService>().AsSingle();
    }
}
