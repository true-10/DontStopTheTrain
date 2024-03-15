using DontStopTheTrain;
using Zenject;

public class InventorySceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Inventory>().AsSingle();
    }
}
