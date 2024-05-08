using DontStopTheTrain;
using DontStopTheTrain.UI;
using System;
using True10.LevelScrollSystem;
using UnityEngine;
using Zenject;

public class DSTGameSceneInstaller : MonoInstaller
{ 
    [SerializeField] 
    private TurnBasedController _turnBasedController;
    [SerializeField] 
    private UIContainer _UIContainer;
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
        InstallPointOfInterestGenerator();
    }

    private void InstallPointOfInterestGenerator()
    {
        Container.Bind<PointOfInterestsManager>().AsSingle();
        Container.Bind<PointOfInterestsGenerator>().AsSingle();
        Container.Bind<PointOfInterestController>().AsSingle();
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
        Container.Bind<UIContainer>().FromInstance(_UIContainer).AsSingle();
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
