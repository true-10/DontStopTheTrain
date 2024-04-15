using True10.DayTimeSystem;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "DayTimeSystemInstaller", menuName = "True10/DI/DayTimeSystemInstaller")]
public class DayTimeSystemInstaller : ScriptableObjectInstaller<DayTimeSystemInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<DayTimeSystem>().AsSingle();
    }
}