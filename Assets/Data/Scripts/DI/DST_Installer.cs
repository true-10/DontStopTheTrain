using DontStopTheTrain.Events;
using DontStopTheTrain.Gameplay;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

public class DST_Installer : MonoInstaller
{
    #region fields
    [SerializeField] private CameraController cameraController;
    [SerializeField] private TurnController turnController;
    [SerializeField] private GameEventController gameEventController;

    #endregion
    public override void InstallBindings()
    {
        //camera
        Container.Bind<ICameraController>().FromInstance(cameraController);
        Container.Bind<ITurnController>().FromInstance(turnController);
        Container.Bind<IGameEventController>().FromInstance(gameEventController);
        
       // Container.Bind<IGameEventController>().To<GameEventController>().AsSingle().NonLazy();


        //Container.Bind<ICameraHolder>().To<CameraHolder>().AsSingle().NonLazy();

        //Container.Bind<ISpriteManager>().FromInstance(spriteManager);

    }
}
