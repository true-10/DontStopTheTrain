using DontStopTheTrain.Events;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "RewardsScriptableInstaller", menuName = "DST/DI/Installers/RewardsScriptableInstaller")]
public class RewardsScriptableInstaller : ScriptableObjectInstaller<RewardsScriptableInstaller>
{
    [SerializeField]
    private RewardsStaticStorage _rewardsStaticStorage;

    public override void InstallBindings()
    {
        Container.Bind<RewardsStaticStorage>().FromScriptableObject(_rewardsStaticStorage).AsSingle();
        Container.Bind<RewardController>().AsSingle();
    }
}