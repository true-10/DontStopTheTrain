using True10.LevelScrollSystem;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "LevelScrollSystemInstaller", menuName = "DST/DI/Installers/LevelScrollSystemInstaller")]
public class LevelScrollSystemInstaller : ScriptableObjectInstaller<LevelScrollSystemInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<LevelChunksManager>().AsSingle();
        Container.Bind<ChunkGiver>().AsSingle();
        Container.Bind<LevelScroller>().AsSingle();
    }
}