using DontStopTheTrain;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "BuffsScriptableInstaller", menuName = "DST/DI/Installers/BuffsScriptableInstaller")]
public class BuffsScriptableInstaller : ScriptableObjectInstaller<BuffsScriptableInstaller>
{
    [SerializeField]
    private BuffsStaticStorage _buffsStaticStorage;
    public override void InstallBindings()
    {
        Container.Bind<BuffsStaticStorage>().FromScriptableObject(_buffsStaticStorage).AsSingle();
        Container.Bind<PlayerBuffsManager>().AsSingle();
        Container.Bind<BuffsManager>().AsSingle();
        Container.Bind<BuffFabric>().AsSingle();
        Container.Bind<BuffsController>().AsSingle();
    }
}