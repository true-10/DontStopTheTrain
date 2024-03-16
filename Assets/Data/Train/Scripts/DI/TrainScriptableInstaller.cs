using DontStopTheTrain;
using DontStopTheTrain.Events;
using DontStopTheTrain.Train;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "TrainScriptableInstaller", menuName = "DST/DI/Installers/TrainScriptableInstaller")]
public class TrainScriptableInstaller : ScriptableObjectInstaller<TrainScriptableInstaller>
{
    [SerializeField]
    private WagonsStaticStorage _wagonsStaticStorage;
    [SerializeField]
    private WagonSystemsStaticStorage _wagonSystemsStaticStorage;

    public override void InstallBindings()
    {
        Container.Bind<WagonsStaticStorage>().FromScriptableObject(_wagonSystemsStaticStorage).AsSingle();
        Container.Bind<WagonsStaticStorage>().FromScriptableObject(_wagonsStaticStorage).AsSingle();

        Container.Bind<WagonsFabric>().AsSingle();
        Container.Bind<WagonSystemsFabric>().AsSingle();

    }
}