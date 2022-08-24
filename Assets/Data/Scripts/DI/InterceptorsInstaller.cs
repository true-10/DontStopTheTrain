using Interceptors.BattleSystem;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

public class InterceptorsInstaller : MonoInstaller
{
    #region fields
    [SerializeField] private CameraController cameraController;

    #endregion
    public override void InstallBindings()
    {
        //camera
        Container.Bind<ICameraController>().FromInstance(cameraController);
        //Container.Bind<ICameraController>().To<CameraController>().AsSingle().NonLazy();

        Container.Bind<IBattleController>().To<BattleController>().AsSingle().NonLazy();
       
        //Container.Bind<ICameraHolder>().To<CameraHolder>().AsSingle().NonLazy();

        //Container.Bind<ISpriteManager>().FromInstance(spriteManager);

    }
}