using DontStopTheTrain;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PerksScriptableInstaller", menuName = "DST/DI/Installers/PerksScriptableInstaller")]
public class PerksScriptableInstaller : ScriptableObjectInstaller<PerksScriptableInstaller>
{
    [SerializeField]
    private PerksStaticStorage _perksStaticStorage;
    [SerializeField]
    private PerksLeveslStaticData _perksLeveslStaticData;

    public override void InstallBindings()
    {
        Container.Bind<PerksManager>().AsSingle();
        Container.Bind<PlayerPerksManager>().AsSingle();
        Container.Bind<PerksFabric>().AsSingle();
        Container.Bind<PerksController>().AsSingle();
        Container.Bind<PerksLeveslStaticData>().FromScriptableObject(_perksLeveslStaticData).AsSingle();
        Container.Bind<PerksStaticStorage>().FromScriptableObject(_perksStaticStorage).AsSingle();
    }
}