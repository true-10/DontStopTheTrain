using DontStopTheTrain;
using DontStopTheTrain.Events;
using DontStopTheTrain.Train;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "WagonScriptableInstaller", menuName = "DST/DI/Installers/WagonScriptableInstaller")]
public class WagonScriptableInstaller : ScriptableObjectInstaller<WagonScriptableInstaller>
{
    [SerializeField]
    private WagonPartsStaticStorage _wagonPartsStaticStorage;
    [SerializeField]
    private WagonsStaticStorage _wagonsStaticStorage;
    [SerializeField]
    private WagonSystemsStaticStorage _wagonSystemsStaticStorage;

    public override void InstallBindings()
    {
        Container.Bind<WagonPartsStaticStorage>().FromScriptableObject(_wagonPartsStaticStorage).AsSingle();
        Container.Bind<WagonsStaticStorage>().FromScriptableObject(_wagonSystemsStaticStorage).AsSingle();
        Container.Bind<WagonSystemsStaticStorage>().FromScriptableObject(_wagonsStaticStorage).AsSingle();

        Container.Bind<WagonsFabric>().AsSingle();
        Container.Bind<WagonSystemsFabric>().AsSingle();
        Container.Bind<WagonSystemsManager>().AsSingle();
        Container.Bind<WagonsManager>().AsSingle();

    }
}