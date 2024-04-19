using True10.CameraSystem;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "CameraSystemScriptableInstaller", menuName = "True10/DI/CameraSystemScriptableInstaller")]
public class CameraSystemScriptableInstaller : ScriptableObjectInstaller<CameraSystemScriptableInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<ICameraController>().To<CameraController>().AsSingle();
        Container.Bind<CamerasManager>().AsSingle();
        Container.Bind<CameraSwitcher>().AsSingle();
    }
}