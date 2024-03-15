using DontStopTheTrain;
using DontStopTheTrain.Events;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PlayerScriptableInstaller", menuName = "DST/DI/Installers/PlayerScriptableInstaller")]
public class PlayerScriptableInstaller : ScriptableObjectInstaller<PlayerScriptableInstaller>
{
    [SerializeField]
    private LevelsStaticStorage _levelsStaticStorage;

    public override void InstallBindings()
    {
        Container.Bind<LevelsStaticStorage>().FromScriptableObject(_levelsStaticStorage).AsSingle();
        Container.Bind<Player>().AsSingle();
    }
}